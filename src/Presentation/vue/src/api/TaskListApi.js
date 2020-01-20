import Axios from 'axios'

const axios = Axios.create({
    baseURL: 'https://localhost:5001/api/v1/supero/'
});

export default {
    get: axios.get,
    put: axios.put,
    delete: axios.delete,
    post: axios.post,
    getFormattedMessage: (error) => {
        if(error && error.data && error.data.status) {
            switch (error.response.status) {
                case 400: return error.response.data.errors.join('\n');
                default: return error.message
            }
        }
        return error.message;
    },
    setToken(token) {
        axios.defaults.headers.common['Authorization'] = `${token}`;
    }
};