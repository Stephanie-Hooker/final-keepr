import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'
import AuthService from './AuthService'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? 'https://localhost:5001/' : '/'
// let baseUrl = location.host.includes('localhost') ? '//localhost:5000/' : '/'

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    vaultKeeps: [],
    vaults: [],
    keeps: [],
    activeKeep: {},
    activeVault: {},

  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setKeeps(state, keeps) {
      state.keeps = keeps
    },
    setVaults(state, vaults) {
      state.vaults = vaults
    },
    setVaultKeeps(state, vaultKeeps) {
      state.vaultKeeps = vaultKeeps
    },
    setActiveKeep(state, activeKeep) {
      state.activeKeep = activeKeep;
    },
    setActiveVault(state, activeVault) {
      state.activeVault = activeVault
    },
    resetState(state) {
      //clear the entire state object of user data
      state.user = {}
    }
  },
  actions: {
    backButton() {
      router.push({ name: "home" })
    },
    vaultsButton() {
      router.push({ name: "vaults" })
    },
    viewKeep() {
      router.push({ name: "activeKeep" })
    },
    saveKeep() {
      router.push({ name: "activeKeep" })
    },
    backToHome() {
      router.push({ name: "home" })
    },
    returnHome() {
      router.push({ name: "home" })
    },
    viewVault() {
      router.push({ name: "activeVault" })
    },
    backToVault() {
      router.push({ name: "vaults" })
    },


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

    async addVaults({ commit, dispatch }, vaultData) {
      try {
        let res = await api.post('/vaults', vaultData)
        dispatch("getVaults")
      } catch (error) {
        console.error(error)
      }
    },

    async getVaults({ commit, dispatch }) {
      try {
        let res = await api.get('/vaults')
        commit('setVaults', res.data)
      } catch (error) {
        console.error(error)
      }
    },

    async getVaultById({ commit }, vaultId) {
      try {
        let res = await api.get(`/vaults/${vaultId}`);
        commit('setActiveVault', res.data);
      } catch (error) {
        console.error(error)
      }
    },

    async removeVault({ dispatch }, data) {
      try {
        let res = await api.delete('/vaults/' + data.id)
        dispatch('getVaults')
      } catch (error) {
        console.error("store.js: removeVault")
      }
    },

    async  addKeep({ commit, dispatch }, keepData) {
      try {
        let res = await api.post('/keeps', keepData)
        dispatch("getKeeps")
      } catch (error) {
        console.error(error)
      }

    },
    async getKeeps({ commit, dispatch }) {
      try {
        let res = await api.get('/keeps')
        commit('setKeeps', res.data)
      } catch (error) {
        console.error(error)
      }
    },

    async getKeepById({ commit, dispatch }, keepId) {
      try {
        let res = await api.get(`/keeps/${keepId}`);
        commit('setActiveKeep', res.data);
      } catch (error) {
        console.error(error);
      }
    },

    async editKeep({ commit, dispatch }, keep) {
      try {
        let res = await api.put(`/keeps/${keep.id}`, keep);
        dispatch("getKeeps");
      } catch (error) {
        console.error(error);
      }
    },

    async removeKeep({ dispatch }, data) {
      try {
        let res = await api.delete('/keeps/' + data.id)
        dispatch("getKeeps")
      } catch (error) {
        console.error(error)
      }
    },

    async addVaultKeep({ dispatch, commit }, payload) {
      try {
        let res = await api.post('/vaultkeeps', payload)
        dispatch("getVaultKeeps", res.data.vaultId)
      } catch (error) {
        console.error(error)
      }
    },

    async getVaultKeeps({ dispatch, commit }, vaultId) {
      try {
        let res = await api.get(`/vaultkeeps/${vaultId}`)
        commit("setVaultKeeps", res.data)
      } catch (error) {
        console.error(error)
      }
    },

    async removeVaultKeep({ dispatch }, vaultKeep) {
      try {
        let res = await api.put('/vaultkeeps', vaultKeep)
        dispatch("getVaultKeeps")
      } catch (error) {
        console.error(error)
      }
    }
  }
})
