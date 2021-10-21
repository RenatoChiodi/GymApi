import Vue from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify'
import 'roboto-fontface/css/roboto/roboto-fontface.css'
import '@mdi/font/css/materialdesignicons.css'
import VueRouter from 'vue-router';
import {routes} from './routes';
import VueResource from 'vue-resource';

Vue.use(VueResource);
Vue.http.options.root = 'http://localhost:51200';

Vue.config.productionTip = false
Vue.use(VueRouter);

const router = new VueRouter({
  routes,
  mode: 'history'
 });

new Vue({
  vuetify,
  router,
  render: h => h(App)
}).$mount('#app')
