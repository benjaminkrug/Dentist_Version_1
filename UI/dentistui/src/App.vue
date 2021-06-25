<template>
  <div id="app">
    <main-style />
  </div>
</template>

<script>
import MainStyle from './components/MainStyle.vue'

export default {
  name: 'App',
  components: {
    MainStyle
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
