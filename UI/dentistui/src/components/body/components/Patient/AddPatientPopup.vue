<template>
  <div>
    <popup class="popup" modal-id="modal-add-patient" title="Patient hinzufügen" @ok="ok" @cancel="cancel">
      <div class="addPatientPopup">
        <input v-model="First_Name" placeholder="Vorname">
        <input v-model="Last_Name" placeholder="Nachname">
        <b-form-datepicker id="example-datepicker" v-model="picker" class="mb-2"></b-form-datepicker>
      </div>
    </popup>
  </div>
</template>

<script>
import { mapActions } from 'vuex'

import Popup from '@/components/popups/popup.vue'
export default {
  name: "AddPatientPopup",
  props:{
  },
  components: {
    Popup
  },
  data() {
    return {
      picker: (new Date(Date.now() - (new Date()).getTimezoneOffset() * 60000)).toISOString().substr(0, 10),
      First_Name: '',
      Last_Name: '',
    };
  },
  computed:{
  },
  methods:{
    ...mapActions([
      'addPatient'
    ]),
    ok() {
      var newPatient = { First_Name: this.First_Name, Last_Name: this.Last_Name, Birthday: this.picker}
      this.addPatient(newPatient);
    },
    cancel() {
      console.log("cancel")
    }
  }
}
</script>

<style scoped>
.addPatientPopup{
  display: flex;
  flex-direction: column;
}
.addPatientPopup > *{
  margin: 3px;
  border-style: hidden;
  border-bottom: 1px solid;
  width: 65%;
  border-radius: 0;
}
</style>
