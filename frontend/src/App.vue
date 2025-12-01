<template>
  <v-app>
    <v-app-bar app color="primary" dark>
      <v-app-bar-nav-icon @click="drawer = !drawer" />
      <v-toolbar-title>Control horario</v-toolbar-title>
      <v-spacer />
      <v-btn icon="mdi-account-circle" variant="text"></v-btn>
    </v-app-bar>

    <v-navigation-drawer v-model="drawer" app>
      <v-list density="compact" nav>
        <v-list-item
          v-for="item in menuItems"
          :key="item.to"
          :title="item.title"
          :value="item.to"
          :to="item.to"
          :prepend-icon="item.icon"
          link
        />
      </v-list>
    </v-navigation-drawer>

    <v-main class="pa-4">
      <router-view />
    </v-main>
  </v-app>
</template>

<script setup>
import { computed, ref } from 'vue'
import { useAuthStore } from './stores/auth'

const drawer = ref(true)
const authStore = useAuthStore()

const menuItems = computed(() => [
  { title: 'Dashboard', to: '/', icon: 'mdi-view-dashboard' },
  { title: 'Mis fichajes', to: '/fichajes', icon: 'mdi-clock-outline' },
  { title: 'Usuarios', to: '/admin/usuarios', icon: 'mdi-account-group-outline', role: 'Administrador' }
].filter((item) => !item.role || authStore.hasRole(item.role)))
</script>
