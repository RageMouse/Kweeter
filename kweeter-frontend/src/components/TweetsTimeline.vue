<template>
  <v-card class="elevation-12 mx-auto" max-width="1500">
    <v-container fluid>
      <v-row dense>
        <v-col
          v-for="tweet in tweets"
          :key="tweet.tweetId"
          cols="12"
          md="3"
          sm="4"
          xs="12"
        >
          <v-card class="mx-auto" color="#26c6da" dark max-width="600">
            <v-card-title>
              <v-icon large left> mdi-twitter </v-icon>
              <span class="text-h6 font-weight-light" v-text="tweet.tweetName"></span>
            </v-card-title>

            <v-card-text class="text-h5 font-weight-bold">
              "Turns out semicolon-less style is easier and safer in TS because
              most gotcha edge cases are type invalid as well."
            </v-card-text>

            <v-card-actions>
              <v-list-item class="grow">
                <v-list-item-avatar color="grey darken-3">
                  <v-img
                    class="elevation-6"
                    alt=""
                    src="https://avataaars.io/?avatarStyle=Transparent&topType=ShortHairShortCurly&accessoriesType=Prescription02&hairColor=Black&facialHairType=Blank&clotheType=Hoodie&clotheColor=White&eyeType=Default&eyebrowType=DefaultNatural&mouthType=Default&skinColor=Light"
                  ></v-img>
                </v-list-item-avatar>

                <v-list-item-content>
                  <v-list-item-title>Evan You</v-list-item-title>
                </v-list-item-content>

                <v-row align="center" justify="end">
                  <v-icon class="mr-1"> mdi-heart </v-icon>
                  <span class="subheading mr-2">256</span>
                  <span class="mr-1">·</span>
                  <v-icon class="mr-1"> mdi-share-variant </v-icon>
                  <span class="subheading">45</span>
                </v-row>
              </v-list-item>
            </v-card-actions>
          </v-card>
        </v-col>
      </v-row>
    </v-container>
  </v-card>
</template>

<script>
export default {
  name: "tweetList",
  computed: {
    tweets() {
      return this.$store.getters.tweets;
    },
  },
  mounted() {
    this.getAllTweets();
  },
  methods: {
    getAllTweets() {
      return this.$store.dispatch("getAllTweets");
    },
  },
};
</script>