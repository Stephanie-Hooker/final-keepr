<template>
  <div class="sticky-top row">
    <div class="col-12">
      <nav class="navbar">
        <form class="form-inline">
          <button class="btn-outline" type="button" @click="logoutNav" v-if="user.email">Logout</button>
          <button class="btn-outline" type="button" @click="loginNav" v-else>Login</button>
          <div>
            <button
              class="btn-outline mr-1"
              type="button"
              @click="vaultsButton"
              v-if="user.email"
            >Vaults</button>
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
    logoutNav() {
      this.$store.dispatch("logoutNav");
    },
    loginNav() {
      this.$store.dispatch("loginNav");
    },
    vaultsButton() {
      this.$store.dispatch("vaultsButton");
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