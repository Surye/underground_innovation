<template>
<b-navbar toggleable="md" type="dark" variant="dark">

  <b-navbar-toggle target="nav_collapse"></b-navbar-toggle>

  <b-collapse is-nav id="nav_collapse">

    <b-navbar-nav class="navbar-center">
      <b-nav-item-dropdown text="Subject Areas">
        <b-dropdown-item href="#">Infantry</b-dropdown-item>
        <b-dropdown-item href="#">Mechanized</b-dropdown-item>
        <b-dropdown-item href="#">Logistics</b-dropdown-item>
        <b-dropdown-item href="#">Fire's</b-dropdown-item>
        <b-dropdown-item href="#">Intel</b-dropdown-item>
        <b-dropdown-item href="#">Ship2Shore</b-dropdown-item>
        <b-dropdown-item href="#">Communications</b-dropdown-item>
        <b-dropdown-item href="#">Cyber</b-dropdown-item>
      </b-nav-item-dropdown>
      <b-nav-item-dropdown text="Concepts">
        <b-dropdown-item href="#">List</b-dropdown-item>
        <b-dropdown-item href="#">Of</b-dropdown-item>
        <b-dropdown-item href="#">Published</b-dropdown-item>
        <b-dropdown-item href="#">Concepts</b-dropdown-item>
      </b-nav-item-dropdown>
      <b-nav-item-dropdown text="TDG">
        <b-dropdown-item href="#">List</b-dropdown-item>
        <b-dropdown-item href="#">Of</b-dropdown-item>
        <b-dropdown-item href="#">TDGs</b-dropdown-item>
      </b-nav-item-dropdown>
      <b-nav-item-dropdown text="MCWL">
        <b-dropdown-item href="#">FAD</b-dropdown-item>
        <b-dropdown-item href="#">Concepts and Plans</b-dropdown-item>
        <b-dropdown-item href="#">War Gaming</b-dropdown-item>
        <b-dropdown-item href="#">S&amp;T</b-dropdown-item>
        <b-dropdown-item href="#">FTB</b-dropdown-item>
      </b-nav-item-dropdown>
      <b-nav-item-dropdown text="Warfare Centers">
        <b-dropdown-item href="#">ONR</b-dropdown-item>
        <b-dropdown-item href="#">MCWL</b-dropdown-item>
        <b-dropdown-item href="#">NRL</b-dropdown-item>
        <b-dropdown-item href="#">NSWC Crane</b-dropdown-item>
        <b-dropdown-item href="#">NSWC Carterock</b-dropdown-item>
        <b-dropdown-item href="#">NSWC Indianhead</b-dropdown-item>
      </b-nav-item-dropdown>
    </b-navbar-nav>

    <!-- Right aligned nav items -->
    <b-navbar-nav class="ml-auto">
      <b-nav-item-dropdown right>
        <!-- Using button-content slot -->
        <template slot="button-content">
          <em>User</em>
        </template>
        <b-dropdown-item href="#">Profile</b-dropdown-item>
        <b-dropdown-item href="#">Signout</b-dropdown-item>
      </b-nav-item-dropdown>
    </b-navbar-nav>

  </b-collapse>
</b-navbar>
</template>

<script>

export default {
    data() {
    }
}
</script>

<style scoped>
  .navbar-center {
    z-index: 100;
    left: 50%;
  }
</style>
