<template>
  <div class="select-patient">
    <v-select
      v-model="selected"
      :items="patientItems"
      item-text="text"
      item-value="id"
      :menu-props="{ top: true, offsetY: true }"
      label="Patienten"
    ></v-select>
  </div>
</template>

<script>
import { mapState, mapActions } from 'vuex'

export default {
  name: "SelectPatient",
  props:{
    SelectPatientId: String
  },
  components: {
  },
  data() {
    return {
      items: ['Foo', 'Bar', 'Fizz', 'Buzz'],
    };
  },
  computed:{
    ...mapState([
      'patients'
    ]),
    selected: {
      get() {
        return this.SelectPatientId
      },
      set(v) {
        this.$emit('selectedPatient', v)
      }
    },
    patientItems() {
      return this.patients.map(p => {return {id: p.id, text: p.last_Name + ' '+ p.first_Name}});
    }
  },
  methods:{
    ...mapActions([
      'loadAllPatients',
    ]),
  },
  watch: {
  },
  mounted() {
    this.loadAllPatients()
  }
}
</script>

<style scoped>
</style>
