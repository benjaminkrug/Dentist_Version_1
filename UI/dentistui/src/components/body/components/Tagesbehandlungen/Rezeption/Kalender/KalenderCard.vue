<template>
  <div class="KalenderCardStyle" >
    <div v-if="!cardOpen" class="ClosedCardStyle" @click="toggleCard">
      <div class="StatusColor" :style="'background-color:' + CardColor">
      </div>
      {{infos.first_Name[0]}}.{{infos.last_Name}} ({{ infos.typ_short }})
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
        <div>
          Status: {{infos.status}}
        </div>
        <div>
          {{infos.typ_long}}
        </div>
      </div>
      <div class="Actions">
        <b-icon v-if="infos.status == 'ausstehend'" icon="arrow90deg-right" variant="success" @click="moveWartezimmer"></b-icon>
        <b-icon icon="info-circle" @click="showPatient(infos.userId)"></b-icon>
        <b-icon v-if="infos.status == 'ausstehend'" icon="x-circle" variant="danger"></b-icon>
      </div>
    </div>
  </div>
</template>

<script>

import { mapState, mapActions, mapMutations } from 'vuex'

export default {
  name:"KalenderCard",
  components: {
  },
  props: {
    infos: {}
  },
  data(){
    return{
      cardOpen: false
    }
  },
  computed: {
    ...mapState({
    }),
    CardColor(){
      switch(this.infos.status){
        case 'wartezimmer':{
          return 'yellow'
        }
        case 'inBehandlung':{
          return 'red'
        }
        case 'abgeschlossen':{
          return 'green'
        }
        case 'ausstehend':{
          return 'grey'
        }
      }
      return 'red'
    }
  },
  methods:{
    ...mapMutations([
      'setSelectedPatientId',
    ]),
    ...mapActions([
      'setTerminStatusToWartezimmer',
    ]),
    toggleCard(){
      this.cardOpen = !this.cardOpen
    },
    moveWartezimmer(){
      this.cardOpen = false;
      this.setTerminStatusToWartezimmer(this.infos)
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

}
.Card{
  border-style: groove;
  border-radius: 8px;
}
.CardStyle{
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  grid-template-rows: repeat(3, 1fr);
}
.CardStyle > div{
  margin: 5px;
}
.ClosedCardStyle{
  display: flex;
  align-items: center;
  justify-content: center;
  flex-direction: row;
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
.StatusColor{
  width: 4px;
  height: 14px;
  margin-right: 5px;
}
</style>
