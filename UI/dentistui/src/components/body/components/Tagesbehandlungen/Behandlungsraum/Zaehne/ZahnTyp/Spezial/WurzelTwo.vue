<template>
  <div class="wurzel-two" :style="styleIsUnterkiefer">
    <div />
    <div />
    <spezial-form :isUnterKiefer="isUnterKiefer" />
    <spezial-form :isUnterKiefer="isUnterKiefer" />
  </div>
</template>

<script>
import SpezialForm from './SpezialForm.vue'
export default {
  name: "WurzelTwo",
  props:{
    isUnterKiefer:{
      type: Boolean,
      default: false
    },
  },
  components: {
    SpezialForm
  },
  data() {
    return {
    };
  },
  computed:{
    styleIsUnterkiefer(){
      let returnObject = {}
      returnObject = {marginTop: this.isUnterKiefer ? '-10px' : '' }
      return returnObject;
    },
  }
}
</script>

<style scoped>
.wurzel-two{
  display: grid;
  grid-template-columns: 1fr 1fr 1fr 1fr 1fr 1fr;
}
</style>
