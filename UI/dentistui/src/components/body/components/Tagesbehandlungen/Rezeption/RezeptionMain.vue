<template>
  <div class="Fill">
    Rezeption
    <div class="RezeptionStyle">
      <div class="calender box">
        <kalender />
      </div>
      <div class="wartezimmer box">
        Wartezimmer
      </div>
      <div class="behandlung box">
        In Behandlung
      </div>
    </div>
  </div>
</template>

<script>

import kalender from './Kalender/KalenderMain.vue'
export default {
  name: "Rezeption",
  components:{
    kalender
  },
}
</script>

<style scoped>
.Fill{
  width: 100%;
  height: 100vh;
}
.RezeptionStyle{
  position: fixed;
  top: 125px;
  left: 0;
  right: 0;
  bottom: 0;

  display: grid;
  grid-template-columns: repeat(2, 1fr);
  grid-template-rows: repeat(2, 1fr);
}
.box{
  margin: 10px;
  border-style: solid;
  border-color: black;
}
.calender {
  grid-column: 1;
  grid-row: 1 / span 2;
}
.wartezimmer{
  grid-column: 2;
  grid-row: 1;
}
.behandlung{
  grid-column: 2;
  grid-row: 2;
}
</style>
