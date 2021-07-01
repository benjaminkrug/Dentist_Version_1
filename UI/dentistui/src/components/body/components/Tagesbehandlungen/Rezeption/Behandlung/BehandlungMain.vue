<template>
  <div class="behandlung">
    <h4>In Behandlung</h4>
    <div class="behandlunggrid">
      <div v-for="kunde in kundenInBehandlung" :key="kunde.id">
        <behandlung-card :infos="kunde" />
      </div>
    </div>
  </div>
</template>

<script>

import { mapGetters } from 'vuex'

import BehandlungCard from './BehandlungCard.vue'

export default {
  name: "Wartezimmer",
  components:{
    BehandlungCard
  },
  computed: {
    ...mapGetters([
      'kundenInBehandlung',
    ])
  },
}
</script>

<style scoped>
.behandlung{

}
.behandlunggrid{
  display: grid;
  grid-template-columns: 50% 50%;
  text-align: center;

}
</style>
