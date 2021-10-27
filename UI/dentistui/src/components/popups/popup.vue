<template>
  <div>
    <b-modal :id="modalId" :title="title" @ok="ok" @cancel="$emit('cancel')" @hide="$emit('cancel')" @close="$emit('cancel')">
      <slot></slot>
      <div v-if="showAlert" class="error">
        <slot name="error"></slot>
      </div>
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
    show: {
      type: Boolean,
      default: false
    },
    showOnMounted: {
      type: Boolean,
      default: false
    },
    allowOk: {
      type: Boolean,
      default: true
    }
  },
  components: {
  },
  data() {
    return {
      showAlert: false
    };
  },
  methods: {
    ok(bvModalEvt){
      // Prevent modal from closing
      bvModalEvt.preventDefault()
      // Trigger submit handler
      this.handleSubmit()
    },
    handleSubmit() {
      // Exit when the form isn't valid
      if (!this.allowOk) {
        this.showAlert = true;
        return
      }
      this.$emit('ok')
      // Hide the modal manually
      this.$nextTick(() => {
        this.$bvModal.hide(this.modalId)
      })
    }
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
    },
    async showAlert(value){
      if(value){
        var v = this;
        setTimeout(function () {
            v.showAlert = false;
        }, 3000);
      }
    }
  },
  mounted(){
    if(this.modalId && this.showOnMounted){
      this.$bvModal.show(this.modalId)
    }
  }

}
</script>

<style scoped>
.popup{
  display: flex;
  flex-direction: column;
}
.popup > *{
  margin: 3px;
  border-style: hidden;
  border-bottom: 1px solid;
  width: 65%;
  border-radius: 0;
}
.error{
  color: red;
}
</style>
