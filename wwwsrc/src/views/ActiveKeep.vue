<template>
  <div class="ActiveKeep">
    <button class="btn-outline" type="button" @click="backToHome">Back to Homepage</button>
    <div class="row">
      <div class="card mb-3 shadow" style="width: 18rem;">
        <img v-bind:src="`${keep.img}`" class="card-img-top img" alt />
        <div class="card-body">
          <h5 class="card-title">Name: {{keep.name}}</h5>
          <p class="card-text">Description: {{keep.description}}</p>
          <span>views: {{keep.views + 1}} saves: {{keep.keeps + 1}}</span>
          <span class="bg-light text-danger rounded px-1 ml-3 pb-1" @click="removeKeep()">x</span>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import router from "@/router.js";
export default {
  name: "ActiveKeep",
  data() {
    return {};
  },
  mounted() {
    let keepId = this.$route.params.keepId;
    this.$store.dispatch("getKeepById", keepId);
  },
  computed: {
    keep() {
      return this.$store.state.activeKeep;
    }
  },
  methods: {
    backToHome() {
      this.$store.dispatch("backToHome");
    },
    view() {
      this.$store.dispatch("viewKeep");
    },
    saveKeep() {
      this.$store.dispatch("saveKeep");
    },
    removeKeep() {
      this.$store.dispatch("removeKeep", this.keep);
    }
  },
  components: {}
};
</script>


<style scoped>
</style>