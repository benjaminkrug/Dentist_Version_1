<template>
  <div v-if="headerlist.length > 0" class="sheduler">
    <div class="header">
      <div>
      </div>
      <div>
      </div>
      <div v-for="(name, i) in headerlist" :key="name + i" >
        {{ name }}
      </div>
    </div>
    <div v-for="hour in list" :key="hour.hour">
      <div
        class="card"
        v-for="mins in hour.mins"
        :key="mins.min"
      >
        <div
          :style="aktuellHour == hour.hour && aktuellMinuteMin == mins.min? 'background-color: grey;' : ''"
        >
          {{hour.hour}}.{{mins.min}}
        </div>
        <div>
          |
        </div>
        <div v-for="(header, i) in headerlist" :key="header +  i">
          <div v-for="(task, i) in mins.groupedTasks[header]" :key="task.last_Name + i">
            <KalenderCard :infos="task" />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>

import { mapState, mapActions } from 'vuex'

import KalenderCard from './KalenderCard.vue'

export default {
  name:"KalenderDay",
  components: {
    KalenderCard
  },
  data() {
    return {
      list: [],
      cardsPerHour: 3,
      now: 0
    }
  },

  mounted() {
    this.loadAllAerzte();
    this.loadAllTermine()
    .then(() => {
        const startHour = 9
        const closeHour = 18
        for (var h = startHour; h <= closeHour; h++) {
          const minList = []
          for (var m = 0; m < this.cardsPerHour; m++){
            var stamp = m * (60 / this.cardsPerHour)
            const tasks = this.termine.filter(task =>
              task.terminDate.getHours() == h
              && task.terminDate.getMinutes() > stamp
              && task.terminDate.getMinutes() <= stamp + (60 / this.cardsPerHour))
            var groupedTasks = {}
            if(tasks.length > 0){

              groupedTasks = tasks.reduce((acc, value) => {
              if (!acc[value.arzt_Last_Name]) {
                acc[value.arzt_Last_Name] = [];
              }
              // Grouping
              acc[value.arzt_Last_Name].push(value);
              return acc;
            }, {})
            }
            minList.push({min:stamp == 0 ? '00' : stamp, groupedTasks})
          }
          this.list.push({hour: h, mins:minList})
        }
    })
    setInterval(this.updateNow.bind(this),1000);
  },
  methods: {
    ...mapActions([
      'loadAllTermine',
      'loadAllAerzte',
    ]),
    updateNow() {
      this.now = new Date().getMinutes()
    }
  },
  computed:{
    ...mapState([
      'termine',
      'aerzte'
    ]),
    headerlist(){
      return this.aerzte.map(x => x.last_Name)
    },
    aktuellHour() {
      return new Date().getHours();
    },
    aktuellMinute() {
      return new Date().getMinutes();
    },
    aktuellMinuteMin() {
      for(var x = 0; x <= this.cardsPerHour; x++){
        if(x * (60 / this.cardsPerHour) > this.now){
          return x* (60 / this.cardsPerHour)- (60 / this.cardsPerHour);
        }
      }
      return x* (60 / this.cardsPerHour) - (60 / this.cardsPerHour);
    }
  }
}
</script>

<style scoped>
.sheduler{
  overflow-y: auto;
  height: 97%;
}
.card{
  text-align: left;
  display: grid;
  grid-template-columns: 10% 1% repeat(2, 1fr);
  text-align: center;


}
.header{
  display: grid;
  grid-template-columns: 10% 1% repeat(2, 1fr);
}
</style>
