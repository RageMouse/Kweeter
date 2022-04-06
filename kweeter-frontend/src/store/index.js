import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    tweets: {},
    tweet: {
      tweetId: '',
      tweetTitle: '',
      tweetMessage: ''
    },
  },
  getters: {
    tweets(state) {
      return state.tweets
  },
  },
  mutations: {
    setTweets(state, tweets) {
      state.tweets = tweets;
  },
  },
  actions: {
    getAllTweets(context) {
      return axios
          .get("http://localhost:5141/api/tweet/")
          .then((response) => {
              context.commit("setTweets", response.data);
              console.log(response.data)
          })
          .catch(error => {
              throw new Error(error)
          });
  },
  },
  modules: {
  }
})
