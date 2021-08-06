<template>
  <div class="ZahnCard">
    <div class="ZahnCardAufbau">
      <wurzel-selector class="wurzel-selector" :wurzeln="wurzeln"/>
      <div />
      <div class="box mitte-mitte"/>
      <div />
      <div v-if="type !== 'SchneideZahn' && type !== 'EckZahn'" />
      <div v-if="type !== 'SchneideZahn' && type !== 'EckZahn'" class="unten-mitte" :style='styleUntenMitteMitte' >
        <spezial-form-round />
      </div>
      <div v-if="type === 'SchneideZahn' || type === 'EckZahn'" class="box unten-links"/>
      <div v-if="type === 'SchneideZahn' || type === 'EckZahn'" class="unten-mitte">
        <div class="box"/>
        <div class="box"/>
        <div class="box"/>
      </div>
      <div v-if="type === 'SchneideZahn' || type === 'EckZahn'" class="box unten-rechts"/>
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
  }
  //<eck-zahn v-if="type === 'EckZahn'" :zahn-style="zahnStyle" :wurzeln="wurzeln" :isUnterKiefer="isUnterKiefer" />
  //<vormahl-zahn v-if="type === 'VormahlZahn'" :zahn-style="zahnStyle" :wurzeln="wurzeln" :isUnterKiefer="isUnterKiefer" />
  //<mahl-zahn v-if="type === 'MahlZahn'" :zahn-style="zahnStyle" :wurzeln="wurzeln" :isUnterKiefer="isUnterKiefer" />
  //<weisheits-zahn v-if="type === 'WeisheitsZahn'" :zahn-style="zahnStyle" :wurzeln="wurzeln" :isUnterKiefer="isUnterKiefer" />


}
</script>

<style scoped>
.ZahnCard{
  width: 80px;
  height: 80px;
  background-color: aquamarine;
}
.zzz{
  width: 100%;
  height: 100%;
}
.ZahnCardAufbau{
  padding-right: 10px;
  padding-left: 10px;
  padding-bottom: 3px;
  width: 100%;
  height: 100%;
  display: grid;
  grid-template-columns: 30% 40% 30%;
  grid-template-rows: 35% 20% 45%;
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
