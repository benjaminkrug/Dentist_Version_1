<template>
  <div class="all">
    <wurzel-selector class="wurzel-selector" :wurzeln="wurzeln"/>
    <div class="box mitte-mitte" />
    <div class="unten-mitte" >
      <spezial-form-round class="spezial" />
    </div>
  </div>
</template>

<script>
import WurzelSelector from './Spezial/WurzelSelector.vue'
import SpezialFormRound from './Spezial/SpezialFormRound0.vue'
export default {
  name: "VormahlZahn",
  props:{
    wurzeln:{
      type: Number,
      default: 1
    },
  },
  components: {
    WurzelSelector,
    SpezialFormRound
  }

}
</script>

<style scoped>
.all{
  width: 100%;
  height: 100%;
  display: grid;
  grid-template-rows: 35% 20% 45%;
}
.VormahlZahnOben{
  padding-bottom: 3px;
  padding-right: 10px;
  padding-left: 10px;
  display: grid;
  grid-template-columns: auto 17px 17px 15px;
  grid-template-rows: 100%;
}
.VormahlZahnUnten{
  padding-bottom: 3px;
  padding-right: 10px;
  padding-left: 10px;
  display: grid;
  grid-template-columns: 30% 40% 30%;
  grid-template-rows:  31% 69%;
}
.SchneideZahn >*{
}
.oben-mitte{
  justify-self: center;
}
.oben-mitte-2{
  justify-self: center;
}
.mitte-mitte{
  width: 34%;
  justify-self: center;
  border-radius: 6px;
  margin: 3px 1px 1px;
  z-index: 2;
}
.unten-mitte{
  border-radius: 6px;
  display: grid;
  grid-template-rows: 33% 34% 33%;
  grid-template-columns: 33% 34% 33%;
  padding-bottom: 3px;

}
.unten-mitte >*{
  border-radius: 6px;
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
