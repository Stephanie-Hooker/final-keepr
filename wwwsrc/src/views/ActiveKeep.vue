<template>
  <div class="ActiveKeep">
    <div class="row">
      <button class="btn" type="button" @click="backToHome">Back to Homepage</button>

      <div class="card mb-3 shadow" style="width: 18rem;">
        <img v-bind:src="`${keep.img}`" class="card-img-top img" alt />
        <div class="card-body">
          <h5 class="card-title">{{keep.name}}</h5>
          <p class="card-text">{{keep.description}}</p>
          <span>views: {{keep.views}} saves: {{keep.save}}</span>
          <!-- <button class="btn-outline mr-1" type="button" @click="view">View</button> -->

          <button class="btn-outline ml-1" type="button" @click="save">Save</button>
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
    console.log(`KeepID: ${keepId}`);
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
    save() {
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