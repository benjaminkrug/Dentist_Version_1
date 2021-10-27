<template>
  <div>
    <h3>Behandlungsraum Frei</h3>
    <div class="FreeRoom">
      <div>
        <select-patient class="patient" :select-patient-id="SelectPatientId" @selectedPatient="(v) => SelectPatientId = v" />
        <select-arzt class="patient" :select-arzt-id="SelectArztId" @selectedArzt="(v) => SelectArztId = v" />
      </div>
      <div v-if="propsSelected" class="propsSelected" >
        <button @click="belegeRaum"> Raum Belegen</button>
      </div>
    </div>
  </div>
</template>

<script>
import { mapState, mapActions } from 'vuex'

import SelectPatient from '@/components/body/share/selects/SelectPatient.vue'
import SelectArzt from '@/components/body/share/selects/SelectArzt.vue'

export default {
  name: "RaumBelegen",
  components: {
    SelectPatient,
    SelectArzt
  },
  props:{
  },
  data() {
    return {
      SelectPatientId: '',
      SelectArztId: '',
    };
  },
  computed: {
    ...mapState([
      'patients',
      'aerzte'
    ]),
    propsSelected () {
      return this.SelectPatientId != '' && this.SelectArztId != ''
    },
    selectedPatient(){
      return this.patients.filter(p => p.id === this.SelectPatientId)[0]
    },
    selectedArzt(){
      return this.aerzte.filter(a => a.id === this.SelectArztId)[0]
    }
  },
  methods: {
    ...mapActions([
      'addEvent',
    ]),
    async belegeRaum() {
      var date = new Date();
      var terminDate = (date.getFullYear()) + "-" +
        ("00" + date.getDate()).slice(-2) + "-" +
        ("00" + (date.getMonth() + 1)).slice(-2) + "T" +
        ("00" + date.getHours()).slice(-2) + ":" +
        ("00" + date.getMinutes()).slice(-2) + ":" +
        ("00" + date.getSeconds()).slice(-2) + ".000Z";

      var newEvent = {
        First_Name: this.selectedPatient.first_Name,
        Last_Name: this.selectedPatient.last_Name,
        UserId: this.SelectPatientId,
        ArztId: this.SelectArztId,

        // name: `Event #${this.events.length}`,
        // color: this.rndElement(this.colors),
        // start: this.createStart,
        // end: this.createStart,
        terminDate: terminDate,
        status: 'ausstehend',
        Typ_short: 'AU'
      }

      this.addEvent(newEvent)
    }
  }
}
</script>

<style scoped>
.patient {
  width: 40%;
  margin-left: 10%;
}
.FreeRoom{
  display: grid;
  grid-template-columns: 50% 50%;
}
.propsSelected{
  margin-top: 5%;
}
</style>
