<template>
  <div id="app">
    <b-container fluid>
      <b-row>
        <b-col>
          <nav-menu params="route: route"></nav-menu>
        </b-col>
      </b-row>
      <b-row class="main-content">
        <b-col cols="2">
          <side-bar></side-bar>
        </b-col>
        <b-col cols="10">
          <router-view class="mt-2"></router-view>
        </b-col>
      </b-row>
    </b-container>
  </div>
</template>

<script>
  import NavMenu from './NavMenus/nav-menu'
  import SideBar from './side-bar'

  export default {
    components: { NavMenu, SideBar },
    data() {
      return {
      }
    }
  }
</script>

<style scoped>

</style>
