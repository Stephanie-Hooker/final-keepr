<template>
  <div class="Keeps row">
    <div class="col-3" v-for="keep in keeps" :key="keep._id">
      <Keep :keep="keep" />
    </div>
  </div>
</template>


<script>
import Keep from "../Components/Keep";
export default {
  name: "Keeps",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getKeeps");
    this.$store.dispatch("getVaults");
  },
  computed: {
    keeps() {
      return this.$store.state.keeps;
    }
  },
  methods: {},
  components: { Keep }
};
</script>


<style scoped>
</style>