import Vue from 'vue'
import VueRouter from 'vue-router'
import TaskList from '../views/TaskList'
import Login from '../views/Login'

Vue.use(VueRouter)

const routes = [
    {
        path: '/',
        name: 'login',
        component: Login
    },
    {
        path: '/task-list',
        name: 'todo-list',
        component: TaskList
    }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
