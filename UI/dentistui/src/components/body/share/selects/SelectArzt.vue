<template>
  <div class="select-patient">
    <v-select
      v-model="selected"
      :items="aerzteItems"
      item-text="text"
      item-value="id"
      :menu-props="{ top: true, offsetY: true }"
      label="Ärzte"
    ></v-select>
  </div>
</template>

<script>
import { mapState, mapActions } from 'vuex'

export default {
  name: "SelectArzt",
  props:{
    SelectArztId: String
  },
  components: {
  },
  data() {
    return {
      items: ['Foo', 'Bar', 'Fizz', 'Buzz'],
    };
  },
  computed:{
    ...mapState([
      'aerzte'
    ]),
    selected: {
      get() {
        return this.SelectArztId
      },
      set(v) {
        this.$emit('selectedArzt', v)
      }
    },
    aerzteItems() {
      return this.aerzte.map(p => {return {id: p.id, text: p.last_Name + ' '+ p.first_Name}});
    }
  },
  methods:{
    ...mapActions([
      'loadAllAerzte',
    ]),
  },
  watch: {
  },
  mounted() {
    this.loadAllAerzte()
  }
}
</script>

<style scoped>
</style>
