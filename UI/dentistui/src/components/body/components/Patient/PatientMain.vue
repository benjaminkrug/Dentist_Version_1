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
            <tr :class="selectedpatient == patient? 'selected-row' : ''" v-for="patient in shownPatients" :key="patient.Id" v-on:click="selectedpatient = patient">
              <td>{{ patient.first_Name }}</td>
              <td>{{ patient.last_Name }}</td>
              <td>{{ patient.birthday.split('T')[0] }}</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
    <div>
      <hr />
      Ausgewählter Patient
      <hr />
    </div>
  </div>
</template>

<script>
import SearchInput from '@/components/body/share/input/SearchInput.vue'

export default {
  name: "PatientMain",
  data() {
    return {
      allPatients:[],
      selectedpatient:{},
      searchText:''
    };
  },
  components: {
    SearchInput
  },
  methods:{
    async loadAllUser() {
      this.allPatients = await this.axios
        .get('https://localhost:5001/getAllUser')
        .then(response => {
          return response.data//.concat(response.data).concat(response.data).concat(response.data).concat(response.data)
        })
      }
  },
  mounted(){
    this.loadAllUser();
  },
  computed: {
    shownPatients(){
      return this.allPatients?.filter(patient => patient.first_Name.includes(this.searchText)) || []
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
