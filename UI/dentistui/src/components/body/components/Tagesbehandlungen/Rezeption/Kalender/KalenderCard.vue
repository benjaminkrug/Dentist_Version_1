<template>
  <div class="KalenderCardStyle">
    <div v-if="!cardOpen" @click="toggleCard">
      {{infos.first_Name[0]}}.{{infos.last_Name}}
    </div>
    <div v-if="cardOpen" class="Card">
      <div class="CardStyle" @click="toggleCard">
        <div>
          Vorname: {{infos.first_Name}} {{ count }}
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
        <b-icon icon="arrow90deg-right" variant="success" @click="moveWartezimmer"></b-icon>
        <b-icon icon="info-circle"></b-icon>
        <b-icon icon="x-circle" variant="danger"></b-icon>
      </div>
    </div>
  </div>
</template>

<script>

import { mapState, mapMutations } from 'vuex'

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
    // arrow functions can make the code very succinct!
      count: state => state.count,
    })
  },
  methods:{
    ...mapMutations([
      'increment', // map `this.increment()` to `this.$store.commit('increment')`
    ]),
    toggleCard(){
      this.cardOpen = !this.cardOpen
    },
    moveWartezimmer(){
      this.increment()
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
