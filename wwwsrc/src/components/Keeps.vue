<template>
  <div class="keeps text-center">
      <div class="creation-tools my-3">
      <button v-on:click="toggleCreate" type="button" class="btn btn-success" data-toggle="modal" data-target="#createKeepModal">Create</button><div></div>
      </div>
        <div class="row">
            <div class="col-12 col-md-3" v-for="keep in getKeeps" :key="keep.id">
                <keep :data="keep"/>
            </div>
        </div>

<!-- Modal -->

<div class="modal fade" id="createKeepModal" tabindex="-1" role="dialog" aria-labelledby="createKeepModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="">
        <h5 class="modal-title" id="createKeepModalLabel">New Keep</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
        <form class="m-3" @submit.prevent="CreateKeep">
          <div class="form-group">
            <input type="text" class="form-control" id="recipient-name" placeholder="Title/Name..." v-model="newKeep.Name">
          </div>
          <div class="form-group">
            <input type="text" class="form-control" id="recipient-name" placeholder="Image url..." v-model="newKeep.Img">
          </div>
          <div class="form-group">
            <textarea class="form-control" id="message-text" placeholder="Description..." v-model="newKeep.Description"></textarea>
          </div>
          <div class="form-group">
            Make Private <input type="checkbox" aria-label="Checkbox for following text input" v-model="newKeep.IsPrivate">
          </div>
      <div class="">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button
              type="submit"
              class="btn btn-success"
              data-toggle="modal"
              data-target="#createKeepModal"
            >Submit</button>
      </div>
        </form>
    </div>
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
  methods: {
      toggleCreate(){
          this.createToggled = true;
      },
      CreateKeep(){
          this.$store.dispatch()
      }
  },
  components: {
      Keep
  },
  data(){
      return {
          createToggled: false,
          newKeep: {
              Name: '',
              Description: '',
              Img: '',
              IsPrivate: ''
          }
      }
  }
};
</script>

<style>
.creation-tools{
    display: flex;
    justify-content: flex-start;
}
</style>