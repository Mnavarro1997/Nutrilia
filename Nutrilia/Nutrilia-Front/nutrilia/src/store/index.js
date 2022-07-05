import Vue from 'vue'
import Vuex from 'vuex'
import createPersistedState from 'vuex-persistedstate'

Vue.use(Vuex)

export default new Vuex.Store({
  plugins: [
    createPersistedState({
      storage: window.sessionStorage,
    })
  ],
  state: {
    currentUser: {},
  },
  mutations: {
    setCurrentUser(state, user) {
      state.currentUser = user
    }
  },
  actions: {
  },
  modules: {
  },
  getters: {
    getCurrentUser: state => state.currentUser
  }
})
