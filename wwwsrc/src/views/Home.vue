<template>
  <div class="home container-fluid text-center">
    <!-- Search form -->
    <input class="form-control m-5" type="text" placeholder="Search" aria-label="Search">
    <div class="row">
      <div class="col-12 col-md-2" v-for="keep in getKeeps" :key="keep.id">
        <public-keep :data="keep"/>
      </div>
    </div>
  </div>
</template>

<script>
import PublicKeep from '../components/publicKeep';

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
  },
  components:{
    PublicKeep
  }
};
</script>
