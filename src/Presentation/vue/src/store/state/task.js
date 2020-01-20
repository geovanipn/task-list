import taskListApi from '../../api/TaskListApi'

const actions = {
    delete: async (taskId) => {
        try {
            await taskListApi.delete(`/task/${taskId}`);
        } catch (error) {
            console.log(taskListApi.getFormattedMessage(error));
        }
    },
    update: async (task) => {
        
        var taskInput = {
            status: task.status,
            title: task.title,
            description: task.description
        };

        try {
            await taskListApi.put(`/task/${task.id}`, taskInput);
        } catch (error) {
            console.log(taskListApi.getFormattedMessage(error));
        }
    },
    create: async (title, description) => {
        
        var taskInput = {
            title: title,
            description: description
        };

        try {
            await taskListApi.post(`/task`, taskInput);
        } catch (error) {
            console.log(taskListApi.getFormattedMessage(error));
        }
    },
    listagemm: async () => {

        try {
            return (await taskListApi.get(`/task/listagem`)).data.data;
        } catch (error) {
            console.log(taskListApi.getFormattedMessage(error));
        }
    }
}

export default {
    actions
}