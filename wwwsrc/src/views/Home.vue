<template>
  <div class="home">
    <div v-for="keep in getKeeps" :key="keep.id">
      Hello World
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
