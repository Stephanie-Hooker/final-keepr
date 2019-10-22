<template>
  <div class="container-fluid bg home">
    <Navbar />
    <!-- <h1>Welcome Home {{user.username}}</h1>
    <button v-if="user.id" @click="logout">logout</button>
    <router-link v-else :to="{name: 'login'}">Login</router-link>-->
    <h3>View your public keeps</h3>
    <AddKeepsModal />
    <button btn-outline data-toggle="modal" data-target="#add-keeps-modal">Add Keep</button>
    <Keeps />
    <!-- <form>
      <div class="form-group row">
        <label for="Title" class="col-sm-2 col-form-label">Title</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="title" placeholder="Title of Keep" />
        </div>
      </div>
      <div class="form-group row">
        <label for="Imgurl" class="col-sm-2 col-form-label">ImgUrl</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="ImgUrl" placeholder="Url for Keep" />
        </div>
      </div>
      <div class="form-group row">
        <label for="description" class="col-sm-2 col-form-label">Description</label>
        <div class="col-sm-10">
          <input
            type="text"
            class="form-control"
            id="Description"
            placeholder="Enter a description"
          />
        </div>
    </div>-->
    <!-- <fieldset class="form-group">
    <div class="row">
      <legend class="col-form-label col-sm-2 pt-0">Radios</legend>
      <div class="col-sm-10">
        <div class="form-check">
          <input class="form-check-input" type="radio" name="gridRadios" id="gridRadios1" value="option1" checked>
          <label class="form-check-label" for="gridRadios1">
            First radio
          </label>
        </div>
        <div class="form-check">
          <input class="form-check-input" type="radio" name="gridRadios" id="gridRadios2" value="option2">
          <label class="form-check-label" for="gridRadios2">
            Second radio
          </label>
        </div>
        <div class="form-check disabled">
          <input class="form-check-input" type="radio" name="gridRadios" id="gridRadios3" value="option3" disabled>
          <label class="form-check-label" for="gridRadios3">
            Third disabled radio
          </label>
        </div>
      </div>
    </div>
    </fieldset>-->
    <!-- <div class="form-group row">
        <div class="col-sm-2">Checkbox</div>
        <div class="col-sm-10">
          <div class="form-check">
            <input class="form-check-input" type="checkbox" id="gridCheck1" />
            <label class="form-check-label" for="gridCheck1">private</label>
          </div>
        </div>
      </div>
      <div class="form-group row">
        <div class="col-sm-10">
          <button class="btn btn-primary" type="submit" @click="submit">Keep</button>
        </div>
      </div>
    </form>-->
  </div>
</template>

<script>
import Navbar from "../Components/Navbar";
import Keeps from "../Components/Keeps";
import AddKeepsModal from "../Components/AddKeepsModal";
export default {
  name: "home",
  components: { Navbar, Keeps, AddKeepsModal },
  computed: {
    // user() {
    //   return this.$store.state.user;
    // }
  },
  methods: {
    // logout() {
    //   this.$store.dispatch("logout");
    // }
  }
};
</script>