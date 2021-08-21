<template>
  <div>
    <popup class="popup" modal-id="modal-add-event" title="Patient hinzufügen" @ok="ok" @cancel="cancel" :show="show">
      <div class="addPatientPopup">
        <input v-model="First_Name" placeholder="Vorname">
        <input v-model="Last_Name" placeholder="Nachname">
      </div>
    </popup>
  </div>
</template>

<script>
import { mapActions } from 'vuex'

import Popup from '@/components/popups/popup.vue'
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
    }
  },
  components: {
    Popup
  },
  data() {
    return {
      First_Name: '',
      Last_Name: '',
    };
  },
  computed:{
  },
  methods:{
    ...mapActions([
      'addEvent'
    ]),
    ok() {
      this.$emit('ok')
      var date = new Date(Date.now());
      var newEvent = {
        First_Name: '',
        Last_Name: '',
        // name: `Event #${this.events.length}`,
        // color: this.rndElement(this.colors),
        // start: this.createStart,
        // end: this.createStart,
        datum: date,
        time: '11:12:04',
        type: 'AU'
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
  height: 100px;
}
.addPatientPopup > *{
  margin: 3px;
  border-style: hidden;
  border-bottom: 1px solid;
  width: 65%;
  border-radius: 0;
}
</style>
