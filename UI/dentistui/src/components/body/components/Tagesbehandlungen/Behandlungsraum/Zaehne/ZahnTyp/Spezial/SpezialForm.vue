<template>
  <div class="spezial-form">
    <v-stage ref="stage" :config="stageSize">
      <v-layer>
        <v-line :config="{
          x: 0,
          y: 3,
          points: [
          16, 35,
          16,25,
          12, 2,
          10, 1,
          8, 2,
          4, 25,
          4, 35,
          ],
          tension: 0,
          closed: true,
          stroke: 'black',
          fill: 'white',
        }"/>
      </v-layer>
      <v-layer ref="dragLayer"></v-layer>
    </v-stage>
  </div>
</template>

<script>
export default {
  name: "SpezialForm",
  data() {
    return {
      stageSize: {
        width: 17,
        height:40
      }
    };
  }

}
</script>

<style scoped>
.spezial-form{
  display: flex;
  justify-content: center;
  margin-left: -3px;
  z-index: 1;
}
.spezial-form >*{
}
.top{
  margin-left:2px;
  width: 2px;
  border-left: 2px solid transparent;
  border-right: 2px solid transparent;
  border-bottom: 1px solid green;
}
.mid{
  width: 8px;
  border-left: 2px solid transparent;
  border-right: 2px solid transparent;
  border-bottom: 2px solid red;
}
.bottom{
  margin-left:-2px;
  width: 12px;
  border-left: 2px solid transparent;
  border-right: 2px solid transparent;
  border-bottom: 20px solid green;
}

.box{
}
</style>
