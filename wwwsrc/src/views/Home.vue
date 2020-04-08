<template>
  <div class="home container-fluid">
    <!-- Search form -->
    <input class="form-control m-5" type="text" placeholder="Search" aria-label="Search">
    <div class="row">
      <div class="col-12 col-md-2" v-for="keep in getKeeps" :key="keep.id">
      <div class="card text-center" style="width: 15rem;">
        <img :src="keep.img" class="card-img-top" alt="...">
        <div class="card-body">
          <h5 class="card-title">{{keep.name}}</h5>
          <p class="card-text">{{keep.description}}</p>
          <a href="#" class="btn btn-primary">Go somewhere</a>
        </div>
      </div>
    </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "home",
  mounted(){
    this.$store.dispatch("getPublicKeeps");
    console.log(this.$store.state.publicKeeps)
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    getKeeps(){
      return this.$store.state.publicKeeps;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  }
};
</script>
