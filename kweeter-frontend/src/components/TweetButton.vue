<template>
  <v-row justify="center">
    <v-dialog v-model="dialog" persistent max-width="600px">
      <template v-slot:activator="{ on, attrs }">
        <v-btn color="primary" dark v-bind="attrs" v-on="on"> Tweet </v-btn>
      </template>
      <v-card>
        <v-card-title>
          <span class="text-h5">Tweet</span>
        </v-card-title>
        <v-card-text>
          <v-form ref="form" lazy-validation>
            <v-row>
              <v-col cols="12">
                <v-text-field
                  id="tweetTitle"
                  v-model="form.tweetTitle"
                  label="Title"
                  required
                  :counter="25"
                  :rules="[(v) => !!v || 'Title is required']"
                ></v-text-field>
              </v-col>
              <v-textarea
                id="tweetMessage"
                v-model="form.tweetMessage"
                solo
                name="input-7-4"
                label="Solo textarea"
                :counter="255"
                :rules="[(v) => !!v || 'Message is required']"
              ></v-textarea>
            </v-row>
          </v-form>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue darken-1" text @click="reset"> Close </v-btn>
          <v-btn color="blue darken-1" text @click="validate"> Save </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-row>
</template>

<script>
export default {
  name: "tweetButton",
  data: () => ({
    dialog: false,
    form: {
      tweetTitle: "",
      tweetMessage: "",
    },
  }),
  methods: {
    validate() {
      if (this.$refs.form.validate()) {
        this.createTweet();
        this.reset();
        this.dialog = false;
      }
    },
    createTweet() {
      console.log(this.form);
      return this.$store.dispatch("createTweet", this.form);
    },
    reset() {
      this.$refs.form.reset();
      this.dialog = false;
    },
  },
};
</script>