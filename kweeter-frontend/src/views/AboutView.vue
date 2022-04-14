<template>
  <v-container>
    <v-slide-y-transition mode="out-in">
      <v-layout row wrap align-center>
        <v-flex xs12 sm8 offset-sm2 md6 offset-md3 lg4 offset-lg4>
          <v-card style="margin-bottom: 200px">
            <div class="pa-3">
              <v-img
                alt="Vuetify Logo"
                class="shrink mr-2"
                contain
                src="../assets/logo.png"
                transition="scale-transition"
                width="40"
              />
            </div>
            <hr />
            <div style="text-align:center">
              <video
                width="320"
                height="320"
                playsinline
                controls
                autoplay
                loop
                poster="../assets/logo.png"
              >
                <source
                  :src="require('../assets/aboutme.mp4')"
                  type="video/mp4"
                />
              </video>
            </div>
          </v-card>
        </v-flex>
      </v-layout>
    </v-slide-y-transition>
  </v-container>
</template>