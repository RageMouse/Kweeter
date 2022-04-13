import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'
import auth0 from 'auth0-js'
import router from '@/router'

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
    userIsAuthorized: false,
    auth0: new auth0.WebAuth({
      domain: process.env.VUE_APP_AUTH0_DOMAIN,
      clientID: process.env.VUE_APP_AUTH0_CLIENT_ID,
      redirectUri: process.env.VUE_APP_DOMAINURL + '/auth0callback',
      responseType: process.env.VUE_APP_AUTH0_CONFIG_RESPONSETYPE,
      scope: process.env.VUE_APP_AUTH0_CONFIG_SCOPE
    })
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
    setUserIsAuthenticated(state, replacement) {
      state.userIsAuthorized = replacement;
    }
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
    auth0Login(context) {
      context.state.auth0.authorize()
    },
    auth0HandleAuthentication(context) {
      context.state.auth0.parseHash((err, authResult) => {
        if (authResult && authResult.accessToken && authResult.idToken) {
          let expiresAt = JSON.stringify(
            authResult.expiresIn * 1000 + new Date().getTime()
          )
          // save the tokens locally
          localStorage.setItem('access_token', authResult.accessToken);
          localStorage.setItem('id_token', authResult.idToken);
          localStorage.setItem('expires_at', expiresAt);

          router.replace('/members');
        }
        else if (err) {
          alert('login failed. Error #KJN838');
          router.replace('/login');
          console.log(err);
        }
      })
    },
    auth0Logout() {
      localStorage.removeItem('access_token');
      localStorage.removeItem('id_token');
      localStorage.removeItem('expires_at');

      window.location.href = process.env.VUE_APP_AUTH0_DOMAINURL + "/v2/logout?returnTo=" + process.env.VUE_APP_DOMAINURL + "/login&client_id=" + process.env.VUE_APP_AUTH0_CLIENT_ID;
    }
  },
  modules: {
  }
})