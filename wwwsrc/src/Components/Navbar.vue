<template>
  <div class="sticky-top row justify-content-center">
    <div class="col-12">
      <nav class="Navbar">
        <form class="form-inline">
          <button class="btn logout" type="button" v-if="user.id" @click="logout">logout</button>
          <router-link v-else :to="{name: 'login'}">Login</router-link>
          <h3 class="welcome">Welcome, {{user.username}}</h3>
          <button class="btn dashboard" type="button" @click="dashboard">View Dashboard</button>
        </form>
      </nav>
    </div>
  </div>
</template>


<script>
import AuthService from "../AuthService";
export default {
  name: "Navbar",
  data() {
    return {};
  },
  computed: {
    user() {
      return this.$store.state.user;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  },
  components: {}
};
</script>


<style scoped>
.form-inline {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  flex-wrap: nowrap;
}

.sticky-top {
  position: sticky;
  background-color: rgb(197, 248, 248);
}
/* .welcome {
  display: inline-block;
  vertical-align: middle;
} */
</style>