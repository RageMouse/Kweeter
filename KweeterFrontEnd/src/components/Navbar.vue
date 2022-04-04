<template>
    <nav>
        <v-app-bar color="primary" dark prominent src="https://picsum.photos/1920/1080?random">
            <div class="d-flex align-center">
                <v-img
                    alt="Vuetify Logo"
                    class="shrink mr-2"
                    contain
                    src="https://cdn.vuetifyjs.com/images/logos/vuetify-logo-dark.png"
                    transition="scale-transition"
                    width="40"
                />

                <v-img
                    alt="Vuetify Name"
                    class="shrink mt-1 hidden-sm-and-down mr-2"
                    contain
                    min-width="100"
                    src="https://cdn.vuetifyjs.com/images/logos/vuetify-name-dark.png"
                    width="100"
                />
            </div>
            <v-tabs>
                <v-tab to="/">Home</v-tab>
                <v-tab to="/about">About</v-tab>
            </v-tabs>

            <v-spacer></v-spacer>

            <v-btn flat color="grey">
                <span>Sign Out</span>
                <v-icon right>mdi-export</v-icon>
            </v-btn>
        </v-app-bar>
    </nav>
</template>