<template>
  <div>
    <div v-if="headerlist.length > 0" class="sheduler">
      <div class="header">
        <div>
        </div>
        <div>
        </div>
        <div v-for="name in headerlist" :key="name" >
          {{ name }}
        </div>
      </div>
      <div v-for="hour in list" :key="hour.hour">
        <div class="card" v-for="mins in hour.mins" :key="mins.mins">
          <div>
            {{hour.hour}}.{{mins.min}}
          </div>
          <div>
            |
          </div>
          <div v-for="header in headerlist" :key="header">
            <div v-for="task in mins.groupedTasks[header]" :key="task.last_Name">
              <KalenderCard :infos="task" />
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>

import KalenderCard from './KalenderCard.vue'

export default {
  name:"KalenderMain",
  components: {
    KalenderCard
  },
  data() {
    return {
      list: [],
      aerzte: [],
      termine: []
    }
  },

  mounted() {
    this.loadAllAerzte();
    this.loadAllTermine()
    .then(() => {
        const startHour = 9
        const closeHour = 18
        const cardsPerHour = 3
        for (var h = startHour; h <= closeHour; h++) {
          const minList = []
          for (var m = 0; m < cardsPerHour; m++){
            var stamp = m * (60 / cardsPerHour)
            const tasks = this.termine.filter(task =>
              task.terminDate.getHours() == h
              && task.terminDate.getMinutes() > stamp
              && task.terminDate.getMinutes() <= stamp + (60 / cardsPerHour))
            var groupedTasks = {}
            if(tasks.length > 0){

              groupedTasks = tasks.reduce((acc, value) => {
              if (!acc[value.arzt]) {
                acc[value.arzt] = [];
              }
              // Grouping
              acc[value.arzt].push(value);
              return acc;
            }, {})
            }
            minList.push({min:stamp == 0 ? '00' : stamp, groupedTasks})
          }
          this.list.push({hour: h, mins:minList})
        }
    });
  },
  methods: {
    async loadAllTermine() {
      this.termine = await this.axios
        .get('https://localhost:5001/getAllTermine')
        .then(response => {
          return response.data.map(x => {
            return {...x, terminDate: new Date(x.terminDate), birthday: new Date(x.birthday)}
          })
        })
    },
    async loadAllAerzte() {
      this.aerzte = await this.axios
        .get('https://localhost:5001/getAllAerzte')
        .then(response => {
            return response.data
          })
    }
  },
  computed:{
    headerlist(){
      return this.aerzte.map(x => x.last_Name)
    }
  }
}
</script>

<style scoped>
.sheduler{
 margin: 5px;
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
