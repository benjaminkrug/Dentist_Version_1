import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

export default new Vuex.Store({
  namespaced: true,
  state: {
    count: 0,
    kunden:[],
    termine:[],
    aerzte:[],

  },
  mutations: {
    increment (state) {
      state.count++
    },
    setTermine(state, t){
      state.termine= t
    },
    setAerzte(state, t){
      state.aerzte= t
    },
    setTerminStatusToWartezimmer(state, termin){
      state.termine.find(t => t.id == termin.id).status = 'wartezimmer'
    },
    setTerminStatusToInBehandlung(state, termin){
      state.termine.find(t => t.id == termin.id).status = 'inBehandlung'
    },
    setTerminStatusToAbgeschlossen(state, termin){
      state.termine.find(t => t.id == termin.id).status = 'abgeschlossen'
    }
  },
  actions: {
    async loadAllTermine({ commit }) {
      commit('setTermine', await axios
        .get('https://localhost:5001/getAllTermine')
        .then(response => {
          return response.data.map(x => {
            return {...x, terminDate: new Date(x.terminDate), birthday: new Date(x.birthday)}
          })
        }))
    },
    async loadAllAerzte({ commit }) {
      commit('setAerzte', await axios
        .get('https://localhost:5001/getAllAerzte')
        .then(response => {
            return response.data
          }))
    },
    async setTerminStatusToWartezimmer({ commit },termin){
      await axios
        .post('https://localhost:5001/setTerminStatusById',
          {Id: termin.id, Status: 'wartezimmer'})
        .then(()=> commit('setTerminStatusToWartezimmer', termin))

    },
    setTerminStatusToInBehandlung({ commit },termin){
      commit('setTerminStatusToInBehandlung', termin)
    },
    setTerminStatusToAbgeschlossen({ commit },termin){
      commit('setTerminStatusToAbgeschlossen', termin)
    },
  },
  getters:{
    kundenInWartezimmer: state => {
      return state.termine.filter(termin => termin.status === 'wartezimmer')
    },
    kundenInBehandlung: state => {
      return state.termine.filter(termin => termin.status === 'inBehandlung')
    }
  }
})
