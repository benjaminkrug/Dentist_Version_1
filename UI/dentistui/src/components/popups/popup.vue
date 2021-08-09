<template>
  <div>
    <b-modal :id="modalId" :title="title" @ok="$emit('ok')" @cancel="$emit('cancel')">
      <slot></slot>
    </b-modal>
  </div>
</template>

<script>
export default {
  name: "Popup",
  props:{
    modalId: String,
    title: String
  },
  components: {
  },
  data() {
    return {
    };
  },
  computed:{
  }

}
</script>

<style scoped>
</style>
