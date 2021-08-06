<template>
  <div class="spezial-border">
    <div class="spezial-form-top" v-bind:style="styleTop" />
    <div class="spezial-form-right" v-bind:style="styleRight" />
    <div class="spezial-form-left" v-bind:style="styleLeft" />
    <div class="spezial-form-bottom" v-bind:style="styleBottom" />
    <v-stage :config="configKonva">
      <v-layer>
        <v-ellipse :config="configInnerCircle" >
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
      configInnerCircle: {
        x: 11,
        y: 15,
        radiusX: 9,
        radiusY: 6,
        fill: "white",
        stroke: "black",
        strokeWidth: 1
      },
      top: 15,
      right: 20,
      left: 20,
      bottom: 15,
      color: 'white',
    }
  },
  computed:{
    styleTop() {

      return {
        borderTop: this.top + 'px solid ' + this.color,
        borderLeft: this.left + 'px solid transparent',
        borderRight: this.right + 'px solid transparent'
      }
    },
    styleRight() {
      return {
        borderTop: this.top + 'px solid transparent',
        borderRight: this.right + 'px solid ' + this.color,
        borderBottom: this.bottom + 'px solid transparent'
      }
    },
    styleLeft() {
      return {
        borderTop: this.top + 'px solid transparent',
        borderLeft: this.left + 'px solid ' + this.color,
        borderBottom: this.bottom + 'px solid transparent'
      }
    },
    styleBottom() {
      return {
        borderLeft: this.left + 'px solid transparent',
        borderRight: this.right + 'px solid transparent',
        borderBottom: this.bottom + 'px solid ' + this.color
      }
    },
  }
}
</script>

<style scoped>
.spezial-border {
  position: relative;
  margin-top: 3px;;
  margin-left: 1px;
}
.spezial-form-top{
  top: -1px;
  left: -9px;
  position: absolute;
  width: 0;
  height: 400px;
  border-radius: 72px / 63px;
}
.spezial-form-right{
  top: 0;
  left: -468px;
  position: absolute;
  width: 500px;
  height: 0;
  border-radius:72px / 63px;
}
.spezial-form-left{
  top: 0;
  left: -10px;
  position: absolute;
  width: 500px;
  height: 0;
  border-radius: 72px / 63px;
}
.spezial-form-bottom{
  top: -369px;
  left: -9px;
  position: absolute;
  width: 0;
  height: 400px;
  border-radius: 72px / 63px;
}
</style>
