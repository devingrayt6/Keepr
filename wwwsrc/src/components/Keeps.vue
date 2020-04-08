<template>
  <div class="keeps text-center">
        <div class="row">
            <div class="col-12 col-md-3" v-for="keep in getKeeps" :key="keep.id">
                <keep :data="keep"/>
            </div>
        </div>
  </div>
</template>

<script>
import Keep from './keep';

export default {
  mounted() {
    this.$store.dispatch("getUserKeeps");
  },
  computed: {
    getKeeps(){
      return this.$store.state.userKeeps;
    }
  },
  components: {
      Keep
  }
};
</script>

<style>
</style>