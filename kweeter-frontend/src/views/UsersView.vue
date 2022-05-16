<template>
  <v-container>
    <v-row>
      <v-col cols="3">
        <ProfileCard />
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

export default {
  name: "UsersView",
  components: {
    ProfileCard,
    UserCard
  },
};
</script>
