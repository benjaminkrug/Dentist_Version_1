<template>
  <div class="BehandlungCardStyle" >
    <div v-if="!cardOpen" @click="toggleCard">
      {{infos.first_Name}} {{infos.last_Name}}
    </div>
    <div v-if="cardOpen" class="Card">
      <div class="CardStyle" @click="toggleCard">
        <div>
          Vorname: {{infos.first_Name}}
        </div>
        <div>
          Nachname: {{infos.last_Name}}
        </div>
        <div>
          Geburtsdatum:
        </div>
        <div>
         {{infos.birthday.getDate() }}.{{infos.birthday.getMonth() +1 }}.{{infos.birthday.getFullYear()}}
        </div>
      </div>
      <div class="Actions">
        <b-icon icon="arrow90deg-right" variant="success" @click="moveBehandlung"></b-icon>
        <b-icon icon="info-circle"></b-icon>
        <b-icon icon="x-circle" variant="danger"></b-icon>
      </div>
    </div>
  </div>
</template>

<script>

import { mapMutations } from 'vuex'

export default {
  name:"WartezimmerCard",
  props: {
    infos: {}
  },
  data(){
    return{
      cardOpen: false
    }
  },
  methods:{
    ...mapMutations([
      'setTerminStatusToAbgeschlossen',
    ]),
    toggleCard(){
      this.cardOpen = !this.cardOpen
    },
    moveBehandlung(){
      this.setTerminStatusToAbgeschlossen(this.infos)
    }
  }
}
</script>

<style scoped>
.BehandlungCardStyle{
  border-style: groove;
  border-radius: 8px;
}
.Card{
}
.CardStyle{
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  grid-template-rows: repeat(3, 1fr);
}
.CardStyle > div{
  margin: 5px;
}
.Actions{
  grid-column: 1/ span 2;
  grid-row: 3;
  border-top: beige;
  border-top-style: ridge;
}
.Actions > svg{
  margin-right: 10px;
  margin-left: 10px;
}
</style>
