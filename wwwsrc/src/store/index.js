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
    async updateKeepPrivacy({ commit }, data){
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
    async setActiveVault({ commit }, data){
        commit("setActiveVault", data);
    },
    async toggleVaultStatus({ commit }, data){
      commit("toggleVaultStatus", data);
    },
    async CreateVaultKeep({ commit }, data){
      try {
        let res = await api.post(`vaultkeeps`, data);
        console.log(res.data)
        commit("addVaultKeep", res.data);
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
    }
  }
});
