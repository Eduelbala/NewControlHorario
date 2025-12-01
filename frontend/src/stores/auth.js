import { defineStore } from 'pinia'

export const useAuthStore = defineStore('auth', {
  state: () => ({
    user: {
      id: 'demo-user',
      name: 'Usuario Demo',
      roles: ['Administrador']
    },
    token: null
  }),
  actions: {
    login(payload) {
      this.user = payload.user
      this.token = payload.token
    },
    logout() {
      this.user = null
      this.token = null
    }
  },
  getters: {
    hasRole: (state) => (role) => state?.user?.roles?.includes(role)
  }
})
