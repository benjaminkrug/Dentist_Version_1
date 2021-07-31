<template>
  <div class="spezial-form">
    <v-stage class="inner" :config="configKonva">
      <v-layer>
        <v-ellipse :config="configInnerCircle" >
        </v-ellipse>
      </v-layer>
    </v-stage>
    <v-stage class="outa" :config="configKonvaLeft">
      <v-layer>
        <v-ellipse :config="configCircleLeft">
        </v-ellipse>
      </v-layer>
    </v-stage>
    <v-stage class="outa right" :config="configKonvaRight">
      <v-layer>
        <v-ellipse :config="configCircleRight">
        </v-ellipse>
      </v-layer>
    </v-stage>
  </div>
</template>

<script>
export default {
  name: "SpezialFormRound",
  data()  {
    return {
      configKonva: {
        width: 60,
        height: 35
      },
      configKonvaLeft: {
        width: 30,
        height: 35
      },
      configKonvaRight: {
        width: 30,
        height: 35
      },
      configCircleLeft: {
        x: 28,
        y: 17,
        radiusX: 25,
        radiusY: 16,
        fill: "red",
        stroke: "black",
        strokeWidth: 1
      },
      configCircleRight: {
        x: 0,
        y: 17,
        radiusX: 25,
        radiusY: 16,
        fill: "blue",
        stroke: "black",
        strokeWidth: 1
      },
      configInnerCircle: {
        x: 28,
        y: 17,
        radiusX: 10,
        radiusY: 6,
        fill: "white",
        stroke: "black",
        strokeWidth: 1
      },
    };
  }
}
</script>

<style scoped>
.spezial-form{
  position: relative;
}
.inner{
  position: absolute;
  top: 0;
  z-index: 3;
}
.outa{
  position: absolute;
  top: 0;
  z-index: 2;
}
.right{
  left: 30px;
}
</style>
