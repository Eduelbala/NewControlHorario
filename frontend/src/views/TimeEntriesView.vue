<template>
  <v-container fluid>
    <v-row class="mb-4" align="center" justify="space-between">
      <v-col cols="12" md="4">
        <h2 class="text-h5">Mis fichajes</h2>
      </v-col>
      <v-col cols="12" md="8" class="text-right">
        <v-btn color="primary" class="mr-2" prepend-icon="mdi-login-variant">Entrada</v-btn>
        <v-btn color="secondary" class="mr-2" prepend-icon="mdi-logout-variant">Salida</v-btn>
        <v-btn color="info" prepend-icon="mdi-cup-water">Inicio descanso</v-btn>
      </v-col>
    </v-row>
    <v-data-table
      :headers="headers"
      :items="items"
      class="elevation-1"
      :items-per-page="5"
    ></v-data-table>
  </v-container>
</template>

<script setup>
const headers = [
  { title: 'Fecha', key: 'date' },
  { title: 'Hora', key: 'time' },
  { title: 'Tipo', key: 'type' },
  { title: 'Comentario', key: 'comment' }
]

const items = [
  { date: '2024-08-01', time: '08:00', type: 'Entrada', comment: '' },
  { date: '2024-08-01', time: '14:00', type: 'Salida', comment: '' },
  { date: '2024-08-02', time: '08:02', type: 'Entrada', comment: 'Retraso por tráfico' }
]
</script>
