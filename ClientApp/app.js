import Vue from 'vue'
import axios from 'axios'
import router from './router'
import store from './store'
import 'babel-polyfill'
import { sync } from 'vuex-router-sync'
import App from 'components/app-root'
import BootstrapVue from 'bootstrap-vue'
import VuePaginate from 'vue-paginate'
import VueScrollTo from 'vue-scrollto'
import Toasted from 'vue-toasted'
import AsyncComputed from 'vue-async-computed'
import VueMoment from 'vue-moment'


import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

Vue.use(VuePaginate)
Vue.use(BootstrapVue)
Vue.use(VueScrollTo)
Vue.use(Toasted)
Vue.use(AsyncComputed)
Vue.use(VueMoment);


sync(store, router)

const app = new Vue({
  store,
  router,
  ...App
})

export {
  app,
  router,
  store
}
