<template>
  <div class="Vaults">
    <div v-for="vault in vaults" :key="vault.id">
      <Vault :vault="vault" />
    </div>
  </div>
</template>


<script>
import Vault from "../Components/Vault";
export default {
  name: "Vaults",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getVaults");
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    },
    keeps() {
      return this.$store.state.keeps;
    }
  },
  methods: {},
  components: { Vault }
};
</script>


<style scoped>
</style>