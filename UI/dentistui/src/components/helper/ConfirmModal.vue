<template>
  <div>
    <b-modal v-model="visible" :title="title" @ok="ok" @close="cancel" >
      {{ text }}
    </b-modal>
  </div>
</template>

<script>
import { mapActions } from 'vuex'

export default {
  name: "ConfirmModal",
  props:{
    modalShow: {
      type: Boolean,
      default: false
    },
    title: {
      type: String,
      default: "Titel"
    },
    text: {
      type: String,
      default: "Inhalt"
    }
  },
  components: {
  },
  data() {
    return {
      visible: false,
      resolvePromise: undefined,
      rejectPromise: undefined,
    };
  },
  computed:{
    internModalShow:{
      get(){
        return this.modalShow
      },
      set(){
      }
    }
  },
  methods:{
    ...mapActions([
    ]),
    show() {
      this.visible= true
      // Return promise so the caller can get results
      return new Promise((resolve, reject) => {
          this.resolvePromise = resolve
          this.rejectPromise = reject
      })
    },
    hide(){
      this.visible= false
    },
    ok() {
      this.hide()
      this.resolvePromise(true)
      this.$emit('ok')
    },
    cancel() {
      this.hide()
      this.resolvePromise(false)
      this.$emit('cancel')
    }
  },
  watch: {
  }
}
</script>

<style scoped>
</style>
