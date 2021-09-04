<template>
  <div class="wartezimmer">
    <h4>Wartezimmer</h4>
    <div class="wartezimmergrid">
      <div v-for="kunde in kundenInWartezimmer" :key="kunde.id">
        <wartezimmer-card :infos="kunde" />
      </div>
    </div>
  </div>
</template>

<script>

import { mapGetters } from 'vuex'

import WartezimmerCard from './WartezimmerCard.vue'

export default {
  name: "Wartezimmer",
  components:{
    WartezimmerCard
  },
  data() {
    return {
    };
  },
  computed: {
    ...mapGetters([
      'kundenInWartezimmer',
    ])
  },
}
</script>

<style scoped>
.wartezimmer{

}
.wartezimmergrid{
  display: grid;
  grid-template-columns: 50% 50%;
  text-align: center;

}
</style>
