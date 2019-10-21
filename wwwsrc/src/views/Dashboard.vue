<template>
  <div class="Dashboard">
    <h1 class="title pt-4">Your Dashboard!</h1>
    <form @submit.prevent="addVault">
      <input type="text" placeholder="name" v-model="newVault.name" required />
      <input type="text" placeholder="description" v-model="newVault.description" />
      <button class="btn create m-1" type="submit">Create Vault</button>
      <button class="btn backButton" @click="backButton">Back</button>
    </form>
    <div v-for="vault in vaults" :key="vault._id">
      <router-link class="link" :to="{name: 'vault', params: {vaultId: vault._id}}">{{vault.name}}</router-link>
      <span class="delete-vaults delete m-2" @click="removeVaults(vault._id)">x</span>
    </div>
  </div>
</template>

<script>
import router from "@/router.js";
export default {
  name: "Dashboard",
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
    addVault() {
      this.$store.dispatch("addVault", this.newVault);
      this.newVault = { name: "", description: "" };
    },
    removeVault(id) {
      this.$store.dispatch("removeVault", id);
    },
    backButton() {
      this.$store.dispatch("backButton");
    }
  }
};
</script>


<style scoped>
</style>