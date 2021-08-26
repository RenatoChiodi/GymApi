<template>
  <v-app class="grey lighten-4">
    <navbar />
    <v-main>
      <Home/>
    </v-main>
  </v-app>
</template>

<script>
import Home from './views/Home.vue'
import Navbar from './components/Navbar.vue'

export default {
  name: 'App',

  components: {
    Home,
    Navbar,
  },

  data: () => ({
    //
  }),
};
</script>
