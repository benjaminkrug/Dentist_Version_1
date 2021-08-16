<template>
  <div class="Fill">
    <h1 @click="chnageType">Terminvereinbarung</h1>
    <div>
      <calendar :type="type"/>
    </div>
  </div>
</template>

<script>
import { mapActions } from 'vuex'

import calendar from '@/components/helper/Calendar.vue'

export default {
  name: "Terminvereinbarung",
  components: {
    calendar
  },
  data() {
    return {
      type: 'month'
    }
  },
  methods: {
    ...mapActions([
      'GetAllTermineByTimeRange'
    ]),
    chnageType() {
      this.type= this.type!= 'month' ? 'month' : 'week'
    },
  },
  mounted() {
    const min = new Date('2012-12-17T00:00:00')
    const max = new Date('2022-12-17T00:00:00')
    this.GetAllTermineByTimeRange({
        startDate: min,
        endDate: max
    });
  }
}
</script>


<style scoped lang="scss">
</style>
