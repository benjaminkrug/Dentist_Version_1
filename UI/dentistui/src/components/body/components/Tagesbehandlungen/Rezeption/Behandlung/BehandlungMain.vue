<template>
  <div class="behandlung">
    <h4>In Behandlung</h4>
    <div v-for="kunde in kundenInBehandlung" :key="kunde.id">
      <behandlung-card :infos="kunde" />
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
</style>
