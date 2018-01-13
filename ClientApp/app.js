import Vue from 'vue'
import axios from 'axios'
import router from './router'
import store from './store'
import 'babel-polyfill'
import { sync } from 'vuex-router-sync'
import App from 'components/app-root'
import BootstrapVue from 'bootstrap-vue'

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
 

Vue.use(BootstrapVue);
Vue.prototype.$http = axios;

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
