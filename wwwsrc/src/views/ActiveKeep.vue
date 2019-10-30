<template>
  <div class="ActiveKeep bg">
    <div class="row ml-1">
      <button
        class="btn btn-secondary raised active"
        type="button"
        @click="backToHome"
      >Back to Homepage</button>
    </div>
    <div class="row justify-content-center">
      <div class="card border-info mb-3 shadow" style="width: 50vh">
        <img v-bind:src="`${keep.img}`" class="card-img-top img" alt />
        <div class="card-body">
          <h5 class="card-header">Name: {{keep.name}}</h5>
          <p class="card-body">Description: {{keep.description}}</p>
          <!-- <span>views: {{keep.views + 1}} saves: {{keep.keeps + 1}}</span>
          <span class="bg-light text-danger rounded px-1 ml-3 pb-1" @click="removeKeep()">x</span>-->
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
  </div>
</template>


<script>
import router from "@/router.js";
export default {
  name: "ActiveKeep",

  data() {
    return {
      newVaultId: ""
    };
  },
  mounted() {
    let keepId = this.$route.params.keepId;
    this.$store.dispatch("getKeepById", keepId);
  },
  computed: {
    keep() {
      return this.$store.state.activeKeep;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    backToHome() {
      this.$store.dispatch("backToHome");
    },
    addVaultKeep() {
      let payload = {
        keepId: this.keep.id,
        vaultId: this.newVaultId
      };
      this.$store.dispatch("addVaultKeep", payload);
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
.bg {
  background-color: #e2e1e0;
}
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