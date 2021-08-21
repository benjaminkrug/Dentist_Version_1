<template>
  <div class="Fill">
    <h1 @click="chnageType">Terminvereinbarung</h1>
    <div>
      <calendar :type="type" :eventss="events" :focus="focus"/>
    </div>
  </div>
</template>

<script>
import { mapState, mapActions } from 'vuex'

import calendar from '@/components/helper/Calendar.vue'

export default {
  name: "Terminvereinbarung",
  components: {
    calendar
  },
  data() {
    return {
      type: 'month',
      focus: '2021-06-26T11:22:06'
    }
  },
  methods: {
    ...mapActions([
      'GetAllTermineByTimeRange'
    ]),
    chnageType() {
      this.type= this.type!= 'month' ? 'month' : 'week'
    },
    UpdateEvents(){
      const min = Date.now.setDate(0)
      const max = min.setMonth(min.getMonth+1)
      this.GetAllTermineByTimeRange({
          startDate: min,
          endDate: max
      });
    }
  },
  computed:{
    ...mapState([
      'termine',
    ]),
    events() {
      return this.termine.map(t => {
        return {
          timed: true,
          start: t.terminDate.getTime(),
          end: t.terminDate.getTime() + 15,
          color: "#2196F3",
          name: 'benni'
        }
      })
    }
  },
  mounted() {
    this.UpdateEvents();
    // this.events.push({
    //     timed: true,
    //     start: new Date('2021-08-12T00:04:00').getTime(),
    //     end: new Date('2021-08-12T00:05:00').getTime(),
    //     color: "#2196F3",
    //     name: 'benni'
    // })
  }
}
</script>


<style scoped lang="scss">
</style>
