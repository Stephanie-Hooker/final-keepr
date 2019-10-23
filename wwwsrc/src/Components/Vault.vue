<template>
  <div class="Vault">
    <div class="card border-info mb-3 shadow" style="max-width: 18rem;">
      <span class="bg-light text-danger rounded px-1 ml-3 pb-1" @click="removeVault()">x</span>
      <div class="card-header">{{vault.name}}</div>
      <div class="card-body text-info">
        <p class="card-text">{{vault.description}}</p>
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
  // mounted() {
  //   this.$store.dispatch("getVaults");
  // },
  // computed: {
  //   vault() {
  //     return this.$store.state.vaults;
  //   }
  // },
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