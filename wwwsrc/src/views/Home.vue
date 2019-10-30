<template>
  <div class="container-fluid bg home">
    <Navbar />
    <h2>View your public keeps</h2>
    <AddKeepsModal />
    <button
      class="btn btn-secondary btn-lg raised active"
      data-toggle="modal"
      data-target="#add-keeps-modal"
    >Add Keep</button>
    <Keeps />
  </div>
</template>

<script>
import Navbar from "../Components/Navbar";
import Keeps from "../Components/Keeps";
import AddKeepsModal from "../Components/AddKeepsModal";
export default {
  name: "home",
  components: { Navbar, Keeps, AddKeepsModal },
  computed: {},
  methods: {}
};
</script>

<style scoped>
.bg {
  background-color: #e2e1e0;
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
</style>
