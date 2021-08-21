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
        focus: '2021-06-26T11:22:06'
      }
    },
    methods: {
      ...mapActions([
        'GetAllTermineByTimeRange'
      ]),
      createEvent(event) {
        console.log(event);
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
      const min = new Date('2012-12-17T00:00:00')
      const max = new Date('2022-12-17T00:00:00')
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
