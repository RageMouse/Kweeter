<template>
  <v-container>
    <v-row>
      <v-col cols="3">
        <ProfileCard />
        <FollowerCard />
      </v-col>
      <v-col cols="9">
        <UserCard />
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
// @ is an alias to /src
import ProfileCard from "@/components/ProfileCard.vue";
import UserCard from "@/components/UserCard.vue";
import FollowerCard from "@/components/FollowerCard.vue";

export default {
  name: "UsersView",
  components: {
    ProfileCard,
    UserCard,
    FollowerCard,
  },
};
</script>
