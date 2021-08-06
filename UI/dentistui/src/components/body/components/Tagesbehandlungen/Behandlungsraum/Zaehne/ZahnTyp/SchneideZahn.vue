<template>
  <div class="all">
    <slot></slot>
  </div>
</template>

<script>
export default {
  name: "SchneideZahn",
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
  components: {
  },
  computed:{
    styleSchneideZahn(){
      let returnObject = {}
      returnObject = {
        gridTemplateRows: this.isUnterKiefer ? '45% 20% 35%' : '35% 20% 45%',
        paddingBottom:  this.isUnterKiefer ? '' : '3px',
        paddingTop:  this.isUnterKiefer ? '3px' : ''
      }
      return returnObject;
    },
  }

}
</script>

<style scoped>
.all{
  width: 100%;
  height: 100%;
}
</style>
