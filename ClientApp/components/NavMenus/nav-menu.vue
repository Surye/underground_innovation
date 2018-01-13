<template>
  <div>
    <nav-menu-top></nav-menu-top>
    <nav-menu-bottom></nav-menu-bottom>
  </div>
</template>

<script>
import NavMenuTop from './nav-menu-top'
import NavMenuBottom from './nav-menu-bottom'

export default {
    components: { NavMenuTop, NavMenuBottom },
    data() {
        return {
        }
    },
}
</script>

<style>

  .navbar-center {
    position: absolute;
    left: 50%;
    transform: translatex(-50%);
  }
</style>
