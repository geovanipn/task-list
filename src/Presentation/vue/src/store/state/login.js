import taskListApi from '../../api/TaskListApi'

const state = {
    userName: undefined,
    token: undefined,
};

const actions = {
    async authenticate(userName, password) {
        try {
            var response = await taskListApi.post('/login/autenticar', {
                userName,
                password
            });
            
            state.token = `${response.data.data.method} ${response.data.data.token}`;
            state.userName = userName;

            taskListApi.setToken(state.token);
        } catch (error) {
            console.log(taskListApi.getFormattedMessage(error));
        }
    }
}

export default {
    state,
    actions
}