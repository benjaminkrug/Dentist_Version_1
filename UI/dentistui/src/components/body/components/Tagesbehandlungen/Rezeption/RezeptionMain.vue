<template>
  <div class="Fill">
    <h1>Rezeption</h1>
    <div class="RezeptionStyle">
      <div class="calender box">
        <kalender />
      </div>
      <v-card>
        <v-navigation-drawer
          v-model="drawer"
          :mini-variant.sync="mini"
          right
        >
          <v-list-item class="px-2">
            <v-btn
              icon
              @click.stop="mini = !mini"
            >
              <v-icon>mdi-chevron-left</v-icon>
            </v-btn>
          </v-list-item>

          <v-divider></v-divider>
          <v-list-item
            key="wartezimmer"
            link
          >
            <v-list-item-icon v-if="mini">
              <v-icon>mdi-human-male-female-child</v-icon>
              <div class="counter" v-if="kundenInWartezimmerCount > 0">
                {{ kundenInWartezimmerCount }}
              </div>
            </v-list-item-icon>
            <v-list-item-content>
              <v-list-item-title>
                <div class="wartezimmer">
                  <wartezimmer />
                </div>
              </v-list-item-title>
            </v-list-item-content>
          </v-list-item>
          <v-list-item
            key="behandlung"
            link
          >
            <v-list-item-icon v-if="mini">
              <v-icon>mdi-account-hard-hat</v-icon>
              <div class="counter" v-if="kundenInBehandlungCount > 0">
                {{ kundenInBehandlungCount }}
              </div>
            </v-list-item-icon>
            <v-list-item-content>
              <v-list-item-title>
                <div class="behandlung">
                  <behandlung />
                </div>
              </v-list-item-title>
            </v-list-item-content>
          </v-list-item>
        </v-navigation-drawer>
      </v-card>
    </div>
  </div>
</template>

<script>

import { mapGetters } from 'vuex'

import kalender from './Kalender/KalenderMain.vue'
import wartezimmer from './Wartezimmer/WartezimmerMain.vue'
import behandlung from './Behandlung/BehandlungMain.vue'

export default {
  name: "Rezeption",
  components:{
    kalender,
    wartezimmer,
    behandlung
  },
  data () {
    return {
        drawer: true,
        mini: true
      }
  },
  computed: {
    ...mapGetters([
      'kundenInWartezimmerCount',
      'kundenInBehandlungCount',
    ])
  },
}
</script>

<style scoped>
.Fill{
  width: 100%;
  height: 100vh;
}
.RezeptionStyle{
  position: fixed;
  top: 125px;
  left: 0;
  right: 0;
  bottom: 0;

  display: flex;
}
.box{
  margin: 10px;
  border-style: solid;
  border-color: black;
}
.calender {
  width: 98%;
  grid-column: 1;
  grid-row: 1 / span 2;
  overflow-y: hidden;
}
.wartezimmer{
  grid-column: 2;
  grid-row: 1;
}
.behandlung{
  grid-column: 2;
  grid-row: 2;
}
.sidebar{
  position: fixed;
}
.counter{
  position: fixed;
  left: 30px;
  margin-top: 15px;
  color: red;
  width: 25px;
  border: 1px solid red;
  border-radius: 30px;
}
</style>
