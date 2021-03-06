import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
import Vaults from './views/Vaults.vue'
import ActiveKeep from "./views/ActiveKeep.vue"
import ActiveVault from "./views/ActiveVault.vue"

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/vaults',
      name: 'vaults',
      component: Vaults
    },
    {
      path: '/activeKeep/:keepId',
      name: 'activeKeep',
      component: ActiveKeep
    },
    {
      path: '/activeVault/:vaultId',
      name: 'activeVault',
      component: ActiveVault
    }

  ]
})
