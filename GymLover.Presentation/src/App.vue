<template>
  <v-app class="grey lighten-4">
    <navbar :rotas="routes"/>
    <transition name="pagina">
     
    </transition>
  </v-app>
</template>

<script>
import Navbar from './components/Navbar'
import {routes} from './routes';

export default {
  name: 'App',

  components: {
    Navbar
  },

  data: () => ({
   routes
  }),
};
</script>
