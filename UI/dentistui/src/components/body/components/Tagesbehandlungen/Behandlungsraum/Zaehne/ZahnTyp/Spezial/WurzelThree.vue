<template>
  <div class="wurzel-three">
    <div />
    <spezial-form :isUnterKiefer="isUnterKiefer" />
    <spezial-form :isUnterKiefer="isUnterKiefer" />
    <spezial-form :isUnterKiefer="isUnterKiefer" />
  </div>
</template>

<script>
import SpezialForm from './SpezialForm.vue'
export default {
  name: "WurzelThree",
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
      }

}
</script>

<style scoped>
.wurzel-three{
  display: grid;
  grid-template-columns: 1fr 1fr 1fr 1fr 1fr;
}
</style>
