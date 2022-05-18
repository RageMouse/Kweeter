import Vue from 'vue'
import VueRouter from 'vue-router'
import HomeView from '../views/HomeView.vue'
import UsersView from '../views/UsersView.vue'
import LoginView from '../views/LoginView.vue'
import Store from '../store'
import Auth0Callback from '../views/Auth0Callback.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView,
    meta: { requiresAuth: true }
  },
  {
    path: '/about',
    name: 'about',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
  },
  {
    path: '/users',
    name: 'users',
    component: UsersView,
    meta: { requiresAuth: true }
  },
  {
    path: '/login',
    name: 'login',
    component: LoginView
  },
  {
    path: '/auth0callback',
    name: 'auth0callback',
    component: Auth0Callback
  }
]

const router = new VueRouter({
  mode: 'history',
  routes
})

router.beforeEach(((to, from, next) => {
  if (to.matched.some(record => record.path == "/auth0callback")) {
    console.log("router.beforeEach found /auth0callback url");
    Store.dispatch('auth0HandleAuthentication');
    next(false);
  }

  let routerAuthCheck = false;
  // Verify all the proper access variables are present for proper authorization
  if (localStorage.getItem('access_token') && localStorage.getItem('id_token') && localStorage.getItem('expires_at')) {
    console.log('Found local storage tokens');
    // Check whether the current time is past the Access Token's expiry time
    let expiresAt = JSON.parse(localStorage.getItem('expires_at'));
    // set localAuthTokenCheck true if unexpired / false if expired
    routerAuthCheck = new Date().getTime() < expiresAt;
  }

  // Set global GUI understanding of Authentication
  Store.commit('setUserIsAuthenticated', routerAuthCheck)

  if (to.matched.some(record => record.meta.requiresAuth)) {
    // Is user Authenticated?
    if (routerAuthCheck) {
      // User is authenticated
      next();
    }
    else {
      // User is not authenticated
      router.replace('/login');
    }
  }
  // Allowed
  else {
    next();
  }
}))

export default router
