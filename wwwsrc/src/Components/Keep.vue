<template>
  <div class="Keep">
    <div class="card mb-3 shadow" style="width: 18rem;">
      <img v-bind:src="`${keep.img}`" class="card-img-top img" alt />
      <div class="card-body">
        <h5 class="card-title">{{keep.name}}</h5>
        <p class="card-text">{{keep.description}}</p>
        <p>{{keep.views}}</p>
        <button class="btn-outline mr-1" type="button" @click="view">View</button>
        <button class="btn-outline ml-1" type="button" @click="keep">Save</button>
        <span class="bg-light text-danger rounded px-1 ml-3 pb-1" @click="removeKeep()">x</span>
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
    view() {
      // increment keep.views by one
      this.keep.views++;
      console.log(`count ${JSON.stringify(this.keep)}`);
      this.$store.dispatch("editKeep", this.keep);

      // now send to the new page.

      this.$router.push({
        name: "activeKeep",
        params: { keepId: this.keep.id }
      });
    },
    keepThis() {
      // save this keep to a vault
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
.img {
  min-width: 10vh;
  min-height: 10vh;
}
</style>