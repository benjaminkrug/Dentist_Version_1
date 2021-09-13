<template>
  <div class="Fill">
    <div class="PatientHeader">{{patient.last_name}} {{patient.first_name[0]}}.</div>
    <b-dropdown class="RaumSelection" href="/Tagesbehandlungen/Behandlungsraum">
      <template #button-content>
        Raum wechseln
      </template>
      <b-dropdown-item @click="raumId = 1">Raum 1</b-dropdown-item>
      <b-dropdown-item @click="raumId = 2">Raum 2</b-dropdown-item>
    </b-dropdown>
    <h1>Behandlungsraum: {{ raumId }}</h1>
    <div v-if="raumData != null" class="behandlungsraumStyle">
      <zaehne-main :zahn-list-fuellung="zahnListFuellung" :gebiss="gebiss"/>
    </div>
    <div v-else>
      <select-patient />
    </div>
    {{ zahnListFuellung }}
  </div>
</template>

<script>
import { mapState, mapGetters, mapActions } from 'vuex'

import ZaehneMain from './Zaehne/ZaehneMain.vue'
import SelectPatient from './SelectPatient.vue'
export default {
  name: "Behandlungsraum",
  components: {
    ZaehneMain,
    SelectPatient
  },
  data() {
    return {
      patient:{
        first_name: 'Benjamin',
        last_name: 'Krug'
      },
      raumData: null,
      raumId: 1,
    }
  },
  mounted(){
    //this.loadPatientsBehandlungsRaumMain();
  },
  methods:{
    ...mapActions([
      'loadPatientsBehandlungsRaumMain',
    ]),
  },
  computed: {
    ...mapState([
      'behandlungsData',
    ]),
    ...mapGetters([
    ]),
    behandlungsraumData() {
      return Object.values(this.behandlungsData).filter(x => x.raum === this.raumId) || null
    },
    zahnList() {
      return this.behandlungsraumData
    },
    gebissList() {
      return this.behandlungsraumData.gebiss
    },
    zahnListFuellung() {
      return this.raumData?.zahnList.filter(x => x.type === 'fuellung') || []
    },
    gebiss() {
      return this.raumData?.gebiss || {}
    }
  },
  watch: {
    raumId(val) {
      this.loadPatientsBehandlungsRaumMain(val);
    },
    behandlungsraumData() {
      if(this.behandlungsraumData && this.behandlungsraumData.length === 1){
        this.raumData = this.behandlungsraumData[0];
      }
      else {
        this.raumData = null;
      }
    }
  }
}
</script>

<style scoped>
.Fill{
  width: 100%;
  height: 100vh;
}
.RaumSelection{
  position: fixed;
  left: 30px;
  margin: 4px;
  z-index: 10;
}
.PatientHeader{
  position: fixed;
  right: 30px;
  margin: 4px;
  z-index: 10;
}
.behandlungsraumStyle{
  display: flex;
  margin: 10px;
}
</style>
