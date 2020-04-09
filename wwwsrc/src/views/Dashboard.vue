<template v-if="this.$store.state.userKeeps">
  <div class="dashboard container-fluid text-center">
    <h1 class="m-2">My DASHBOARD</h1>
    <div class="toggle-view">
      <button v-on:click="toggleVaults()" class="btn btn-primary vault-view m-1">Vaults</button>
      <button v-on:click="toggleKeeps()" class="btn btn-secondary keep-view m-1">Keeps</button>
    </div>
    <vaults v-show="this.toggledVaults"/>
    <keeps v-show="this.toggledKeeps" />
  </div>
</template>

<script>
import Vaults from '../components/Vaults';
import Keeps from '../components/Keeps';

export default {
  mounted() {
    this.$store.dispatch("getUserKeeps");
    this.$store.dispatch("getVaults");
  },
  computed: {},
  components: {
    Vaults,
    Keeps
  },
  data(){
    return {
      toggledVaults: false,
      toggledKeeps: true
    }
  },
  methods:{
    toggleVaults(){
      this.toggledKeeps = false;
      this.toggledVaults = true;
    },
    toggleKeeps(){
      this.toggledKeeps = true;
      this.toggledVaults = false;
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
