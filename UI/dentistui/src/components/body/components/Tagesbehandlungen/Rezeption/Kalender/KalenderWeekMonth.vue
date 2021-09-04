  <template>
    <div class="Fill">
      <calendar :type="type" :eventss="events" :focus="focus" @createEvent="createEvent"/>
    </div>
  </template>

  <script>
  import { mapState, mapActions } from 'vuex'

  import calendar from '@/components/helper/Calendar.vue'

  export default {
    name: "KalenderWeekMonth",
    components: {
      calendar
    },
    props:{
      type: String,
    },
    data() {
      return {
        focus: '2021-09-04T11:22:06',
        arztColors: ['#2196F3', '#A356F6', '#91A6A3']
      }
    },
    methods: {
      ...mapActions([
        'GetAllTermineByTimeRange',
        'loadAllAerzte',
      ]),
      createEvent(event) {
        console.log(event);
      }
    },
    computed:{
      ...mapState([
        'termine',
        'aerzte'
      ]),
      events() {
        return this.termine.map(t => {
          var end = t.terminDate
          return {
            timed: true,
            start: t.terminDate.getTime(),
            end: end.setHours(t.terminDate.getHours() + 1),
            color: this.arztColors[this.aerzte.findIndex(a => a.id == t.arztId)],
            name:  t.first_Name[0] + '. ' + t.last_Name
          }
        })
      },
    },
    mounted() {
      const min =  new Date(new Date().setDate(0))
      const max = new Date(new Date(new Date().setDate(0)).setMonth(min.getMonth() + 1))
      this.loadAllAerzte()
      this.GetAllTermineByTimeRange({
          startDate: min,
          endDate: max
      });
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

  <style scoped>
  </style>
