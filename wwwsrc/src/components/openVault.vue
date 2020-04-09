<template>
  <div class="container-fluid">
      <div class="return-button">
          <i class="fas fa-arrow-left my-3 cursor-pointer" v-on:click="returnToDash"></i>
      </div>
      <div class="row">
        <div class="col-12 col-md-3" v-for="keep in VaultKeeps" :key="keep.id">
            <public-keep :data="keep" :inVault="true" :vaultData="ActiveVault"/>
        </div>
      </div>
  </div>
</template>

<script>
import PublicKeep from './publicKeep';

export default {
    computed:{
        VaultKeeps(){
            return this.$store.state.currentVaultKeeps;
        },
        ActiveVault(){
            return this.$store.state.activeVault;
        }
    },
    methods:{
        returnToDash(){
            this.$store.dispatch("toggleVaultStatus", {isVaultOpen:false});
        }
    },
    components:{
        PublicKeep
    },
    props:['vault']
}
</script>

<style>
    .return-button{
        display: flex;
        justify-content: flex-start;
        color: rgb(109, 179, 172)
    }
    .cursor-pointer{
        cursor: pointer;
    }
</style>