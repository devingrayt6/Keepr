<template>
  <div class="vaults text-center">

    <div class="vaultisclosed" v-show="isVaultOpen==false">
      <div class="creation-tools">
      <button type="button" class="btn btn-success" data-toggle="modal" data-target="#createVaultModal">Create</button>
      </div>    
      <div class="row">
          <div class="col-12 col-md-3 my-3 mx-3" v-for="vault in getVaults" :key="vault.id">
          <vault :data="vault" />
        </div>
      </div>

      <!-- Modal -->
      <div class="modal fade" id="createVaultModal" tabindex="-1" role="dialog" aria-labelledby="createVaultModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="">
              <h5 class="modal-title" id="createVaultModalLabel">New Vault</h5>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
              <form class="m-3" @submit.prevent="CreateVault">
                <div class="form-group">
                  <input type="text" class="form-control" id="recipient-name" placeholder="Title/Name..." v-model="newVault.Name">
                </div>
                <div class="form-group">
                  <textarea class="form-control" id="message-text" placeholder="Description..." v-model="newVault.Description"></textarea>
                </div>
            <div class="">
              <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
              <button
                    type="submit"
                    class="btn btn-success"
                    data-toggle="modal"
                    data-target="#createVaultModal"
                  >Submit</button>
            </div>
              </form>
          </div>
        </div>
      </div>
    </div>

    <div class="vaultisopen" v-show="isVaultOpen==true">
      <open-vault />
    </div>
  </div>
</template>

<script>
import Vault from './vault';
import OpenVault from './openVault';

export default {
  mounted() {
    this.$store.dispatch("getVaults");
  },
  computed: {
    getVaults(){
      return this.$store.state.vaults;
    },
    isVaultOpen(){
      return this.$store.state.isVaultOpen;
    }
  },
  methods:{
    CreateVault(){
      this.$store.dispatch("CreateVault", this.newVault)
    }
  },
  data(){
    return{
      newVault:{
        Name: '',
        Description: ''
      }
    }
  },
  components:{
    Vault,
    OpenVault
  }
};
</script>

<style>
  .toggle-view{
    display: flex;
    justify-content: flex-end;
  }
  .creation-tools{
    display: flex;
    justify-content: flex-start;
  }
</style>