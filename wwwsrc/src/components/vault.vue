<template>
  <div class="card text-center" style="width: 18rem;">
      <!-- <img :src="keep.img" class="card-img-top" alt="..."> -->
      <div class="card-body">
        <h5 class="card-title">{{data.name}}</h5>
        <p class="card-text">{{data.description}}</p>
        <button href="#" class="btn btn-primary" v-on:click="setActiveVault">Open Vault</button>
      </div>
    </div>
</template>

<script>
export default {
    props:['data'],
    methods:{
        setActiveVault(){
            this.$store.dispatch("setActiveVault", this.data);
            this.$store.dispatch("toggleVaultStatus", {isVaultOpen:true});
            this.$store.dispatch("GetKeepsByVaultId", {vaultId:this.data.id});
        }
    }
}
</script>

<style>

</style>