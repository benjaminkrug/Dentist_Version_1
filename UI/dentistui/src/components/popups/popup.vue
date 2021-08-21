<template>
  <div>
    <b-modal :id="modalId" :title="title" @ok="$emit('ok')" @cancel="$emit('cancel')" @close="$emit('cancel')">
      <slot></slot>
    </b-modal>
  </div>
</template>

<script>
export default {
  name: "Popup",
  props:{
    modalId: {
      type: String,
      default: ''
    },
    title: String,
    show:{
      type: Boolean,
      default: false
    },
  },
  components: {
  },
  data() {
    return {
    };
  },
  methods: {
  },
  computed:{
  },
  watch: {
    show(value){
      if(value){
        this.$bvModal.show(this.modalId)
      }
      else{
        this.$bvModal.hide(this.modalId)
      }
    }
  },
  mounted(){
  }

}
</script>

<style scoped>
</style>
