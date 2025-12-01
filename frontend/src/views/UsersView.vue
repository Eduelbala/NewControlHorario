<template>
  <v-container fluid>
    <v-row class="mb-4" align="center" justify="space-between">
      <v-col cols="12" md="6">
        <h2 class="text-h5">Administración de usuarios</h2>
      </v-col>
      <v-col cols="12" md="6" class="text-right">
        <v-btn color="primary" prepend-icon="mdi-account-plus">Nuevo usuario</v-btn>
      </v-col>
    </v-row>
    <v-data-table :headers="headers" :items="items" class="elevation-1" :items-per-page="10">
      <template #item.roles="{ item }">
        <v-chip
          v-for="role in item.columns.roles"
          :key="role"
          size="small"
          class="ma-1"
        >
          {{ role }}
        </v-chip>
      </template>
    </v-data-table>
  </v-container>
</template>

<script setup>
const headers = [
  { title: 'Nombre', key: 'name' },
  { title: 'Correo', key: 'email' },
  { title: 'Roles', key: 'roles' },
  { title: 'Estado', key: 'status' }
]

const items = [
  { name: 'Ana Supervisor', email: 'ana@example.com', roles: ['Supervisor'], status: 'Activa' },
  { name: 'Carlos Admin', email: 'carlos@example.com', roles: ['Administrador'], status: 'Activa' },
  { name: 'Lucía Empleado', email: 'lucia@example.com', roles: ['Empleado'], status: 'Activa' }
]
</script>
