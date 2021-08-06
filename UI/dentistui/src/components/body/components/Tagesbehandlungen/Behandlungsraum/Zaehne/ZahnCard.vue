<template>
  <div class="ZahnCard">
    <schneide-zahn v-if="type === 'SchneideZahn'" :zahn-style="zahnStyle" :wurzeln="wurzeln" :isUnterKiefer="isUnterKiefer" />
    <eck-zahn v-if="type === 'EckZahn'" :zahn-style="zahnStyle" :wurzeln="wurzeln" :isUnterKiefer="isUnterKiefer" />
    <vormahl-zahn v-if="type === 'VormahlZahn'" :zahn-style="zahnStyle" :wurzeln="wurzeln" :isUnterKiefer="isUnterKiefer" />
    <mahl-zahn v-if="type === 'MahlZahn'" :zahn-style="zahnStyle" :wurzeln="wurzeln" :isUnterKiefer="isUnterKiefer" />
    <weisheits-zahn v-if="type === 'WeisheitsZahn'" :zahn-style="zahnStyle" :wurzeln="wurzeln" :isUnterKiefer="isUnterKiefer" />
  </div>
</template>

<script>
import SchneideZahn from './ZahnTyp/SchneideZahn.vue'
import EckZahn from './ZahnTyp/EckZahn.vue'
import VormahlZahn from './ZahnTyp/VormahlZahn.vue'
import MahlZahn from './ZahnTyp/MahlZahn.vue'
import WeisheitsZahn from './ZahnTyp/WeisheitsZahn.vue'
export default {
  name: "Zahnecard",
  components: {
    SchneideZahn,
    EckZahn,
    VormahlZahn,
    MahlZahn,
    WeisheitsZahn
  },
  props:{
    zahnStyle: [],
    type:{
      type: String,
      default: 'SchneideZahn'
    },
    wurzeln:{
      type: Number,
      default: 1
    },
    isUnterKiefer:{
      type: Boolean,
      default: false
    },
  }

}
</script>

<style scoped>
.ZahnCard{
  width: 80px;
  height: 80px;
  background-color: aquamarine;
}
</style>
