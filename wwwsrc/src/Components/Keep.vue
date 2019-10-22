<template>
  <div class="Keep">
    <div class="card mb-3 shadow" style="max-width: 540px;">
      <div class="row no-gutters">
        <div class="col-md-4">
          <img v-bind:src="`${keep.img}`" class="card-img" alt />
        </div>
        <div class="col-md-8">
          <div class="card-body">
            <h5 class="card-title inline">{{keep.name}}</h5>
            <span class="bg-light text-danger rounded px-1 ml-1 pb-1" @click="removeKeep()">x</span>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "Keep",
  props: ["keep"],
  data() {
    return {};
  },
  computed: {},
  methods: {
    removeKeep() {
      this.$store.dispatch("removeKeep", this.keep);
    }
  },
  components: {}
};
</script>


<style scoped>
</style>