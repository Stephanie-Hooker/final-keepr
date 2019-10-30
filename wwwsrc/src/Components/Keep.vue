<template>
  <div class="Keep">
    <div class="card border-info mb-3 shadow" style="max-width: 18rem;">
      <img v-bind:src="`${keep.img}`" class="card-img-top img" alt />
      <div class="card-body">
        <h5 class="card-header">Name: {{keep.name}}</h5>
        <p class="card-body">Description: {{keep.description}}</p>

        <button class="btn btn-secondary raised active mr-1" type="button" @click="view">
          <i class="fa fa-eye fa-2x"></i>
          {{keep.views + 1}}
        </button>
        <button class="btn btn-secondary raised active ml-1" type="button" @click="saveKeep">
          <i class="fa fa-save fa-2x"></i>
          {{keep.keeps + 1}}
        </button>
        <button
          class="btn btn-outline-light raised active ml-2 text-danger"
          type="button"
          @click="removeKeep()"
        >
          <i class="fa fa-trash fa-2x"></i>
        </button>
      </div>
      <div class="form-group">
        <select class="form-control" v-model="newVaultId" @change="addVaultKeep()">
          <option disabled value>Move keep to:</option>
          <option v-for="vault in vaults" :key="vault.id" :value="vault.id">{{vault.name}}</option>
        </select>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "Keep",
  props: ["keep"],
  data() {
    return {
      newVaultId: ""
    };
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    view() {
      // increment keep.views by one
      this.keep.views++;
      this.$store.dispatch("editKeep", this.keep);

      // send to active page.

      this.$router.push({
        name: "activeKeep",
        params: { keepId: this.keep.id }
      });
    },
    saveKeep() {
      // increment keeps.keep by 1
      this.keep.keeps++;
      this.$store.dispatch("editKeep", this.keep);

      // send to active page.
      this.$router.push({
        name: "activeKeep",
        params: { keepId: this.keep.id }
      });
    },
    addVaultKeep() {
      let payload = {
        keepId: this.keep.id,
        vaultId: this.newVaultId
      };
      this.$store.dispatch("addVaultKeep", payload);
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
.btn-secondary.raised {
  box-shadow: 0 3px 0 0 #626566;
}

.btn-secondary.raised:active,
.btn-secondary.raised.active {
  background: #ec9b9b;
  box-shadow: none;
  margin-bottom: -3px;
  margin-top: 3px;
}
.form-control {
  width: 80%;
  margin: auto;
}
</style>