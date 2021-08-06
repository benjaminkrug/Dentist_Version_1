<template>
  <div class="wurzel-one">
    <spezial-form :isUnterKiefer="isUnterKiefer" />
  </div>
</template>

<script>
import SpezialForm from './SpezialForm.vue'
export default {
  name: "WurzelOne",
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
.wurzel-one{
}
</style>
