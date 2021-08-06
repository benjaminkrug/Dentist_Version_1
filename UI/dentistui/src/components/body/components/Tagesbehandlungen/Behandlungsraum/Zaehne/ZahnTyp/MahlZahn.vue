<template>
  <div>
    <div v-if="!isUnterKiefer"  class="MahlZahn" :style="styleMahlZahn">
      <wurzel-selector class="wurzel-selector" :wurzeln="wurzeln"/>
      <div />
      <div class="box mitte-mitte"/>
      <div />
      <div />
      <div class="unten-mitte" >
        <spezial-form-round class="spezial" />
      </div>
    </div>
    <div v-else class="MahlZahn" :style="styleMahlZahn">
      <div />
      <div class="unten-mitte" >
        <spezial-form-round class="spezial" />
      </div>
      <div />
      <div />
      <div class="box mitte-mitte"/>
      <wurzel-selector class="wurzel-selector" :wurzeln="wurzeln" :isUnterKiefer="isUnterKiefer" />
    </div>
  </div>
</template>

<script>
import WurzelSelector from './Spezial/WurzelSelector.vue'
import SpezialFormRound from './Spezial/SpezialFormRound0.vue'
export default {
  name: "MahlZahn",
  props:{
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
    styleMahlZahn() {
      let returnObject = {}
      returnObject = {gridTemplateRows: this.isUnterKiefer ? '35% 20% 45%' : '35% 20% 45%' }
      return returnObject;
    },
  },
  components: {
    WurzelSelector,
    SpezialFormRound
  }

}
</script>

<style scoped>
.MahlZahn{
  padding-bottom: 3px;
  padding-right: 10px;
  padding-left: 10px;
  width: 100%;
  height: 100%;
  display: grid;
  grid-template-columns: 30% 40% 30%;
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
.spezial{
  margin-left: 2px;
  grid-row-start: 1;
  grid-column-start: 2;
}
</style>
