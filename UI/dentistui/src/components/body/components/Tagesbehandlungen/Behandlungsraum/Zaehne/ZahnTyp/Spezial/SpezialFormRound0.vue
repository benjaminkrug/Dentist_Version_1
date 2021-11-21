<template>
  <div class="spezial-border">
    <div class="spezial-form-top" v-bind:style="styleTop" >
      <div
        class="box-top"
        @mouseover="fillTop = 'yellow'" @mouseleave="fillTop = 'white'"
        @click="AddBehandlung('box-top')"
      />
    </div>
    <div class="spezial-form-right" v-bind:style="styleRight" >
      <div
        class="box-right" @mouseover="fillRight = 'yellow'" @mouseleave="fillRight = 'white'"
        @click="AddBehandlung('box-right')"
      />
    </div>
    <div class="spezial-form-left" v-bind:style="styleLeft" >
      <div
        class="box-left" @mouseover="fillLeft = 'yellow'" @mouseleave="fillLeft = 'white'"
        @click="AddBehandlung('box-left')"
     />
    </div>
    <div class="spezial-form-bottom" v-bind:style="styleBottom" >
      <div
        class="box-bottom" @mouseover="fillBottom = 'yellow'" @mouseleave="fillBottom = 'white'"
        @click="AddBehandlung('box-bottom')"
      />
    </div>
    <v-stage :config="configKonva">
      <v-layer>
        <v-ellipse :config="configInnerCircle" >
        </v-ellipse>
      </v-layer>
    </v-stage>
    <div class="hover-detection"
      @mouseover="configInnerCircle.fill = 'yellow'"
      @mouseleave="configInnerCircle.fill = 'white'"
      @click="AddBehandlung('box-mitte')"
    />
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
      fillTop: 'white',
      fillRight: 'white',
      fillLeft: 'white',
      fillBottom: 'white',
    }
  },
  computed:{
    styleTop() {
      return {
        borderTop: this.top + 'px solid ' + this.fillTop,
        borderLeft: this.left + 'px solid transparent',
        borderRight: this.right + 'px solid transparent'
      }
    },
    styleRight() {
      return {
        borderTop: this.top + 'px solid transparent',
        borderRight: this.right + 'px solid ' + this.fillRight,
        borderBottom: this.bottom + 'px solid transparent'
      }
    },
    styleLeft() {
      return {
        borderTop: this.top + 'px solid transparent',
        borderLeft: this.left + 'px solid ' + this.fillLeft,
        borderBottom: this.bottom + 'px solid transparent'
      }
    },
    styleBottom() {
      return {
        borderLeft: this.left + 'px solid transparent',
        borderRight: this.right + 'px solid transparent',
        borderBottom: this.bottom + 'px solid ' + this.fillBottom
      }
    },
  },
  methods: {
    AddBehandlung(position){
      this.$emit('AddBehandlung', position)
    }
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
.box-top{
  width: 15px;
  height: 10px;
  position: relative;
  left: -8px;
  top: -15px;
  z-index: 10;
}
.box-right{
  width: 11px;
  height: 16px;
  position: relative;
  left: 488px;
  top: -8px;
  z-index: 10;
}
.box-left{
  width: 12px;
  height: 14px;
  position: relative;
  left: -20px;
  top: -7px;
  z-index: 10;
}
.box-bottom{
  width: 18px;
  height: 8px;
  position: relative;
  left: -9px;
  top: 391px;
  z-index: 10;
}

.hover-detection{
  position: absolute;
  top: 10px;
  left: 5px;
  width: 12px;
  height: 12px;
  z-index: 30;
}
</style>
