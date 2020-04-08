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
    userKeeps: []
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
    }
  }
});
