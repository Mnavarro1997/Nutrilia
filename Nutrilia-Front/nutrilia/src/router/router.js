import HomeView from '../views/HomeView.vue';
import LoginView from '../views/LoginView.vue';
import { createRouter, createWebHashHistory } from 'vue-router'


const routes = [
    {
      path: '/',
      name: 'Home',
      component: HomeView
    },
    {
      path: '/login',
      name: 'Login',
      component: LoginView
    },
]

const router = createRouter({
    history: createWebHashHistory(),
    routes
  })
  
  export default router