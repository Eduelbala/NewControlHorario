<template>
  <v-container fluid>
    <v-row>
      <v-col cols="12" md="4">
        <v-card title="Estado de fichaje" subtitle="Resumen rápido">
          <v-card-text>
            <div class="text-body-1">Última acción: Entrada 08:01</div>
            <v-btn class="mt-4" color="primary">Fichar salida</v-btn>
          </v-card-text>
        </v-card>
      </v-col>
      <v-col cols="12" md="8">
        <v-card title="Próximos eventos">
          <v-card-text>
            <v-list>
              <v-list-item title="Vacaciones" subtitle="del 10/08 al 15/08" prepend-icon="mdi-beach"></v-list-item>
              <v-list-item title="Revisión horas extra" subtitle="Pendiente de aprobación" prepend-icon="mdi-briefcase-clock-outline"></v-list-item>
            </v-list>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>
