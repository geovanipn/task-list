<template>
  <v-app id="app">
    <v-app-bar app color="primary" dark >
      <v-toolbar-title>TaskList</v-toolbar-title>
    </v-app-bar>
    <v-content>
      <router-view />
    </v-content>
  </v-app>
</template>

<script>

export default {
  name: 'App',
};
</script>
