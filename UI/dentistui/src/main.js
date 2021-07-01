import Vue from 'vue'
import Vuex from 'vuex'
import App from './App.vue'
import router from './router';
import axios from 'axios'
import VueAxios from 'vue-axios'
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import store from './Store'

// Add VuexStore
Vue.use(Vuex)

// Install BootstrapVue
Vue.use(BootstrapVue)
// Optionally install the BootstrapVue icon components plugin
Vue.use(IconsPlugin)

Vue.config.productionTip = false

// use axios
Vue.use(VueAxios, axios)

new Vue({
  router,
  store: store,
  render: h => h(App),
}).$mount('#app')
