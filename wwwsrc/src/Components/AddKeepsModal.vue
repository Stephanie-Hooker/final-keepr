<template>
  <!-- <div class="KeepsModal"> -->
  <div id="add-keeps-modal" class="modal" tabindex="-1" role="dialog">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Add Keep</h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="addKeep()">
            <div class="form-group">
              <input
                type="text"
                class="form-control"
                id="Name"
                placeholder="Enter Keep Name"
                v-model="newKeep.Name"
                required
              />
            </div>
            <div class="form-group">
              <input
                type="text"
                class="form-control"
                id="Img"
                placeholder="Img url"
                v-model="newKeep.Img"
              />
            </div>
            <div class="form-group">
              <input
                type="text"
                class="form-control"
                id="Description"
                placeholder="Enter a Description"
                v-model="newKeep.Description"
              />
            </div>
            <button type="submit" class="btn btn-primary">Submit</button>
          </form>
          <div v-for="keep in Keeps" :key="keep._id"></div>
        </div>
      </div>
    </div>
  </div>
  <!-- </div> -->
</template>


<script>
export default {
  name: "add-keeps-modal",
  data() {
    return {
      newKeep: {}
    };
  },
  computed: {
    keeps() {
      return this.$store.state.keeps;
    }
  },
  methods: {
    AddKeep() {
      this.$store.dispatch("addKeep", this.newKeep);
      $(".close").click();
    }
  },
  components: {}
};
</script>


<style scoped>
</style>