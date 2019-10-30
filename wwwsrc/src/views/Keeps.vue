<template>
  <div class="Keeps container-fluid">
    <!-- <Navbar /> -->
    <div class="row">
      <div class="col-3">
        <Keep v-for="keep in keeps" :keep="keep" :key="keep.id" />
      </div>
    </div>

    <AddKeepsModal />
    <button class="btn-outline" data-toggle="modal" data-target="#add-keeps-modal">Add Keep</button>
  </div>
</template>


<script>
import Keep from "../Components/Keep";
import AddKeepsModal from "../Components/AddKeepsModal";
import Navbar from "../Components/Navbar";
export default {
  name: "Keeps",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getKeeps");
  },
  computed: {
    keeps() {
      return this.$store.state.keeps;
    }
  },
  methods: {},
  components: { Keep, AddKeepsModal, Navbar }
};
</script>


<style scoped>
</style>