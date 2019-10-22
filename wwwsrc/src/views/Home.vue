<template>
  <div class="container-fluid bg home">
    <Navbar />
    <h3>View your public keeps</h3>
    <AddKeepsModal />
    <button btn-outline data-toggle="modal" data-target="#add-keeps-modal">Add Keep</button>
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