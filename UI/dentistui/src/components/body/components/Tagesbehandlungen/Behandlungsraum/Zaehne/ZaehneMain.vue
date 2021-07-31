<template>
  <div class="ZahnmainOverlay">
    <div/>
    <div class="Zahnmain">
      <zahn-card type='WeisheitsZahn' :zahn-style="style[0].fuellungen" :wurzeln='3' />
      <zahn-card type='MahlZahn' :zahn-style="style[1].fuellungen" :wurzeln='3' />
      <zahn-card type='MahlZahn' :zahn-style="style[2].fuellungen" :wurzeln='3' />
      <zahn-card type='VormahlZahn' :zahn-style="style[3].fuellungen" :wurzeln='1' />
      <zahn-card type='VormahlZahn' :zahn-style="style[4].fuellungen" :wurzeln='2' />
      <zahn-card type='EckZahn' :zahn-style="style[5].fuellungen" :wurzeln='1' />
      <zahn-card type='SchneideZahn' :zahn-style="style[6].fuellungen" :wurzeln='1' />
      <zahn-card type='SchneideZahn' :zahn-style="style[7].fuellungen" :wurzeln='1' />
      <zahn-card type='SchneideZahn' :zahn-style="style[8].fuellungen" :wurzeln='1' />
      <zahn-card type='SchneideZahn' :zahn-style="style[9].fuellungen" :wurzeln='1' />
      <zahn-card type='EckZahn' :zahn-style="style[10].fuellungen" :wurzeln='1' />
      <zahn-card type='VormahlZahn' :zahn-style="style[11].fuellungen" :wurzeln='2' />
      <zahn-card type='VormahlZahn' :zahn-style="style[12].fuellungen" :wurzeln='1' />
      <zahn-card type='MahlZahn' :zahn-style="style[13].fuellungen" :wurzeln='3' />
      <zahn-card type='MahlZahn' :zahn-style="style[14].fuellungen" :wurzeln='3' />
      <zahn-card type='WeisheitsZahn' :zahn-style="style[15].fuellungen" :wurzeln='3' />
      <!-- Zeile2 -->
      <zahn-card type='WeisheitsZahn' :zahn-style="style[16].fuellungen" :wurzeln='2' />
      <zahn-card type='MahlZahn' :zahn-style="style[17].fuellungen" :wurzeln='2' />
      <zahn-card type='MahlZahn' :zahn-style="style[18].fuellungen" :wurzeln='2' />
      <zahn-card type='VormahlZahn' :zahn-style="style[19].fuellungen" :wurzeln='1' />
      <zahn-card type='VormahlZahn' :zahn-style="style[20].fuellungen" :wurzeln='1' />
      <zahn-card type='EckZahn' :zahn-style="style[21].fuellungen" :wurzeln='1' />
      <zahn-card type='SchneideZahn' :zahn-style="style[22].fuellungen" :wurzeln='1' />
      <zahn-card type='SchneideZahn' :zahn-style="style[23].fuellungen" :wurzeln='1' />
      <zahn-card type='SchneideZahn' :zahn-style="style[24].fuellungen" :wurzeln='1' />
      <zahn-card type='SchneideZahn' :zahn-style="style[25].fuellungen" :wurzeln='1' />
      <zahn-card type='EckZahn' :zahn-style="style[26].fuellungen" :wurzeln='1' />
      <zahn-card type='VormahlZahn' :zahn-style="style[27].fuellungen" :wurzeln='1' />
      <zahn-card type='VormahlZahn' :zahn-style="style[28].fuellungen" :wurzeln='1' />
      <zahn-card type='MahlZahn' :zahn-style="style[29].fuellungen" :wurzeln='2' />
      <zahn-card type='MahlZahn' :zahn-style="style[30].fuellungen" :wurzeln='2' />
      <zahn-card type='WeisheitsZahn' :zahn-style="style[31].fuellungen" :wurzeln='2' />
    </div>
  </div>
</template>

<script>
import { mapState, mapActions } from 'vuex'

import ZahnCard from './ZahnCard.vue'

export default {
  name: "Zähnemain",
  components: {
    ZahnCard
  },
  props:{
    zahnListFuellung: [],
    gebiss: {}
  },
  data() {
    return {
      fuellungen: [],
    }
  },
  computed: {
    ...mapState([
    ]),
    style(){
      var g = Object.values(this.gebiss).filter(x => x != this.gebiss.id && x != this.gebiss.userId)
      return g.map(zahnId => { return{ zahnId, fuellungen: this.zahnListFuellung.filter(x => x.id == zahnId) || [] }})
    }
  },
  mounted() {
  },
  methods:{
    ...mapActions([
    ]),
  },
}
</script>

<style scoped>
.ZahnmainOverlay{
  width: 100%;
  display: grid;
  grid-template-columns: 1fr auto 1fr;
}
.Zahnmain{
  width: auto;
  display: grid;
  grid-template-columns: repeat(16, 1fr);
  grid-template-rows: repeat(2, 1fr);
}
.Zahnmain >*{
  margin: 1px;
}
</style>
