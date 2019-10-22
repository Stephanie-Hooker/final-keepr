<template>
  <div id="add-vaults-modal" class="modal" tabindex="-1" role="dialog">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Add Vault</h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="addVault()">
            <div class="form-group">
              <input
                type="text"
                class="form-control"
                id="name"
                placeholder="Enter Vault Name"
                v-model="newVault.name"
                required
              />
            </div>
            <div class="form-group">
              <input
                type="text"
                class="form-control"
                id="description"
                placeholder="Vault description"
                v-model="newVault.description"
              />
            </div>
            <button type="submit" class="btn btn-primary">Submit</button>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "add-vaults-modal",
  data() {
    return {
      newVault: {}
    };
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    addVault() {
      this.$store.dispatch("addVaults", this.newVault);
      $(".close").click();
    }
  },
  components: {}
};
</script>


<style scoped>
</style>