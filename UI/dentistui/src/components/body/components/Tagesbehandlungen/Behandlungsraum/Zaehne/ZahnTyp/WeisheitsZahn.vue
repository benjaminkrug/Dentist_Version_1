<template>
  <div class="WeisheitsZahn" >
    <wurzel-selector class="wurzel-selector" :wurzeln="wurzeln"/>
    <div />
    <div class="box mitte-mitte" :style='styleMitteMitte' />
    <div />

    <div />
    <div class="unten-mitte" :style='styleUntenMitteMitte' >
      <spezial-form-round />
    </div>
  </div>
</template>

<script>
import WurzelSelector from './Spezial/WurzelSelector.vue'
import SpezialFormRound from './Spezial/SpezialFormRound0.vue'
export default {
  name: "WeisheitsZahn",
  components: {
    WurzelSelector,
    SpezialFormRound
  },
  props:{
    zahnStyle: [],
    wurzeln:{
      type: Number,
      default: 1
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
    AddIfIsPosition(position, key, value ){
      let returnObject = {}
      if(this.zahnStyle.find(x => x.position == position)){
         returnObject[key] = value
      }
      return returnObject;
    }
  }

}
</script>

<style scoped>
.WeisheitsZahn{
  padding-bottom: 3px;
  padding-right: 10px;
  padding-left: 10px;
  width: 100%;
  height: 100%;
  display: grid;
  grid-template-columns: 30% 40% 30%;
  grid-template-rows: 35% 20% 45%;
}
.wurzel-selector{
  grid-column-end: span 3;
}
.SchneideZahn >*{
}
.mitte-mitte{
  border-radius: 6px;
  margin: 3px 1px 1px;
  z-index: 2;
}
.unten-mitte{
  border-radius: 6px;
  display: grid;
  grid-template-rows: 33% 34% 33%;
  padding-bottom: 3px;

}
.unten-mitte >*{
  border-radius: 6px;
}
.oben-links{
  margin-left: 5px;
}
.oben-mitte{
  margin-left: -1px;
}
.oben-rechts{
  margin-left: -12px;
}
.unten-links{
  border-radius: 6px;
  margin-bottom: 2px;
}
.unten-rechts{
  border-radius: 4px;
  margin-bottom: 2px;
}
.box{
  background-color: white;
  border-style: solid;
  border-width: 2px;
  border-radius: 4px;
}
</style>
