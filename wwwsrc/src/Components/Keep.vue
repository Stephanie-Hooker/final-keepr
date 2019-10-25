<template>
  <div class="Keep">
    <div class="card mb-3 shadow" style="width: 18rem;">
      <img v-bind:src="`${keep.img}`" class="card-img-top img" alt />
      <div class="card-body">
        <h5 class="card-title">Name: {{keep.name}}</h5>
        <p class="card-text">Description: {{keep.description}}</p>
        <p>Views: {{keep.views + 1}}</p>
        <p>Saves: {{keep.keeps + 1}}</p>
        <button class="btn-outline mr-1" type="button" @click="view">View</button>
        <button class="btn-outline ml-1" type="button" @click="saveKeep">Save</button>
        <span class="bg-light text-danger rounded px-1 ml-3 pb-1" @click="removeKeep()">x</span>
      </div>
      <select v-model="newVaultId" @change="addVaultKeep()">
        <option disabled value>Move keep to:</option>
        <option v-for="vault in vaults" :key="vault.id" :value="vault.id">{{vault.name}}</option>
      </select>
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
      debugger;
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
</style>