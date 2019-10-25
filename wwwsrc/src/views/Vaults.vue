<template>
  <div class="container-fluid Vault">
    <div class="row justify-content-start">
      <button class="btn-outline" type="button" @click="returnHome">Back</button>
    </div>
    <h3>Your Vaults</h3>
    <AddVaultsModal />
    <button btn-outline data-toggle="modal" data-target="#add-vaults-modal">Add a Vault</button>
    <Vaults />
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

  computed: {},

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