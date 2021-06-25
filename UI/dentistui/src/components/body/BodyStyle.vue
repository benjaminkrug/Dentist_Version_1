<template>
  <div class="BodyStyle">
    Body
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

}
</style>
