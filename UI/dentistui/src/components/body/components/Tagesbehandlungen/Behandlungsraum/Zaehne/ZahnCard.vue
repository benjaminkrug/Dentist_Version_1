<template>
  <div>
    <div v-if="!isUnterKiefer">
      <div class="ZahnCardAufbau">
        <wurzel-selector class="wurzel-selector" :wurzeln="wurzeln" />
        <div />
        <div class="box mitte-mitte" :style="styleMitteMitte" @click="AddFuellung('mitte-mitte')"/>
        <div />
        <div v-if="type !== 'SchneideZahn' && type !== 'EckZahn'" />
        <div v-if="type !== 'SchneideZahn' && type !== 'EckZahn'" class="unten-mitte" >
          <spezial-form-round />
        </div>
        <div v-if="type === 'SchneideZahn' || type === 'EckZahn'" class="box unten-links" :style="styleUntenLinks" />
        <div v-if="type === 'SchneideZahn' || type === 'EckZahn'" class="unten-mitte" >
          <div class="box" :style="styleUntenMitteOben" />
          <div class="box" :style="styleUntenMitteMitte" />
          <div class="box" :style="styleUntenMitteUnten" />
        </div>
        <div v-if="type === 'SchneideZahn' || type === 'EckZahn'" class="box unten-rechts" :style="styleUntenRechts" />
      </div>
    </div>
    <div v-else>
      <div class="ZahnCardAufbauUnterkiefer">
        <div v-if="type !== 'SchneideZahn' && type !== 'EckZahn'" />
        <div v-if="type !== 'SchneideZahn' && type !== 'EckZahn'" class="unten-mitte" >
          <spezial-form-round />
        </div>
        <div v-if="type === 'SchneideZahn' || type === 'EckZahn'" class="box unten-links" :style="styleUntenLinks" />
        <div v-if="type === 'SchneideZahn' || type === 'EckZahn'" class="unten-mitte">
          <div class="box" :style="styleUntenMitteOben" />
          <div class="box" :style="styleUntenMitteMitte" />
          <div class="box" :style="styleUntenMitteUnten" />
        </div>
        <div v-if="type === 'SchneideZahn' || type === 'EckZahn'" class="box unten-rechts" :style="styleUntenRechts" />
        <div v-if="type !== 'SchneideZahn' && type !== 'EckZahn'" />
        <div />
        <div class="box mitte-mitte" :style="styleMitteMitte" />
        <div />
        <wurzel-selector class="wurzel-selector" :wurzeln="wurzeln" isUnterKiefer />
      </div>
    </div>
  </div>
</template>

<script>
//import SchneideZahn from './ZahnTyp/SchneideZahn.vue'
//import EckZahn from './ZahnTyp/EckZahn.vue'
//import VormahlZahn from './ZahnTyp/VormahlZahn.vue'
//import MahlZahn from './ZahnTyp/MahlZahn.vue'
//import WeisheitsZahn from './ZahnTyp/WeisheitsZahn.vue'

import WurzelSelector from './ZahnTyp/Spezial/WurzelSelector.vue'
import SpezialFormRound from './ZahnTyp/Spezial/SpezialFormRound0.vue'

export default {
  name: "Zahnecard",
  components: {
    //SchneideZahn,
    //EckZahn,
    //VormahlZahn,
    //MahlZahn,
    //WeisheitsZahn,
    WurzelSelector,
    SpezialFormRound
  },
  props:{
    zahnStyle: [],
    type:{
      type: String,
      default: 'SchneideZahn'
    },
    wurzeln:{
      type: Number,
      default: 1
    },
    isUnterKiefer:{
      type: Boolean,
      default: false
    },
  },
  computed:{
    styleObenLinks(){
      let returnObject = {}
      Object.assign(returnObject, this.AddIfIsPosition('oben-links', 'backgroundColor', 'red'));
      return returnObject;
    },
    styleObenMitte(){
      let returnObject = {}
      Object.assign(returnObject, this.AddIfIsPosition('oben-mitte', 'backgroundColor', 'red'));
      return returnObject;
    },
    styleObenRechts(){
      let returnObject = {}
      Object.assign(returnObject, this.AddIfIsPosition('oben-rechts', 'backgroundColor', 'red'));
      return returnObject;
    },
    styleMitteMitte(){
      let returnObject = {}
      Object.assign(returnObject, this.AddIfIsPosition('mitte-mitte', 'backgroundColor', 'red'));
      return returnObject;
    },
    styleUntenLinks(){
      let returnObject = {}
      Object.assign(returnObject, this.AddIfIsPosition('unten-links', 'backgroundColor', 'red'));
      return returnObject;
    },
    styleUntenMitteOben(){
      let returnObject = {}
      Object.assign(returnObject, this.AddIfIsPosition('unten-mitte-oben', 'backgroundColor', 'red'));
      return returnObject;
    },
    styleUntenMitteMitte(){
      let returnObject = {}
      Object.assign(returnObject, this.AddIfIsPosition('unten-mitte-mitte', 'backgroundColor', 'red'));
      return returnObject;
    },
    styleUntenMitteUnten(){
      let returnObject = {}
      Object.assign(returnObject, this.AddIfIsPosition('unten-mitte-unten', 'backgroundColor', 'red'));
      return returnObject;
    },
    styleUntenRechts(){
      let returnObject = {}
      Object.assign(returnObject, this.AddIfIsPosition('unten-rechts', 'backgroundColor', 'red'));
      return returnObject;
    },
  },
  methods:{
    AddFuellung(part){
      this.$emit("addFuellung", part)
    },
    AddIfIsPosition(position, key, value ){
      let returnObject = {}
      if(this.zahnStyle.find(x => x.position == position)){
         returnObject[key] = value
      }
      return returnObject;
    }
  }
  //<eck-zahn v-if="type === 'EckZahn'" :zahn-style="zahnStyle" :wurzeln="wurzeln" :isUnterKiefer="isUnterKiefer" />
  //<vormahl-zahn v-if="type === 'VormahlZahn'" :zahn-style="zahnStyle" :wurzeln="wurzeln" :isUnterKiefer="isUnterKiefer" />
  //<mahl-zahn v-if="type === 'MahlZahn'" :zahn-style="zahnStyle" :wurzeln="wurzeln" :isUnterKiefer="isUnterKiefer" />
  //<weisheits-zahn v-if="type === 'WeisheitsZahn'" :zahn-style="zahnStyle" :wurzeln="wurzeln" :isUnterKiefer="isUnterKiefer" />


}
</script>

<style scoped>
.ZahnCard{
}
.zzz{
  width: 100%;
  height: 100%;
}
.ZahnCardAufbau{
  width: 80px;
  height: 80px;
  background-color: aquamarine;
  padding-right: 10px;
  padding-left: 10px;
  padding-bottom: 3px;
  display: grid;
  grid-template-columns: 30% 40% 30%;
  grid-template-rows: 35% 20% 45%;
}
.ZahnCardAufbauUnterkiefer{
  width: 80px;
  height: 80px;
  background-color: aquamarine;
  padding-right: 10px;
  padding-left: 10px;
  padding-bottom: 3px;
  display: grid;
  grid-template-columns: 30% 40% 30%;
  grid-template-rows: 45% 20% 35%;
}
.wurzel-selector{
  grid-column-end: span 3;
}
.box{
  background-color: white;
  border-style: solid;
  border-width: 2px;
  border-radius: 4px;
}
.mitte-mitte{
  border-radius: 4px;
  margin: 3px 1px 1px;
  z-index: 2;
}
.unten-mitte{
  display: grid;
  grid-template-rows: 33% 34% 33%;
}
.unten-mitte >*{
  border-radius: 4px;
}
.unten-links{
}
.unten-rechts{
}
</style>
