<template>
  <div>
    <hr />
    Ausgewählter Patient
    <hr />
    {{ selectedPatient }}
  </div>
</template>

<script>
import { mapGetters } from 'vuex'

export default {
  name: "SelectedPatientMain",
  data() {
    return {
    };
  },
  components: {
  },
  methods:{
  },
  mounted(){
  },
  computed: {
    ...mapGetters([
      'selectedPatient',
    ]),
  }
}
</script>

<style scoped>
</style>
