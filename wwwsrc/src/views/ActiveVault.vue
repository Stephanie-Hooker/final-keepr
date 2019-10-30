<template>
  <div class="ActiveVault container-fluid bg">
    <div class="row ml-1">
      <button
        class="btn btn-secondary btn-lg raised active"
        type="button"
        @click="backToVault"
      >Back to Vaults</button>
    </div>

    <div class="row justify-content-center">
      <h1>Name: {{vault.name}}</h1>
    </div>
    <div class="row justify-content-center">
      <h4>Description: {{vault.description}}</h4>
    </div>
    <div class="row mx-2 mt-3">
      <div class="col-3 mx-2"></div>
      <div v-for="keep in keeps" :key="keep._id">
        <Keep :keep="keep" />
        <button
          class="btn btn-secondary btn-lg raised active"
          @click="removeVaultKeep(keep.id)"
        >Delete</button>
      </div>
    </div>
  </div>
</template>


<script>
import router from "@/router.js";
import Keep from "../Components/Keep.vue";
export default {
  name: "ActiveVault",
  data() {
    return {};
  },
  mounted() {
    let vaultId = this.$route.params.vaultId;
    this.$store.dispatch("getVaultById", vaultId);
    this.$store.dispatch("getVaultKeeps", vaultId);
  },
  computed: {
    vault() {
      return this.$store.state.activeVault;
    },
    keeps() {
      return this.$store.state.vaultKeeps;
    }
  },
  methods: {
    removeVaultKeep(keepId) {
      this.$store.dispatch("removeVaultKeep", {
        keepId,
        vaultId: this.vault.id
      });
    },
    backToVault() {
      this.$store.dispatch("backToVault");
    }
  },
  components: { Keep }
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
</style>