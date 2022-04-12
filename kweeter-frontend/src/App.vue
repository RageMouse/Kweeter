<template>
  <v-app>
    <v-app-bar app color="primary" dark src="https://picsum.photos/1920/1080?random">
      <div class="d-flex align-center">
        <v-img
          alt="Vuetify Logo"
          class="shrink mr-2"
          contain
          src="./assets/logo.png"
          transition="scale-transition"
          width="40"
        />
      </div>
      <v-tabs >
        <v-tab to="/">Home</v-tab>
        <v-tab to="/about">About</v-tab>
      </v-tabs>
      <div class="ml-3">
        <v-switch v-model="$vuetify.theme.dark" hide-details label="Theme Dark"></v-switch>
      </div>
    </v-app-bar>

    <v-main>
      <router-view></router-view>
    </v-main>
  </v-app>
</template>

<script>
// import NavBar from './components/NavBar.vue'

export default {
  name: "App",
  components: {
    // NavBar
  },
  data: () => ({
    //
  })
};
</script>
