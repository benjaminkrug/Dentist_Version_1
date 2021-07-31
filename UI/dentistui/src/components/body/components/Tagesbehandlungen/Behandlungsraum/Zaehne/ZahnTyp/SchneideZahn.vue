<template>
  <div class="SchneideZahn">
    <wurzel-selector class="wurzel-selector" :wurzeln="wurzeln"/>
    <div />
    <div class="box mitte-mitte"/>
    <div />
    <div class="box unten-links"/>
    <div class="unten-mitte">
      <div class="box"/>
      <div class="box"/>
      <div class="box"/>
    </div>
    <div class="box unten-rechts"/>
  </div>
</template>

<script>
import WurzelSelector from './Spezial/WurzelSelector.vue'
export default {
  name: "SchneideZahn",
  props:{
    wurzeln:{
      type: Number,
      default: 1
    },
  },
  components: {
    WurzelSelector
  }

}
</script>

<style scoped>
.SchneideZahn{
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
