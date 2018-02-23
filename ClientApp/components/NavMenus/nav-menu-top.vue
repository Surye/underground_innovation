<template>
  <b-navbar toggleable="md" type="dark" variant="dark">

    <b-navbar-toggle target="nav_collapse"></b-navbar-toggle>
    <img src="/assets/images/logo.png" height="150px" alt="MCLW">


    <b-navbar-brand href="#" class="navbar-center">
      <h1>Innovation Underground</h1>
    </b-navbar-brand>


    <!-- Right aligned nav items -->
    <b-navbar-nav class="ml-auto">
      <img src="/assets/images/mc_logo.png" height="150px" alt="MCLW">
    </b-navbar-nav>
  </b-navbar>
</template>

<script>

export default {
    data() {
      return {}
    }
}
</script>

<style>
  .navbar-center {
    position: absolute;
    left: 50%;
    transform: translatex(-50%);
  }
</style>
