<template>
  <div class="sticky-top row">
    <div class="col-12">
      <nav class="navbar">
        <form class="form-inline">
          <button
            class="btn btn-secondary btn-lg raised active"
            type="button"
            @click="logoutNav"
            v-if="user.email"
          >Logout</button>
          <button
            class="btn btn-secondary btn-lg raised active"
            type="button"
            @click="loginNav"
            v-else
          >Login</button>
          <div>
            <button
              class="btn btn-secondary btn-lg raised active mr-1"
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

.btn-secondary.raised {
  box-shadow: 0 3px 0 0 #626566;
}

.btn-secondary.raised:active,
.btn-secondary.raised.active {
  background: #ec9b9b;
  box-shadow: none;
  margin-bottom: -3px;
  margin-top: 3px;
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
  background-color: #f8f8f8;
}
/* .welcome {
  display: inline-block;
  vertical-align: middle;
} */
</style>