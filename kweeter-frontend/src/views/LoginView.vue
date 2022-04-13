<template>
  <v-container>
    <v-row>
      <v-col cols="12">
        <LoginCard />
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
// @ is an alias to /src
import LoginCard from "@/components/LoginCard.vue";

export default {
  name: "HomeView",
  components: {
    LoginCard
  },
};
</script>