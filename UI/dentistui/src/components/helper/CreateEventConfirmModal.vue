<template>
  <div>
    <popup class="popup" modal-id="modal-add-event" title="Termin hinzufügen" @ok="ok" @cancel="cancel" :show="show">
      <div class="addPatientPopup">
        <select-patient :select-patient-id="SelectPatientId" @selectedPatient="(v) => SelectPatientId = v"/>
        <select-arzt :select-arzt-id="SelectArztId" @selectedArzt="(v) => SelectArztId = v"/>
      </div>
    </popup>
  </div>
</template>

<script>
import { mapState, mapActions } from 'vuex'

import Popup from '@/components/popups/popup.vue'
import SelectPatient from '@/components/body/share/selects/SelectPatient.vue'
import SelectArzt from '@/components/body/share/selects/SelectArzt.vue'

export default {
  name: "CreateEvemtConfirmModal",
  props:{
    data: {
      type: Object,
      default: null
    },
    show:{
      type: Boolean,
      default: false
    },

  },
  components: {
    Popup,
    SelectPatient,
    SelectArzt
  },
  data() {
    return {
      First_Name: '',
      Last_Name: '',
      SelectPatientId: '',
      SelectArztId: ''
    };
  },
  computed:{
    ...mapState([
      'patients'
    ]),
    selectedPatient(){
      return this.patients.find(x => x.id === this.SelectPatientId)
    }
  },
  methods:{
    ...mapActions([
      'addEvent'
    ]),
    ok() {
      this.$emit('ok')
      var newEvent = {
        First_Name: this.selectedPatient.first_Name,
        Last_Name: this.selectedPatient.last_Name,
        UserId: this.SelectPatientId,
        ArztId: this.SelectArztId,

        // name: `Event #${this.events.length}`,
        // color: this.rndElement(this.colors),
        // start: this.createStart,
        // end: this.createStart,
        terminDate: this.data.start,
        status: 'ausstehend',
        Typ_short: 'AU',
        time: '11:12:04',
      }
      this.addEvent(newEvent);
    },
    cancel() {
      this.$emit('cancel')
      console.log("cancel")
    }
  },
  watch: {
  }
}
</script>

<style scoped>
.addPatientPopup{
  display: flex;
  flex-direction: column;
}
.addPatientPopup > *{
  width: 65%;
}
input{
  margin: 3px;
  border-style: hidden;
  border-bottom: 1px solid;
  border-radius: 0;
}
</style>
