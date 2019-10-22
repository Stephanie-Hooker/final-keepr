<template>
  <div class="Vaults">
    <div v-for="vault in vaults" :key="vault._id"></div>
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
    }
  },
  methods: {},
  components: { Vault }
};
</script>


<style scoped>
</style>