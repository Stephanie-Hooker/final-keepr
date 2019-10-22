<template>
  <div class="sticky-top row">
    <div class="col-12">
      <nav class="navbar">
        <form class="form-inline">
          <button class="btn" type="button" @click="logout" v-if="user.email">Logout</button>
          <button class="btn" type="button" @click="login" v-else>Login</button>
          <div>
            <button class="btn" type="button" @click="vaultsButton" v-if="user.email">Vaults</button>
            <button class="btn" type="button" @click="keepsButton" v-if="user.email">Keeps</button>
          </div>
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
    },
    login() {
      this.$store.dispatch("login");
    },
    vaultsButton() {
      this.$store.dispatch("vaultsButton");
    },
    keepsButton() {
      this.$store.dispatch("keepsButton");
    }
  },
  components: {}
};
</script>


<style scoped>
/* .form-inline {
  display: contents;
} */
/* .sticky-top {
  position: sticky;
  background-color: #dad6d2;
} */
.btn {
  background-color: #4bbcbc;
  color: black;
}
.form-inline {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  flex-wrap: nowrap;
  display: contents;
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