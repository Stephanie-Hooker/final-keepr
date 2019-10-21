import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'
import AuthService from './AuthService'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? '//localhost:5000/' : '/'

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    vaults: [],
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setVaults(state, vaults) {
      state.vaults = vaults
    },
    resetState(state) {
      //clear the entire state object of user data
      state.user = {}
    }
  },
  actions: {
    async register({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Register(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async login({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Login(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async logout({ commit, dispatch }) {
      try {
        let success = await AuthService.Logout()
        if (!success) { }
        commit('resetState')
        router.push({ name: "login" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    getVaults({ commit, dispatch }) {
      api.get('vaults')
        .then(res => {
          commit('setVaults', res.data)
        })
    },
    addVault({ commit, dispatch }, vaultData) {
      api.post('vaults', vaultData)
        .then(serverVault => {
          dispatch('getVaults')
        })
    },


    async removeVault({ dispatch }, payload) {
      try {

        let res = await api.delete('/vaults/' + payload)
        dispatch('getVaults')
        router.push({ name: "vaults" })
      } catch (error) {
        console.error("store.js: removeVault")
      }
    },
    backButton() {
      router.push({ name: "home" })
    },
    vaultButton() {
      router.push({ name: "vaults" })
    }

  }
})
