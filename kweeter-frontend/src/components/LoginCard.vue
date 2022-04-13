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
            <v-card-title primary-title>
              <div>
                <h3 class="headline mb-0">Welcome</h3>
                <div>
                  Welcome to My Application. <br /><br />
                  Login to connect.
                  <br /><br />

                  Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed
                  do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                  Ut enim ad minim veniam, quis nostrud exercitation ullamco
                  laboris nisi ut aliquip ex ea commodo consequat.
                </div>
              </div>
            </v-card-title>
            <v-card-actions>
              <v-btn color="primary" dark @click="auth0Login()">Login</v-btn>
            </v-card-actions>
          </v-card>
        </v-flex>
      </v-layout>
    </v-slide-y-transition>
  </v-container>
</template>

<script>
export default {
  name: "LoginCard",
  methods: {
    auth0Login() {
      this.$store.dispatch("auth0Login");
    },
  },
};
</script>