<template>
  <div class="ZahnmainOverlay">
    <div/>
    <div class="Zahnmain">
      <zahn-card type='WeisheitsZahn' :zahn-style="style[0].fuellungen" :wurzeln='3' position="_11" @addFuellung="(part)=> addFuellung(part, '_11')" @setSelecedZahn="setSelecedZahn"/>
      <zahn-card type='MahlZahn' :zahn-style="style[1].fuellungen" :wurzeln='3' position="_12" @addFuellung="(part)=> addFuellung(part, '_12')" @setSelecedZahn="setSelecedZahn"/>
      <zahn-card type='MahlZahn' :zahn-style="style[2].fuellungen" :wurzeln='3' position="_13" @addFuellung="(part)=> addFuellung(part, '_13')" @setSelecedZahn="setSelecedZahn"/>
      <zahn-card type='VormahlZahn' :zahn-style="style[3].fuellungen" :wurzeln='1' position="_14" @addFuellung="(part)=> addFuellung(part, '_14')" @setSelecedZahn="setSelecedZahn"/>
      <zahn-card type='VormahlZahn' :zahn-style="style[4].fuellungen" :wurzeln='2' position="_15" @addFuellung="(part)=> addFuellung(part, '_15')" @setSelecedZahn="setSelecedZahn"/>
      <zahn-card type='EckZahn' :zahn-style="style[5].fuellungen" :wurzeln='1' position="_16" @addFuellung="(part)=> addFuellung(part, '_16')" @setSelecedZahn="setSelecedZahn"/>
      <zahn-card type='SchneideZahn' :zahn-style="style[6].fuellungen" :wurzeln='1' position="_17" @addFuellung="(part)=> addFuellung(part, '_17')" @setSelecedZahn="setSelecedZahn"/>
      <zahn-card type='SchneideZahn' :zahn-style="style[7].fuellungen" :wurzeln='1' position="_18" @addFuellung="(part)=> addFuellung(part, '_18')" @setSelecedZahn="setSelecedZahn"/>
      <zahn-card type='SchneideZahn' :zahn-style="style[8].fuellungen" :wurzeln='1' position="_21" @addFuellung="(part)=> addFuellung(part, '_21')" @setSelecedZahn="setSelecedZahn"/>
      <zahn-card type='SchneideZahn' :zahn-style="style[9].fuellungen" :wurzeln='1' position="_22" @addFuellung="(part)=> addFuellung(part, '_22')" @setSelecedZahn="setSelecedZahn"/>
      <zahn-card type='EckZahn' :zahn-style="style[10].fuellungen" :wurzeln='1' position="_23" @addFuellung="(part)=> addFuellung(part, '_23')" @setSelecedZahn="setSelecedZahn"/>
      <zahn-card type='VormahlZahn' :zahn-style="style[11].fuellungen" :wurzeln='2' position="_24" @addFuellung="(part)=> addFuellung(part, '_24')" @setSelecedZahn="setSelecedZahn"/>
      <zahn-card type='VormahlZahn' :zahn-style="style[12].fuellungen" :wurzeln='1' position="_25" @addFuellung="(part)=> addFuellung(part, '_25')" @setSelecedZahn="setSelecedZahn"/>
      <zahn-card type='MahlZahn' :zahn-style="style[13].fuellungen" :wurzeln='3' position="_26" @addFuellung="(part)=> addFuellung(part, '_26')" @setSelecedZahn="setSelecedZahn"/>
      <zahn-card type='MahlZahn' :zahn-style="style[14].fuellungen" :wurzeln='3' position="_27" @addFuellung="(part)=> addFuellung(part, '_27')" @setSelecedZahn="setSelecedZahn"/>
      <zahn-card type='WeisheitsZahn' :zahn-style="style[15].fuellungen" :wurzeln='3' position="_28" @addFuellung="(part)=> addFuellung(part, '_28')" @setSelecedZahn="setSelecedZahn"/>
      <!-- Zeile2 -->
      <zahn-card type='WeisheitsZahn' :zahn-style="style[16].fuellungen" :wurzeln='2' isUnterKiefer position="_31" @addFuellung="(part)=> addFuellung(part, '_31')" @setSelecedZahn="setSelecedZahn"/>
      <zahn-card type='MahlZahn' :zahn-style="style[17].fuellungen" :wurzeln='2' isUnterKiefer position="_32" @addFuellung="(part)=> addFuellung(part, '_32')" @setSelecedZahn="setSelecedZahn"/>
      <zahn-card type='MahlZahn' :zahn-style="style[18].fuellungen" :wurzeln='2' isUnterKiefer position="_33" @addFuellung="(part)=> addFuellung(part, '_33')" @setSelecedZahn="setSelecedZahn"/>
      <zahn-card type='VormahlZahn' :zahn-style="style[19].fuellungen" :wurzeln='1' isUnterKiefer position="_34" @addFuellung="(part)=> addFuellung(part, '_34')" @setSelecedZahn="setSelecedZahn"/>
      <zahn-card type='VormahlZahn' :zahn-style="style[20].fuellungen" :wurzeln='1' isUnterKiefer position="_35" @addFuellung="(part)=> addFuellung(part, '_35')" @setSelecedZahn="setSelecedZahn"/>
      <zahn-card type='EckZahn' :zahn-style="style[21].fuellungen" :wurzeln='1' isUnterKiefer position="_36" @addFuellung="(part)=> addFuellung(part, '_36')" @setSelecedZahn="setSelecedZahn"/>
      <zahn-card type='SchneideZahn' :zahn-style="style[22].fuellungen" :wurzeln='1' isUnterKiefer position="_37" @addFuellung="(part)=> addFuellung(part, '_37')" @setSelecedZahn="setSelecedZahn"/>
      <zahn-card type='SchneideZahn' :zahn-style="style[23].fuellungen" :wurzeln='1' isUnterKiefer position="_38" @addFuellung="(part)=> addFuellung(part, '_38')" @setSelecedZahn="setSelecedZahn"/>
      <zahn-card type='SchneideZahn' :zahn-style="style[24].fuellungen" :wurzeln='1' isUnterKiefer position="_41" @addFuellung="(part)=> addFuellung(part, '_41')" @setSelecedZahn="setSelecedZahn"/>
      <zahn-card type='SchneideZahn' :zahn-style="style[25].fuellungen" :wurzeln='1' isUnterKiefer position="_42" @addFuellung="(part)=> addFuellung(part, '_42')" @setSelecedZahn="setSelecedZahn"/>
      <zahn-card type='EckZahn' :zahn-style="style[26].fuellungen" :wurzeln='1' isUnterKiefer position="_43" @addFuellung="(part)=> addFuellung(part, '_43')" @setSelecedZahn="setSelecedZahn"/>
      <zahn-card type='VormahlZahn' :zahn-style="style[27].fuellungen" :wurzeln='1' isUnterKiefer position="_44" @addFuellung="(part)=> addFuellung(part, '_44')" @setSelecedZahn="setSelecedZahn"/>
      <zahn-card type='VormahlZahn' :zahn-style="style[28].fuellungen" :wurzeln='1' isUnterKiefer position="_45" @addFuellung="(part)=> addFuellung(part, '_45')" @setSelecedZahn="setSelecedZahn"/>
      <zahn-card type='MahlZahn' :zahn-style="style[29].fuellungen" :wurzeln='2' isUnterKiefer position="_46" @addFuellung="(part)=> addFuellung(part, '_46')" @setSelecedZahn="setSelecedZahn"/>
      <zahn-card type='MahlZahn' :zahn-style="style[30].fuellungen" :wurzeln='2' isUnterKiefer position="_47" @addFuellung="(part)=> addFuellung(part, '_47')" @setSelecedZahn="setSelecedZahn"/>
      <zahn-card type='WeisheitsZahn' :zahn-style="style[31].fuellungen" :wurzeln='2' isUnterKiefer position="_48" @addFuellung="(part)=> addFuellung(part, '_48')" @setSelecedZahn="setSelecedZahn"/>
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
      selecedZahn: null
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
    addFuellung(part, zahn){
      console.log(part, this.gebiss[zahn])
    },
    setSelecedZahn(zahnPosition) {
      console.log(zahnPosition)
      this.selecedZahn = zahnPosition;
    }
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
