import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    publicKeeps: [],
    vaults: [],
    activeVault: {},
    isVaultOpen: false,
    userKeeps: [],
    vaultKeeps: [],
    currentVaultKeeps: []
  },
  mutations: {
    setPublicKeeps(state, data){
      state.publicKeeps = data;
    },
    setVaults(state, data){
      state.vaults = data;
    },
    setUserKeeps(state, data){
      state.userKeeps = data;
    },
    updateKeep(state, data){
      let userkeep = state.userKeeps.filter(k => k.id != data.id);
      let publickeep = state.publicKeeps.filter(k => k.id != data.id);
      publickeep.push(data);
      userkeep.push(data);
      console.log(state.userKeeps)
    },
    createKeep(state, data){
      state.publicKeeps.push(data);
      state.userKeeps.push(data);
    },
    createVault(state, data){
      state.vaults.push(data);
    },
    deleteKeep(state, data){
      let newKeeps = state.userKeeps.filter(k => k.id != data.id);
      state.userKeeps = newKeeps;
    },
    deleteVault(state, id){
      let newVaults = state.vaults.filter(v => v.id != id);
      state.vaults = newVaults;
    },
    setActiveVault(state, data){
      state.activeVault = data;
      console.log(state.activeVault)
    },
    toggleVaultStatus(state, data){
      state.isVaultOpen = data.isVaultOpen;
    },
    addVaultKeep(state, data){
      state.vaultKeeps.push(data);
    },
    setCurrentVaultKeeps(state, data){
      state.currentVaultKeeps = data;
    },
    setVaultKeeps(state, data){
      state.vaultKeeps = data;
      console.log(state.vaultKeeps)
    },
    removeFromVault(state,data){
      let newVaultKeeps = state.vaultKeeps.filter(vk => vk.id != data.id);
      state.vaultKeeps = newVaultKeeps;
      let newCurrentVaultKeeps = state.currentVaultKeeps.filter(k => k.id != data.keepId);
      state.currentVaultKeeps = newCurrentVaultKeeps;
    }
  },
  actions: {
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    async getPublicKeeps({ commit }) {
      try {
        let res = await api.get("keeps");
        commit("setPublicKeeps", res.data);
      } catch (error) {
        console.error(error)
      }
    },
    async getUserKeeps({ commit }) {
      try {
        let res = await api.get("keeps/mykeeps")
        commit("setUserKeeps", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async getVaults({ commit }){
     try {
      let res = await api.get("vaults");
      commit("setVaults", res.data);
     } catch (error) {
       console.error(error);
     }
    },
    async updateKeep({ commit }, data){
      try {
        let res = await api.put(`keeps/${data.id}`, data);
        commit("updateKeep", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async CreateKeep({ commit }, keep){
      try {
        let res = await api.post(`keeps`, keep);
        commit("createKeep", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async CreateVault({ commit }, vault){
      try {
        let res = await api.post(`vaults`, vault);
        commit("createVault", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async DeleteKeep({ commit }, data){
      try {
        let res = await api.delete(`keeps/${data.id}`);
        commit("deleteKeep", data);
      } catch (error) {
        console.error(error);
      }
    },
    async DeleteVault({ commit }, id){
      try {
        let res = await api.delete(`vaults/${id}`);
        commit("deleteVault", id);
      } catch (error) {
        console.error(error);
      }
    },
    async setActiveVault({ commit }, data){
        commit("setActiveVault", data);
    },
    async toggleVaultStatus({ commit }, data){
      commit("toggleVaultStatus", data);
    },
    async CreateVaultKeep({ commit }, data){
      try {
        let exists = this.state.currentVaultKeeps.find(k => k.id == data.newKeep.id);

        if(!exists){
          let res = await api.post(`vaultkeeps`, data.vaultKeep);
          commit("addVaultKeep", res.data);
          this.dispatch("updateKeep", data.newKeep)
        }
      } catch (error) {
        console.error(error);
      }
    },
    async GetKeepsByVaultId({ commit }, data){
      try {
        let res = await api.get(`vaults/${data.vaultId}/keeps`);
        commit("setCurrentVaultKeeps", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async GetVaultKeeps({ commit }, data){
      try {
        let res = await api.get(`vaultkeeps`);
        commit("setVaultKeeps", res.data);
      } catch (error) {
        
      }
    },
    async RemoveFromVault({ commit }, data){
      try {
        let vaultKeep = this.state.vaultKeeps.find(v => v.vaultId == data.vaultId && v.keepId == data.keepId);
        console.log(vaultKeep)
        let res = await api.delete(`vaultkeeps/${vaultKeep.id}`);
        commit("removeFromVault", vaultKeep)
      } catch (error) {
        
      }
    }
  }
});
