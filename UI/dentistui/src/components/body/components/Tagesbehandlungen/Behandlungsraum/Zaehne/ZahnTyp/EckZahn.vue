<template>
  <div class="all">
  </div>
</template>

<script>
export default {
  name: "EckZahn",
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
  }

}
</script>

<style scoped>
.all{
  height: 100%;
}
</style>
