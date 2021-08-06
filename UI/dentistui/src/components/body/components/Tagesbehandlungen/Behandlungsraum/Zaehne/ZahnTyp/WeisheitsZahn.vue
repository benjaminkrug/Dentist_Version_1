<template>
  <div>
  </div>
</template>

<script>
export default {
  name: "WeisheitsZahn",
  components: {
  },
  props:{
  },
  computed:{
    styleWeisheitsZahn(){
      let returnObject = {}
      returnObject = {gridTemplateRows: this.isUnterKiefer ? '35% 20% 45%' : '35% 20% 45%' }
      return returnObject;
    },
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
</style>
