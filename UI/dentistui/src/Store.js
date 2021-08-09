import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

export default new Vuex.Store({
  namespaced: true,
  state: {
    count: 0,
    patients:[],
    selectedPatientId: null,
    termine:[],
    aerzte:[],
    behandlungsData:{}

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
    SetTerminStatusById(state, termin){
      state.termine.find(t => t.id == termin.Id).status = termin.Status
    },
    SetBehandlungsRaumById(state, termin){
      state.termine.find(t => t.id == termin.Id).raum = termin.Raum
    },
    setSelectedPatientId(state, id){
      state.selectedPatientId = id
    },
    setAllPatients(state, p){
      state.patients = p
    },
    setPatientToBehandlungsraum(state, behandlungsData){
      state.behandlungsData = behandlungsData
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
    async SetTerminStatusById(state, t){
      await axios
        .post('https://localhost:5001/setTerminStatusById',
          {Id: t.Id, Status: t.Status})
    },
    async SetTerminStatusUndBehandlungsRaumById(state, t){
      await axios
        .post('https://localhost:5001/setTerminStatusUndBehandlungsRaumById',
          {Id: t.Id, Status: t.Status, Raum: t.Raum})
    },
    async setTerminStatusToWartezimmer({ commit, dispatch },termin){
      var newTermin = {Id: termin.id, Status: 'wartezimmer'}
      dispatch('SetTerminStatusById', newTermin)
        .then(()=> commit('SetTerminStatusById', newTermin))
    },
    async setTerminStatusToInBehandlung({ commit, dispatch },termin){
      var newTermin = {Id: termin.id, Status: 'inBehandlung', Raum: termin.raum}
      dispatch('SetTerminStatusUndBehandlungsRaumById', newTermin)
        .then(()=> commit('SetTerminStatusById', newTermin))
        .then(()=> commit('SetBehandlungsRaumById', newTermin))
    },
    async setTerminStatusToAbgeschlossen({ commit, dispatch },termin){
      var newTermin = {Id: termin.id, Status: 'abgeschlossen'}
      dispatch('SetTerminStatusById', newTermin)
        .then(()=> commit('SetTerminStatusById', newTermin))
    },
    async loadAllPatients({ commit }) {
      commit('setAllPatients', await axios
        .get('https://localhost:5001/getAllUser')
        .then(response => {
          return response.data//.concat(response.data).concat(response.data).concat(response.data).concat(response.data)
        }))
    },
    async loadPatientsBehandlungsRaumMain({ commit }) {
      commit('setPatientToBehandlungsraum', await axios
        .get('https://localhost:5001/getBehandlungsRaumMain')
        .then(response => {
          return response.data.reduce((a,x) => ({...a, [x.userId]: {...x}}), {})
        }))
    },
    async addPatient(state, newPatient) {
      await axios
        .post('https://localhost:5001/addPatient', newPatient)
    },
    async removePatientById(state, patientId) {
      await axios
        .post(`https://localhost:5001/removePatientById/${patientId}`)
    }
  },
  getters:{
    kundenInWartezimmer: state => {
      return state.termine.filter(termin => termin.status === 'wartezimmer')
    },
    kundenInBehandlung: state => {
      return state.termine.filter(termin => termin.status === 'inBehandlung')
    },
    selectedPatient: state => {
      return state.patients.filter(p => p.id === state.selectedPatientId)[0]
    }
  }
})
