<template>
  <v-container>
    <v-row>
      <v-col cols="3">
        <ProfileCard />
        <TweetButton />
      </v-col>
      <v-col cols="9">
        <TweetsTimeline />
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
// @ is an alias to /src
import ProfileCard from "@/components/ProfileCard.vue";
import TweetsTimeline from "@/components/TweetsTimeline.vue";
import TweetButton from "@/components/TweetButton.vue"

export default {
  name: "HomeView",
  components: {
    ProfileCard,
    TweetsTimeline,
    TweetButton
  },
};
</script>
