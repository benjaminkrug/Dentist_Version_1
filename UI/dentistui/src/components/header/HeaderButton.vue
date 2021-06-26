<template>
  <li class="nav-item">
    <button class="btn btn-sm btn-outline-secondary" type="button">{{ text }}</button>
  </li>
</template>

<script>
export default {
  props:{
    text:String
  },
  components: {
  }
}
</script>

<style scoped>
</style>
