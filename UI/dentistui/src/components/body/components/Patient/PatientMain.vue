<template>
  <div class="patient-main">
    <div class="patient-auswahl">
      <hr />
      Patientensuche
      <hr />
      <div class="patient-suche">
        <b-icon icon="plus-circle" variant="success" v-b-modal.modal-add-patient >
          <add-patient-popup />
        </b-icon>
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
              <td><b-icon icon="three-dots-vertical" :id="'popover-info' + patient.id" /></td>
              <b-popover class="popover" :target="'popover-info' + patient.id" triggers="hover">
                <b-icon icon="x-circle" @click="doDelete(patient.id)" />
              </b-popover>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
    <div>
      <selected-patient-main/>
    </div>
    <add-patient-popup />
    <confirm-modal
      ref="confirmDialogue"
      title="Patienten Löschen"
      text="Wollen sie den Patienten wirklich löschen?"
    />
  </div>
</template>

<script>
import { mapState, mapMutations, mapActions } from 'vuex'

import SearchInput from '@/components/body/share/input/SearchInput.vue'
import ConfirmModal from '@/components/helper/ConfirmModal.vue'
import AddPatientPopup from './AddPatientPopup.vue'
import SelectedPatientMain from './Selected/SelectedPatientMain.vue'

export default {
  name: "PatientMain",
  data() {
    return {
      searchText:'',
      modalShow: false,
    };
  },
  components: {
    SearchInput,
    ConfirmModal,
    SelectedPatientMain,
    AddPatientPopup
  },
  methods:{
    ...mapMutations([
      'setSelectedPatientId',
    ]),
    ...mapActions([
      'loadAllPatients',
      'removePatientById'
    ]),
    async doDelete(id) {
      const ok = await this.$refs.confirmDialogue.show();
      if (ok) {
        this.removePatientById(id)
      }
    }
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
  margin: 5px;
}
.selected-row{
  background-color: #e6e6de;
}
svg{
  margin-right: 5px;
}
.popover{
  display: flex;
  flex-direktion: column;
}
</style>
