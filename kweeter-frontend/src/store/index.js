import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

const baseUrl = 'http://localhost:5141/api/tweet/';

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
    addTweet(state, tweet) {
      state.tweets.push(tweet)
  },
  },
  actions: {
    getAllTweets(context) {
      return axios
        .get(baseUrl)
        .then((response) => {
          context.commit("setTweets", response.data);
          console.log(response.data)
        })
        .catch(error => {
          throw new Error(error)
        });
    },
    createTweet(context, data) {
      return axios
          .post(baseUrl, {
              title: data.tweetTitle,
              message: data.tweetMessage
          })
          .then(({ data }) => {
              context.commit("addTweet", data)
          }).catch((error) => {
              throw error
          })
  },
  },
  modules: {
  }
})