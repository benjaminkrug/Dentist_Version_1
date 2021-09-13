<template>
  <div>
    <popup class="popup" :modal-id="id" title="Termin hinzufügen" @ok="$emit('close')" @cancel="$emit('close')" :show="show" >
      <div class="addPatientPopup">
        <h3>Behandlungsraum Frei</h3>
      </div>
    </popup>
    hi
  </div>
</template>

<script>

import Popup from '@/components/popups/popup.vue'
export default {
  name: "BehandlungSelector",
  components: {
    Popup
  },
  props:{
    data: {}
  },
  data() {
    return {
      show: true,
    };
  },
  computed: {
    id(){
      return 'modal-' + this.data.part + '-' + this.data.position;
    }
  },
  methods: {
  }
}
</script>

<style scoped>
.popup{
}
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
