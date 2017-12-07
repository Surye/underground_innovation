<template>
    <div class="main-nav">
        <div class="navbar navbar-inverse">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" v-on:click="toggleCollapsed">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="hidden-xs navbar-brand" href="/">
                    <img src="/assets/images/logo.png" width="150" height="150" alt="" />
                    Underground Innovation
                </a>
                <a class="visible-xs navbar-brand" href="/">
                    Underground Innovation
                </a>
            </div>

            <div class="clearfix"></div>


            <div v-if="isLoggedIn()">
                <transition name="slide">
                    <div class="navbar-collapse collapse in" v-show="!collapsed">
                        <ul class="nav navbar-nav">
                            <li v-for="route in loggedInRoutes">
                                <!-- TODO: highlight active link -->
                                <router-link :to="route.path">
                                    <span :class="route.style"></span> {{ route.display }}
                                </router-link>
                            </li>
                        </ul>
                    </div>
                </transition>
            </div>
            <div v-else>
                <transition name="slide">
                    <div class="navbar-collapse collapse in" v-show="!collapsed">
                        <ul class="nav navbar-nav">
                            <li v-for="route in loggedOutRoutes">
                                <!-- TODO: highlight active link -->
                                <router-link :to="route.path">
                                    <span :class="route.style"></span> {{ route.display }}
                                </router-link>
                            </li>
                        </ul>
                    </div>
                </transition>
            </div>
        </div>
    </div>
</template>

<script>
    import { routes } from '../routes'
    import { isLoggedIn } from '../auth'

export default {
    data() {
        return {
            loggedInRoutes: routes.filter(route => route.beforeEnter),
            loggedOutRoutes: routes.filter(route => !route.beforeEnter),
            isLoggedIn,
            collapsed : true
        }
    },
    methods: {
        toggleCollapsed: function(event){
            this.collapsed = !this.collapsed;
        }
    }
}
</script>

<style>
    .slide-enter-active, .slide-leave-active {
      transition: max-height .35s
    }
    .slide-enter, .slide-leave-to {
      max-height: 0px;
    }

    .slide-enter-to, .slide-leave {
      max-height: 20em;
    }

    .hidden-xs.navbar-brand {
        height: 190px;
    }
</style>
