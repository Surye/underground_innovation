<template>
  <b-nav vertical class="bg-dark h-100">
    <a class="nav-link bg-dark text-muted" href="#">Active</a>
    <a class="nav-link bg-dark text-muted" href="#">Home</a>
    <a class="nav-link bg-dark text-muted" href="#">Submissions</a>
    <a class="nav-link bg-dark text-muted" href="#">Top Topics</a>
    <a class="nav-link bg-dark text-muted" href="#">Ellis Group</a>
    <a class="nav-link bg-dark text-muted" href="#">Fellowship Program</a>
    <a class="nav-link bg-dark text-muted" href="#">'Gap List'</a>
    <a class="nav-link bg-dark text-muted" href="#">User Accounts</a>
    <a class="nav-link bg-dark text-muted" href="#">POC's</a>
    <a class="nav-link bg-dark text-muted" href="#">Ellis Group</a>
  </b-nav>
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

<style scoped>

</style>
