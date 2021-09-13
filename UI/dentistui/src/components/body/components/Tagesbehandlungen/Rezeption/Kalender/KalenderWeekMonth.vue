  <template>
    <div class="Fill" v-if="focus!=''">
      <calendar ref="calendar" :type="type" :eventss="events" :focus="focus" @createEvent="createEvent"/>
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
        focus: '',
        arztColors: ['#004E14', '#A356F6', '#91A6A3']
      }
    },
    methods: {
      ...mapActions([
        'GetAllTermineByTimeRange',
        'loadAllAerzte',
      ]),
      createEvent(event) {
        console.log(event);
      },
      prev () {
        this.$refs.calendar.prev()
      },
      next () {
        this.$refs.calendar.next()
      },
    },
    computed:{
      ...mapState([
        'termine',
        'aerzte'
      ]),
      events() {
        return this.termine.map(t => {
          return {
            timed: true,
            start: t.terminDate.getTime(),
            end: t.terminDate.getTime() + 2000000,
            color: this.arztColors[this.aerzte.findIndex(a => a.id == t.arztId)],
            name:  t.first_Name[0] + '. ' + t.last_Name
          }
        })
      },
    },
    mounted() {
      var date = new Date();
      var dateStr =
        ("00" + (date.getMonth() + 1)).slice(-2) + "/" +
        ("00" + date.getDate()).slice(-2) + "/" +
        date.getFullYear() + " " +
        ("00" + date.getHours()).slice(-2) + ":" +
        ("00" + date.getMinutes()).slice(-2) + ":" +
        ("00" + date.getSeconds()).slice(-2);
      this.focus = dateStr
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
