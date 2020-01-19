using TaskList.Application.BoardContext.Interfaces;
using System.Threading.Tasks;
using MediatR;
using TaskList.Application.BoardContext.InputModels;
using TaskList.Domain.BoardContext.Commands;
using AutoMapper;
using Utils.Domain.Interfaces;
using System.Collections.Generic;
using TaskList.Domain.BoardContext.OutputModels;
using System;
using TaskList.Domain.BoardContext.Interfaces.Repositories;

namespace TaskList.Application.BoardContext.Services
{
    public sealed class TaskAppService : ITaskAppService , IDisposable
    {
        private readonly IMapper _mapper;
        private readonly IMediatorService _mediatorService;
        private readonly ITaskRepository _taskRepository;

        public TaskAppService(
            IMapper mapper,
            IMediatorService mediatorService,
            ITaskRepository taskRepository)
        {
            _mapper = mapper;
            _mediatorService = mediatorService;
            _taskRepository = taskRepository;
        }

        public async Task<Unit> Create(CreateTaskInputModel createTaskInputModel)
        {
            return await _mediatorService.SendCommand(
                _mapper.Map<CreateTaskCommand>(createTaskInputModel));
        }

        public async Task<Unit> Delete(DeleteTaskInputModel deleteTaskInputModel)
        {
            return await _mediatorService.SendCommand(
                _mapper.Map<DeleteTaskCommand>(deleteTaskInputModel));
        }

        public async Task<ICollection<TaskOutputModel>> Tasks(long userId)
        {
            return await _taskRepository.TasksByUser(userId);
        }

        public async Task<Unit> Update(long id, UpdateTaskInputModel updateTaskInputModel)
        {
            updateTaskInputModel.Id = id;
            return await _mediatorService.SendCommand(
                _mapper.Map<UpdateTaskCommand>(updateTaskInputModel));
        }

        public void Dispose()
        {
            _taskRepository.Dispose();
        }
    }
}
