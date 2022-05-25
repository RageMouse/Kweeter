<template>
  <v-container>
    <v-row>
      <v-card width="400">
        <v-img
          height="400px"
          src="https://cdn.pixabay.com/photo/2015/12/01/15/43/black-1072366_960_720.jpg"
        >
          <v-app-bar flat color="rgba(0, 0, 0, 0)">
            <v-toolbar-title class="text-h6 white--text pl-0">
              People you follow
            </v-toolbar-title>
          </v-app-bar>

          <v-card-title
            class="white--text mt-8"
            v-for="user in usersYouFollow"
            :key="user.userFollowed"
          >
            <v-avatar size="56">
              <img
                alt="user"
                src="https://cdn.pixabay.com/photo/2020/06/24/19/12/cabbage-5337431_1280.jpg"
              />
            </v-avatar>
            <p class="ml-3" v-text="user.userFollowed">John Doe</p>
          </v-card-title>
        </v-img>
      </v-card>
    </v-row>
  </v-container>
</template>


<script>
export default {
  name: "FollowerCard",
  computed: {
    usersYouFollow() {
      return this.$store.getters.usersYouFollow;
    },
  },
  mounted() {
    this.getAllUsersYouFollow();
  },
  methods: {
    getAllUsersYouFollow() {
      return this.$store.dispatch("getUsersYouFollow");
    },
  },
};
</script>