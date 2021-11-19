<template>
  <div class="Fill">
    <v-sheet height="750">
      <v-calendar
        ref="calendar"
        v-model="value"
        color="primary"
        :type="type"
        :events="eventss"
        :event-color="getEventColor"
        :event-ripple="false"
        :max-days="maxDays"
        :weekdays="weekdays"
        :first-interval="intervals.first"
        :interval-minutes="intervals.minutes"
        :interval-count="intervals.count"
        :interval-height="intervals.height"

        @mousedown:event="startDrag"
        @mousedown:time="startTime"
        @mousemove:time="mouseMove"
        @mouseup:time="endDrag"
        @mouseleave.native="cancelDrag"
        @click:date="changeDate"
        @click:day="changeDay"
      >
        <template v-slot:event="{event}">
          <KalenderCard :infos="event" />
        </template>
      </v-calendar>
    </v-sheet>
    <create-event-confirm-modal :data="createEvent" :show="createEventConfirmModal" @ok="closeConfirmModal" @cancel="closeConfirmModal"/>
  </div>
</template>

<script>

import CreateEventConfirmModal from './CreateEventConfirmModal.vue'
import KalenderCard from './KalenderCard.vue'

export default {
    name: "Calendar",
    props:{
      type: String,
      eventss: Array,
      focus: {
        type: String,
        default: ''
      },
    },
    components: {
      CreateEventConfirmModal,
      KalenderCard
    },
    data: () => ({
      value: '',
      events: [],
      colors: ['#2196F3', '#3F51B5', '#673AB7', '#00BCD4', '#4CAF50', '#FF9800', '#757575'],
      dragEvent: null,
      dragStart: null,
      createEvent: null,
      createStart: null,
      extendOriginal: null,
      createEventConfirmModal: false,
      maxDays: 5,
      weekdays: [1, 2, 3, 4, 5],
      intervalsDay: {
        first: 16,
        minutes: 30,
        count: 20,
        height: 33,
      },
      intervalsWeek: {
        first: 14,
        minutes: 30,
        count: 24,
        height: 33,
      }
    }),
    computed: {
      intervals() {
        return this.type == 'day' ? this.intervalsDay : this.intervalsWeek
      }
    },
    methods: {
      closeConfirmModal(){
        this.createEvent = null;
        this.createEventConfirmModal = false;
      },
      changeDay(value){
        console.log(value)
        if(this.type != 'month') return;
        this.createEvent = {
          name: `Event #${this.events.length}`,
          color: this.rndElement(this.colors),
          start: null,
          end: null,
          date: value.date,
          timed: true,
        }
        this.createEventConfirmModal = true;
      },
      changeDate(value){
        this.value = value.date
      },
      startDrag ({ event, timed }) {

        if (event && timed) {
          this.dragEvent = event
          this.dragTime = null
          this.extendOriginal = null
        }
      },
      isClickOverEvent(tms) {
        const t = this.toTimeWithOffset(tms)
        return this.events.find(x => x.start < t && x.end > t) && this.events.find(x => x.start < t && x.end > t) != null;
      },
      startTime (tms) {
        if(this.isClickOverEvent(tms)){
          return
        }
        const mouse = this.toTime(tms)
        const date = this.toDate(tms)
        const endDate = new Date(date.getTime() + 30*60000)


        this.createStart = this.roundTime(mouse)
        this.createEvent = {
          name: `Event #${this.events.length}`,
          color: this.rndElement(this.colors),
          start: date,
          end: endDate,
          timed: true,
        }
      },
      extendBottom (event) {
        this.createEvent = event
        this.createStart = event.start
        this.extendOriginal = event.end
      },
      mouseMove (tms) {
        const mouse = this.toTime(tms)

        if (this.dragEvent && this.dragTime !== null) {
          const start = this.dragEvent.start
          const end = this.dragEvent.end
          const duration = end - start
          const newStartTime = mouse - this.dragTime
          const newStart = this.roundTime(newStartTime)
          const newEnd = newStart + duration

          this.dragEvent.start = newStart
          this.dragEvent.end = newEnd
        } else if (this.createEvent && this.createStart !== null) {
          const mouseRounded = this.roundTime(mouse, false)
          const min = Math.min(mouseRounded, this.createStart)
          const max = Math.max(mouseRounded, this.createStart)

          this.createEvent.start = new Date(this.toTime(min))
          this.createEvent.end = new Date(this.toTime(max))
        }
      },
      endDrag () {
        this.dragTime = null
        if(this.dragEvent != null){
          this.dragEventConfirmModal = true;
          this.$emit("dragEvent", this.dragEvent)
        }
        if(this.createEvent != null){
          this.createEventConfirmModal = true;
          this.$emit("createEvent", this.createEvent)
        }
        this.createStart = null
        this.extendOriginal = null
      },
      cancelDrag () {
        if (this.createEvent) {
          if (this.extendOriginal) {
            this.createEvent.end = this.extendOriginal
          } else {
            const i = this.events.indexOf(this.createEvent)
            if (i !== -1) {
              this.events.splice(i, 1)
            }
          }
        }

        this.createStart = null
        this.dragTime = null
        this.dragEvent = null
      },
      roundTime (time, down = true) {
        const roundTo = 15 // minutes
        const roundDownTime = roundTo * 60 * 1000

        return down
          ? time - time % roundDownTime
          : time + (roundDownTime - (time % roundDownTime))
      },
      toTime (tms) {
        return this.toDate(tms).getTime()
      },
      toDate (tms) {
        return new Date(tms.year, tms.month - 1, tms.day, tms.hour + 2, tms.minute)
      },
      toTimeWithOffset (tms) {
        return this.toDateWithOffset(tms).getTime()
      },
      toDateWithOffset (tms) {
        return new Date(tms.year, tms.month - 1, tms.day, tms.hour, tms.minute)
      },
      getEventColor (event) {
        const rgb = parseInt(event.color.substring(1), 16)
        const r = (rgb >> 16) & 0xFF
        const g = (rgb >> 8) & 0xFF
        const b = (rgb >> 0) & 0xFF

        return event === this.dragEvent
          ? `rgba(${r}, ${g}, ${b}, 0.7)`
          : event === this.createEvent
            ? `rgba(${r}, ${g}, ${b}, 0.7)`
            : event.color
      },
      rnd (a, b) {
        return Math.floor((b - a + 1) * Math.random()) + a
      },
      rndElement (arr) {
        return arr[this.rnd(0, arr.length - 1)]
      },
      refocus() {
        this.value = this.focus
      },
      prev () {
        this.$refs.calendar.prev()
      },
      next () {
        this.$refs.calendar.next()
      },
    },
    watch: {
      focus(){
        this.refocus()
      },
      value(v){
        this.$emit("refocus", v)
      },
      eventss(v){
        this.events = v;
      }
    },
    mounted() {
      this.refocus()
    }
  }
</script>


<style scoped lang="scss">
.Fill{
  width: 98%;
  margin-left: 1%;
}
.v-event-draggable {
  padding-left: 6px;
}

.v-event-timed {
  user-select: none;
  -webkit-user-select: none;
}

.v-event-drag-bottom {
  position: absolute;
  left: 0;
  right: 0;
  bottom: 4px;
  height: 4px;
  cursor: ns-resize;

  &::after {
    display: none;
    position: absolute;
    left: 50%;
    height: 4px;
    border-top: 1px solid white;
    border-bottom: 1px solid white;
    width: 16px;
    margin-left: -8px;
    opacity: 0.8;
    content: '';
  }

  &:hover::after {
    display: block;
  }
}
</style>
