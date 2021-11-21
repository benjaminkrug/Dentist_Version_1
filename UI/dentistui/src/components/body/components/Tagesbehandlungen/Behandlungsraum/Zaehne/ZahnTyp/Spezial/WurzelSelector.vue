<template>
  <div class="wurzel-selector"  :style="styleIsUnterkiefer">
    <wurzel-one v-if="wurzeln === 1"  :isUnterKiefer="isUnterKiefer" @AddBehandlung="(value) => $emit('AddBehandlung', value)"/>
    <wurzel-two v-if="wurzeln === 2"  :isUnterKiefer="isUnterKiefer" @AddBehandlung="(value) => $emit('AddBehandlung', value)"/>
    <wurzel-three v-if="wurzeln === 3"  :isUnterKiefer="isUnterKiefer" @AddBehandlung="(value) => $emit('AddBehandlung', value)"/>
  </div>
</template>

<script>
import WurzelOne from './WurzelOne.vue'
import WurzelTwo from './WurzelTwo.vue'
import WurzelThree from './WurzelThree.vue'
export default {
  name: "WurzelSelector",
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
    WurzelOne,
    WurzelTwo,
    WurzelThree
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
.wurzel-selector{
}
</style>
