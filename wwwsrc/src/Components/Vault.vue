<template>
  <div class="Vault">
    <div class="card border-dark mb-3 shadow" style="max-width: 18rem;">
      <button
        class="btn btn-outline-light raised active ml-2 text-danger"
        type="button"
        @click="removeVault()"
      >
        <i class="fa fa-trash fa-2x"></i>
      </button>
      <div class="card-header">Name: {{vault.name}}</div>
      <div class="card-body text-dark">
        <p class="card-text">Description: {{vault.description}}</p>
        <button
          class="btn btn-secondary btn-lg raised active mr-1"
          type="button"
          @click="viewVault"
        >View Vault</button>
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