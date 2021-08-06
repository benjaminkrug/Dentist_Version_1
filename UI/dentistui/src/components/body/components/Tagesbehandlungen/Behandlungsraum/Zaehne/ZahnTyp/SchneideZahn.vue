<template>
  <div class="all">
  </div>
</template>

<script>
export default {
  name: "SchneideZahn",
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
  width: 100%;
  height: 100%;
}
</style>
