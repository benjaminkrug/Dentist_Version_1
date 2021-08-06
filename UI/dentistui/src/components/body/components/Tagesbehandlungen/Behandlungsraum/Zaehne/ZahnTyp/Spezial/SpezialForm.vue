<template>
  <div class="spezial-form">
    <v-stage ref="stage" :config="stageSize">
      <v-layer>
        <v-line :config="lineConfig"/>
      </v-layer>
      <v-layer ref="dragLayer"></v-layer>
    </v-stage>
  </div>
</template>

<script>
export default {
  name: "SpezialForm",
  props:{
    isUnterKiefer:{
      type: Boolean,
      default: false
    },
  },
  data() {
    return {
      stageSize: {
        width: 17,
        height:40
      }
    };
  },
  computed: {
    lineConfig(){
      var points= [
        16, 35,
        16,25,
        12, 2,
        10, 1,
        8, 2,
        4, 25,
        4, 35,
      ];
      var pointsUnterkiefer= [
        16, 1,
        16,12,
        12, 34,
        10, 35,
        8, 34,
        4, 12,
        4, 1,
      ];
      return {
        x: 0,
        y: 3,
        points: this.isUnterKiefer? pointsUnterkiefer: points,
        tension: 0,
        closed: true,
        stroke: 'black',
        fill: 'white',
      }
    }
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
