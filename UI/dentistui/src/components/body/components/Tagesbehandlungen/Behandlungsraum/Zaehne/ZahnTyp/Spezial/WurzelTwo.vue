<template>
  <div class="wurzel-two">
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
  }
}
</script>

<style scoped>
.wurzel-two{
  display: grid;
  grid-template-columns: 1fr 1fr 1fr 1fr 1fr 1fr;
}
</style>
