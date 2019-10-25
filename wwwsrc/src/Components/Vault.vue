<template>
  <div class="Vault">
    <div class="card border-info mb-3 shadow" style="max-width: 18rem;">
      <span class="bg-light text-danger rounded px-1 ml-3 pb-1" @click="removeVault()">x</span>
      <div class="card-header">Name: {{vault.name}}</div>
      <div class="card-body text-info">
        <p class="card-text">Description: {{vault.description}}</p>
        <button class="btn-outline mr-1" type="button" @click="viewVault">View Vault</button>
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
    viewVault() {
      this.$router.push({
        name: "activeVault",
        params: { vaultId: this.vault.id }
      });
    },
    removeVault() {
      this.$store.dispatch("removeVault", this.vault);
    }
  },
  components: {}
};
</script>


<style scoped>
</style>