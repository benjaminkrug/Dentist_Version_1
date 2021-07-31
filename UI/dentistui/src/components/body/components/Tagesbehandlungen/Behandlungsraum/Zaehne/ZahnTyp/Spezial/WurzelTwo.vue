<template>
  <div class="wurzel-two">
    <div />
    <div />
    <spezial-form />
    <spezial-form />
  </div>
</template>

<script>
import SpezialForm from './SpezialForm.vue'
export default {
  name: "WurzelOne",
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
.wurzel-two{
  display: grid;
  grid-template-columns: 1fr 1fr 1fr 1fr 1fr 1fr;
}
</style>
