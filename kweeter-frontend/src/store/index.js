import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    tweets: {}
  },
  getters: {
    tweets(state) {
      return state.tweets
  },
  },
  mutations: {
    setTweets(state, tweets) {
      state.tweets = tweets;
  }
  },
  actions: {
    getAllTweets(context) {
      return axios
          .get("http://tweet_api:51603/tweet/get")
          .then((response) => {
              context.commit("setTweets", response.data);
          })
          .catch(error => {
              throw new Error(error)
          });
  },
  },
  modules: {
  }
})
