<template>
  <div class="NavVault sticky-top row">
    <div class="col-12">
      <nav class="navbar">
        <button
          class="btn btn-secondary btn-lg raised active"
          type="button"
          @click="returnHome"
        >Back</button>
      </nav>
    </div>
  </div>
</template>


<script>
export default {
  name: "NavVault",
  data() {
    return {};
  },
  computed: {},
  methods: {
    returnHome() {
      this.$store.dispatch("returnHome");
    }
  },
  components: {}
};
</script>


<style scoped>
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
.form-inline {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  flex-wrap: nowrap;
  display: contents;
}
.sticky-top {
  position: sticky;
  background-color: #f8f8f8;
}
</style>