<template>
  <div class="Vault">
    <button btn-outline data-toggle="modal" data-target="#add-vaults-modal">Add a Vault</button>
    <div class="card border-info mb-3" style="max-width: 18rem;">
      <div class="card-header">{{vault.name}}</div>
      <div class="card-body text-info">
        <p class="card-text">{{vault.description}}</p>
        <span class="bg-light text-danger rounded px-1 ml-3 pb-1" @click="removeVault()">x</span>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "Vault",
  props: ["vault"],
  data() {
    return {};
  },
  computed: {},
  methods: {
    removeVault() {
      this.$store.dispatch("removeVault", this.vault);
    }
  },
  components: {}
};
</script>


<style scoped>
</style>