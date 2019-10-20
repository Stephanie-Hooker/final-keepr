<template>
  <div class="container-fluid bg home">
    <Navbar />
    <!-- <h1>Welcome Home {{user.username}}</h1>
    <button v-if="user.id" @click="logout">logout</button>
    <router-link v-else :to="{name: 'login'}">Login</router-link>-->
  </div>
</template>

<script>
import Navbar from "../Components/Navbar";
export default {
  name: "home",
  components: { Navbar },
  computed: {
    // user() {
    //   return this.$store.state.user;
    // }
  },
  methods: {
    // logout() {
    //   this.$store.dispatch("logout");
    // }
  }
};
</script>