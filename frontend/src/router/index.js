import { createRouter, createWebHistory } from 'vue-router'
import DashboardView from '../views/DashboardView.vue'
import TimeEntriesView from '../views/TimeEntriesView.vue'
import UsersView from '../views/UsersView.vue'

const routes = [
  { path: '/', name: 'dashboard', component: DashboardView },
  { path: '/fichajes', name: 'time-entries', component: TimeEntriesView },
  { path: '/admin/usuarios', name: 'users', component: UsersView }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
