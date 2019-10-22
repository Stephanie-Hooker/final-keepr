<template>
  <div class="container-fluid Vault">
    <h3>Your Vaults</h3>
    <AddVaultsModal />
    <button btn-outline data-toggle="modal" data-target="#add-vaults-modal">Add a Vault</button>
  </div>
</template>

<script>
import Vaults from "../Components/Vaults";
import AddVaultsModal from "../Components/AddVaultsModal";
export default {
  name: "Vault",
  computed: {},
  methods: {},
  components: { AddVaultsModal, Vaults }
};
</script>


<style scoped>
</style>