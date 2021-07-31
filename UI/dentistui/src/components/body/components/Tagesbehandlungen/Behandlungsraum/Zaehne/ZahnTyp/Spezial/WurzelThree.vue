<template>
  <div class="wurzel-three">
    <div />
    <spezial-form />
    <spezial-form />
    <spezial-form />
  </div>
</template>

<script>
import SpezialForm from './SpezialForm.vue'
export default {
  name: "WurzelThree",
  components: {
    SpezialForm
  },
  data() {
    return {
    };
  }

}
</script>

<style scoped>
.wurzel-three{
  display: grid;
  grid-template-columns: 1fr 1fr 1fr 1fr 1fr;
}
</style>
