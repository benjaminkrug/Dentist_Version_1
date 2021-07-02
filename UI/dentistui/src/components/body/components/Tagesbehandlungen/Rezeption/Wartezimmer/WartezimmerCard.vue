<template>
  <div class="KalenderCardStyle" >
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
        <b-dropdown variant="link" no-caret>
          <template #button-content class="dropdown-button">
            <b-icon icon="arrow90deg-right" variant="success" ></b-icon>
          </template>
          <b-dropdown-item @click="moveBehandlung('1')">Behandlungsraum 1</b-dropdown-item>
          <b-dropdown-item @click="moveBehandlung('2')">Behandlungsraum 2</b-dropdown-item>
          <b-dropdown-item @click="moveBehandlung('3')">Behandlungsraum 3</b-dropdown-item>
        </b-dropdown>
        <b-icon icon="info-circle" @click="showPatient(infos.userId)"></b-icon>
        <b-icon icon="x-circle" variant="danger"></b-icon>
      </div>
    </div>
  </div>
</template>

<script>

import { mapActions, mapMutations } from 'vuex'

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
      'setSelectedPatientId',
    ]),
    ...mapActions([
      'setTerminStatusToInBehandlung',
    ]),
    toggleCard(){
      this.cardOpen = !this.cardOpen
    },
    moveBehandlung(raum){
      this.infos.raum = raum;
      this.setTerminStatusToInBehandlung(this.infos)
    },
    showPatient(id){
      this.setSelectedPatientId(id)
      this.$router.push('/Patient')
    }
  }
}
</script>

<style scoped>
.KalenderCardStyle{
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
svg{
  font-size: 100%;
  vertical-align: text-top;
}
</style>
