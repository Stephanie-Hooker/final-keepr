<template>
  <div class="Vault">
    <button class="btn-outline backButton" @click="backButton">Back</button>
    <h1 class="title pt-4">Your Vaults!</h1>
    <h3>Add a Vault</h3>
    <form @submit.prevent="addVault">
      <input type="text" placeholder="name" v-model="newVault.name" required />
      <input type="text" placeholder="description" v-model="newVault.description" />
      <button class="btn-outline create m-1" type="submit">Create a Vault</button>
    </form>
    <div v-for="vault in vaults" :key="vault._id">
      <router-link class="link" :to="{name: 'vault', params: {vaultId: vault._id}}">{{vault.name}}</router-link>
      <span class="delete-vaults delete m-2" @click="removeVaults(vault._id)">x</span>
    </div>
    <!-- <AddKeepsModal />
    <button class="btn-outline" data-toggle="modal" data-target="#add-keeps-modal">Add Keep</button>-->
  </div>
</template>

<script>
import router from "@/router.js";
// import AddKeepsModal from "../Components/AddKeepsModal";
export default {
  name: "Vault",
  props: ["vaultId"],
  mounted() {
    this.$store.dispatch("getVaults");
  },
  data() {
    return {
      newVault: {
        name: "",
        description: ""
      }
    };
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    addVaults() {
      this.$store.dispatch("addVaults", this.newVault);
      this.newVault = { name: "", description: "" };
    },
    removeVault(id) {
      this.$store.dispatch("removeVault", id);
    },
    backButton() {
      this.$store.dispatch("backButton");
    }
  },
  components: {}
};
</script>


<style scoped>
</style>