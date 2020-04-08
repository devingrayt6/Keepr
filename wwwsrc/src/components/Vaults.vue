<template>
  <div class="vaults container-fluid text-center">
    <div class="row">
      <div class="col-12 col-md-3 my-3 mx-3" v-for="vault in getVaults" :key="vault.id">
      <div class="card text-center" style="width: 18rem;">
        <!-- <img :src="keep.img" class="card-img-top" alt="..."> -->
        <div class="card-body">
          <h5 class="card-title">{{vault.name}}</h5>
          <p class="card-text">{{vault.description}}</p>
          <a href="#" class="btn btn-primary">Go somewhere</a>
        </div>
      </div>
    </div>
    </div>
  </div>
</template>

<script>
export default {
  mounted() {
    this.$store.dispatch("getVaults");
  },
  computed: {
    getVaults(){
      return this.$store.state.vaults;
    }
  }
};
</script>

<style>
  .toggle-view{
    display: flex;
    justify-content: flex-end;
  }
</style>