<template>
  <div class="TagesbehandlungenStyle">
    <router-view></router-view>
  </div>
</template>

<script>
import { mapActions } from 'vuex'
export default {
  mounted(){
    this.loadPatientsBehandlungsRaumMain();
  },
  methods:{
    ...mapActions([
      'loadPatientsBehandlungsRaumMain',
    ]),
  },
}
</script>

<style scoped>
.TagesbehandlungenStyle{
  width: 100%;
}
</style>
