<template>
  <div class="patient-main">
    <div class="patient-suche">
      <hr />
      Patientensuche
      <hr />
      <div>
        <Search-input :search-text="searchText" @search="(value) =>searchText = value"/>
      </div>
      <div class="patient-table">
        <table class="table-sm table-hover">
          <thead>
            <tr>
              <th scope="col">Vorname</th>
              <th scope="col">Nachname</th>
              <th scope="col">Geburtstag</th>
            </tr>
          </thead>
          <tbody>
            <tr :class="selectedPatientId == patient.id? 'selected-row' : ''" v-for="patient in shownPatients" :key="patient.id" v-on:click="setSelectedPatientId(patient.id)">
              <td>{{ patient.first_Name }}</td>
              <td>{{ patient.last_Name }}</td>
              <td>{{ patient.birthday.split('T')[0] }}</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
    <div>
      <selected-patient-main/>
    </div>
  </div>
</template>

<script>
import { mapState, mapMutations, mapActions } from 'vuex'

import SearchInput from '@/components/body/share/input/SearchInput.vue'
import SelectedPatientMain from './Selected/SelectedPatientMain.vue'

export default {
  name: "PatientMain",
  data() {
    return {
      searchText:''
    };
  },
  components: {
    SearchInput,
    SelectedPatientMain
  },
  methods:{
    ...mapMutations([
      'setSelectedPatientId',
    ]),
    ...mapActions([
      'loadAllPatients',
    ]),
  },
  mounted(){
    this.loadAllPatients();
  },
  computed: {
    ...mapState([
      'selectedPatientId',
      'patients'
    ]),
    shownPatients(){
      return this.patients?.filter(patient => patient.first_Name.includes(this.searchText)) || []
    }
  }
}
</script>

<style scoped>
.patient-main{
  display: grid;
  grid-template-columns:40% 60%;
}
table{
  margin: auto;
}
.patient-table{
  height: 65%;
  overflow-y: auto;
}
.patient-suche{
}
.selected-row{
  background-color: #e6e6de;
}
</style>
