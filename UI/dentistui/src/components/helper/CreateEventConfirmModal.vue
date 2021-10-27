<template>
  <div>
    <popup class="popup" modal-id="modal-add-event" title="Termin hinzufügen" :allow-ok="allowOk" @ok="ok" @cancel="cancel">
      <div class="addPatientPopup">
        <select-patient :select-patient-id="SelectPatientId" @selectedPatient="(v) => SelectPatientId = v"/>
        <select-arzt :select-arzt-id="SelectArztId" @selectedArzt="(v) => SelectArztId = v"/>
        <div v-if="data && !data.start">
          <div class="time">
            <b-form-input
              id="example-input"
              v-model="time"
              type="text"
              placeholder="HH:mm:ss"
            ></b-form-input>
            <b-input-group-append>
              <b-form-timepicker
                v-model="time"
                button-only
                right
                locale="ger"
                aria-controls="example-input"
              ></b-form-timepicker>
            </b-input-group-append>
          </div>
          <b-form-datepicker v-model="data.date" class="mb-2"></b-form-datepicker>
        </div>
      </div>
      <template v-slot:error>
        Patient und Arzt bitte auswählen.
      </template>
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
      SelectArztId: '',
      time: ''
    };
  },
  computed:{
    ...mapState([
      'patients'
    ]),
    selectedPatient(){
      return this.patients.find(x => x.id === this.SelectPatientId)
    },
    allowOk(){
      return !!this.SelectPatientId && !!this.SelectArztId
    }
  },
  methods:{
    ...mapActions([
      'addEvent',
      'GetAllTermineByTimeRange'
    ]),
    async ok() {
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
        terminDate: this.data.start || this.data.date + 'T' + this.time,
        status: 'ausstehend',
        Typ_short: 'AU'
      }

      const min =  new Date(new Date().setDate(0))
      const max = new Date(new Date(new Date().setDate(0)).setMonth(min.getMonth() + 1))

      this.addEvent(newEvent)
      .then(() =>
        this.GetAllTermineByTimeRange({
            startDate: min,
            endDate: max
        })
      );
    },
    cancel() {
      this.$emit('cancel')
      console.log("cancel")
    }
  },
  watch: {
    show(value){
      if(value){
        this.$bvModal.show('modal-add-event')
      }
      else{
        this.$bvModal.hide('modal-add-event')
      }

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
  width: 65%;
}
input{
  margin: 3px;
  border-style: hidden;
  border-bottom: 1px solid;
  border-radius: 0;
}
.time{
  display: flex;
  flex-direction: row;
    margin-bottom: 3px;
}
</style>
