using System;
using System.Threading.Tasks;
using TaskList.Domain.SharedContext.Commands;
using TaskList.Domain.SharedContext.Notifications;
using Utils.Domain.Interfaces;
using Utils.EntityFramework.SqlDataContext;

namespace TaskList.Domain.SharedContext.CommandHandler
{
    public abstract class CommandHandler : IDisposable
    {
        protected readonly IMediatorService _mediatorService;
        private readonly IDbContext _dbContext;

        protected CommandHandler(
            IMediatorService mediatorService,
            IDbContext dbContext)
        {
            _mediatorService = mediatorService;
            _dbContext = dbContext;
        }

        public async Task<bool> CommandIsValid(Command request)
        {
            if (request.IsValid()) return true;

            await NotifyValidationErrors(request);

            return false;
        }

        private async Task NotifyValidationErrors(Command request)
        {
            foreach (var error in request.ValidationResult.Errors)
                await _mediatorService.SendNotification(new DomainNotification(request.Name, error.ErrorMessage));
        }

        public async Task<bool> Commit()
        {
            if (_mediatorService.HasNotifications()) 
                return false;

            try
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                await _mediatorService.SendNotification(new DomainNotification("Erro ao processar requisição", e.Message));
                return false;
            }
        }

        public virtual void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
