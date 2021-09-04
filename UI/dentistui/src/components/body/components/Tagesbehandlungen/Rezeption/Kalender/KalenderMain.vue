<template>
  <div class="kalenderMain">
    <div class="headerKalender">
      <div @click="changeType(0)">
        Monat
      </div>
      <div @click="changeType(1)">
        Woche
      </div>
      <div @click="changeType(2)">
        Tag
      </div>
    </div>
    <kalender-day v-if="typeId == 3"/>
    <kalender-week-month v-else :type="type"/>
  </div>
</template>

<script>
import KalenderDay from './KalenderDay.vue'
import KalenderWeekMonth from './KalenderWeekMonth.vue'

export default {
  name:"KalenderMain",
  components: {
    KalenderDay,
    KalenderWeekMonth
  },
  data() {
    return {
      typeId:0,
      type: 'month'
    }
  },
  mounted() {
  },
  methods: {
    changeType(i) {
      this.typeId= i % 3;
      switch(this.typeId){
        case 0:
          this.type= 'month';
          break;
        case 1:
          this.type= 'week';
          break;
        default:
          this.type= 'day';
      }
      console.log(this.type)
    },
  },
  computed:{
  }
}
</script>

<style scoped>
.kalenderMain{
  height: 100%;
}
.headerKalender
{
  display: flex;
  align-items: stretch;
}
.headerKalender>div {
  flex: 1;
  height: 25px;
}
</style>
