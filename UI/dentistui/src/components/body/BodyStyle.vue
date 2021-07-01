<template>
  <div class="BodyStyle">
    <router-view></router-view>
  </div>
</template>

<script>
export default {
  data() {
    return {
      test: 'test'
    }
  }
}
</script>

<style scoped>
.BodyStyle{
  width: 100%;
}
</style>
