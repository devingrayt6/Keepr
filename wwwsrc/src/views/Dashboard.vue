<template>
  <div class="dashboard">
    <h1>WELCOME TO THE DASHBOARD</h1>
    public {{ publicKeeps }} user {{ userKeeps }}
  </div>
</template>

<script>
export default {
  mounted() {
    this.$store.dispatch("getVaults");
    console.log("this is the vaults")
    console.log(this.$store.state.vaults)
  },
  computed: {}
};
</script>

<style></style>
