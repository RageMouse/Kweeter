<template>
  <v-container>
    <v-row>
      <v-card width="400">
        <v-img
          height="200px"
          src="https://cdn.pixabay.com/photo/2020/07/12/07/47/bee-5396362_1280.jpg"
        >
          <v-app-bar flat color="rgba(0, 0, 0, 0)">
            <v-toolbar-title class="text-h6 white--text pl-0">
              Profile
            </v-toolbar-title>
          </v-app-bar>

          <v-card-title class="white--text mt-8">
            <v-avatar size="56">
              <img
                alt="user"
                src="https://cdn.pixabay.com/photo/2020/06/24/19/12/cabbage-5337431_1280.jpg"
              />
            </v-avatar>
            <p class="ml-3" v-text="profile.nickname">John Doe</p>
          </v-card-title>
        </v-img>
      </v-card>
    </v-row>
  </v-container>
</template>


<script>
export default {
  name: "ProfileCard",
  computed: {
    profile() {
      return this.$store.getters.profile;
    },
  },
  mounted() {},
  methods: {},
};
</script>