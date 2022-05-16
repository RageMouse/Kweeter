<template>
  <v-card class="elevation-12 mx-auto" max-width="1500">
    <v-container fluid>
      <v-row dense>
        <v-col
          cols="12"
          md="6"
          sm="4"
          xs="12"
        >
          <v-card class="mx-auto" color="#26c6da" dark max-width="600">
            <v-card-title>
              <v-icon large left> mdi-twitter </v-icon>
              <span
                class="text-h6 font-weight-light"
              >User</span>
            </v-card-title>

            <v-card-text
              class="text-h5 font-weight-bold"
            >maybedennis
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
                  <v-btn color="secondary" dark @click="followUser" > Follow </v-btn>
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
  name: "followUser",
  data: () => ({
    username: ""
  }),
  methods: {
    followUser() {
      return this.$store.dispatch("followUser", this.username);
    }
  },
};
</script>