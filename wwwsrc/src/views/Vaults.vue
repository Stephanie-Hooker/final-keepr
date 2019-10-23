<template>
  <div class="container-fluid Vault">
    <div class="row justify-content-start">
      <button class="btn-outline" type="button" @click="returnHome">Back</button>
    </div>
    <h3>Your Vaults</h3>
    <AddVaultsModal />
    <button btn-outline data-toggle="modal" data-target="#add-vaults-modal">Add a Vault</button>
    <Vaults />
    <!-- <div class="card border-info mb-3 shadow" style="max-width: 18rem;">
      <div class="card-header">{{vaultProp.name}}</div>
      <div class="card-body text-info">
        <p class="card-text">{{vaultProp.description}}</p>
        <span class="bg-light text-danger rounded px-1 ml-3 pb-1" @click="removeVault()">x</span>
      </div>
    </div>-->
  </div>
</template>

<script>
import Vaults from "../Components/Vaults";
import AddVaultsModal from "../Components/AddVaultsModal";
export default {
  name: "Vault",
  data() {
    return {};
  },
  // props: ["vault, vaults"],
  computed: {
    // Vault() {
    //   return this.$store.state.vaults;
    // }
  },
  // mounted() {
  //   this.$store.dispatch("getVaults");
  // },
  methods: {
    returnHome() {
      this.$store.dispatch("returnHome");
    }
  },
  components: { AddVaultsModal, Vaults }
};
</script>


<style scoped>
</style>