<template>
    <nav>
        <v-toolbar app>
            <v-toolbar-side-icon></v-toolbar-side-icon>
                <v-toolbar-title class="gray--text">
                    GymLover
                </v-toolbar-title>
                <v-spacer></v-spacer>
                <v-btn flat color="grey">
                    <span>Sair</span>
                </v-btn>
        </v-toolbar>
        <v-navbar></v-navbar>
    </nav>
</template>
<script>
import { defineComponent } from '@vue/composition-api'

export default defineComponent({
    setup() {
        
    },
})
</script>
