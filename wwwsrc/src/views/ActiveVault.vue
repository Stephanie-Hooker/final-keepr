<template>
  <div class="ActiveVault container-fluid">
    <div class="row">
      <button class="btn-outline" type="button" @click="backToVault">Back to Vaults</button>
    </div>

    <div class="row justify-content-center">
      <h1>Name: {{vault.name}}</h1>
    </div>
    <div class="row justify-content-center">
      <h4>Description: {{vault.description}}</h4>
    </div>
    <div class="row">
      <div v-for="keep in keeps" :key="keep._id">
        <Keep :keep="keep" />
        <button class="btn-outline" @click="removeVaultKeep(keep.id)">Delete VaultKeep</button>
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
      this.$store.dispatch("removeVaultKeep", this.vaultKeep);
    },
    backToVault() {
      this.$store.dispatch("backToVault");
    }
  },
  components: { Keep }
};
</script>


<style scoped>
</style>