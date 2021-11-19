  <template>
    <div v-if="focus!=''">
      <div class="WeekMonth" >
        <div class="WeekMonth"  v-for="a in colorByAerzte" :key="a.arztName" >
          <div class="StatusColor" :style="'background-color:' + a.color" >
          </div>
          {{ a.arztName }}
        </div>
      </div>
      <calendar ref="calendar" :type="type" :eventss="events" :focus="focus" @refocus="(v) => this.focus=v" @createEvent="createEvent"/>
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
        focus_start: '',
        focus_end: '',
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
      refocus(date){
        this.focus_start =  new Date(new Date(date).setDate(-6)).toISOString().slice(0, 10);
        this.focus_end = new Date(new Date(date).setDate(39)).toISOString().slice(0, 10);
        this.loadAllAerzte()
        this.GetAllTermineByTimeRange({
            startDate: this.focus_start,
            endDate: this.focus_end
        });
      }
    },
    computed:{
      ...mapState([
        'termine',
        'aerzte'
      ]),
      events() {
        return this.termine.map(t => {
          return {
            ...t,
            timed: true,
            start: t.terminDate.getTime(),
            end: t.terminDate.getTime() + 2000000,
            color: this.arztColors[this.aerzte.findIndex(a => a.id == t.arztId)],
            name:  t.first_Name[0] + '. ' + t.last_Name
          }
        })
      },
      colorByAerzte() {
        console.log(this.aerzte)
        if(this.aerzte.length == 0) return

        return this.aerzte.map((a, i) =>{
        return {
            color: this.arztColors[i],
            i:i,
            arztName: a.first_Name + ' ' + a.last_Name
        }});
      }
    },
    watch: {
      focus(v){
        this.refocus(v)
      }
    },
    mounted() {
      var date = new Date().toISOString().slice(0, 10)
      this.focus = date
    }
  }
  </script>

  <style scoped>
  .WeekMonth{
    display: flex;
    justify-content: space-around;
  }
  .StatusColor{
    width: 10px;
    height: 20px;
    margin-right: 5px;
  }
  </style>
