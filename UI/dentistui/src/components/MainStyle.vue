<template>
  <div class="MainStyle">
    <Header-style />
    <BodyStyle />
  </div>
</template>

<script>
import HeaderStyle from './header/HeaderStyle.vue'
import BodyStyle from './body/BodyStyle.vue'
export default {
  components: {
    HeaderStyle,
    BodyStyle
  }
}
</script>

<style scoped>
.MainStyle{
  display: flex;
  align-items: center;
  justify: center;
  flex-direction: column;
  position: fixed;
  margin: auto;
  top: 0;
  right: 0;
  bottom: 0;
  left: 0;
  margin: 0;
  box-sizing: border-box;
  width: 100%;
  height: 100%;
  object-fit: contain;
}
</style>
