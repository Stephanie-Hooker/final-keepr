<template>
  <div class="container-fluid bg Vault">
    <NavVault />
    <div class="row justify-content-center mb-4 mt-5">
      <h1 class="fancy">
        <span>Your Vaults</span>
      </h1>
    </div>
    <div class="row justify-content-center mb-5">
      <AddVaultsModal />
      <button
        class="btn btn-secondary btn-lg raised active"
        data-toggle="modal"
        data-target="#add-vaults-modal"
      >Add Vault</button>
    </div>
    <Vaults />
  </div>
</template>

<script>
import NavVault from "../Components/NavVault";
import Vaults from "../Components/Vaults";
import AddVaultsModal from "../Components/AddVaultsModal";
export default {
  name: "Vault",
  data() {
    return {};
  },

  computed: {},

  methods: {
    returnHome() {
      this.$store.dispatch("returnHome");
    }
  },
  components: { AddVaultsModal, Vaults, NavVault }
};
</script>


<style scoped>
.bg {
  background-color: #e2e1e0;
  min-height: 100vh;
}
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
.fancy {
  line-height: 0.2;
  text-align: center;
}
.fancy span {
  display: inline-block;
  position: relative;
}
.fancy span:before,
.fancy span:after {
  content: "";
  position: absolute;
  height: 5px;
  border-bottom: 1px solid black;
  border-top: 1px solid black;
  top: 0;
  width: 600px;
}
.fancy span:before {
  right: 100%;
  margin-right: 15px;
}
.fancy span:after {
  left: 100%;
  margin-left: 15px;
}
</style>