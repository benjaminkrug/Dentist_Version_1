<template>
  <div class="wurzel-selector">
    <wurzel-one v-if="wurzeln === 1"  :isUnterKiefer="isUnterKiefer" />
    <wurzel-two v-if="wurzeln === 2"  :isUnterKiefer="isUnterKiefer" />
    <wurzel-three v-if="wurzeln === 3"  :isUnterKiefer="isUnterKiefer" />
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
  }

}
</script>

<style scoped>
.wurzel-selector{
}
</style>
