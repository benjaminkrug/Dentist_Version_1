<template>
  <div>
    <spezial-form :isUnterKiefer="isUnterKiefer" @AddBehandlung="$emit('AddBehandlung', 'wurzel-mitte')"/>
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
  },
  methods: {
  }

}
</script>

<style scoped>
</style>
