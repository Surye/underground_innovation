<template>
<div>
    <b-row>
    <b-breadcrumb :items="items"/>
    </b-row>
    <b-jumbotron header="Drone Lunch Delivery" lead="Project to develop a drone that can deliver lunch to people out in the field."></b-jumbotron>
    <b-card-group deck>
        <b-card header-tag="h3" 
                header="Forums"
                bg-variant="dark"
                text-variant="white"
                img-src="https://thecareforum.co.uk/wp-content/uploads/2016/09/Forums-vs-Expos-image-MICROSITE.jpg">
            <dl>
            <dt>Total Active Forums:</dt> <dd>25</dd>
            <dt>Last Update:</dt> <dd>5 minutes ago</dd>
            </dl>
            <div class="go-button"><b-button size="lg" variant="primary">Visit Forums</b-button></div>
        </b-card>

        <b-card header-tag="h3" 
                header="Polls"
                bg-variant="dark"
                text-variant="white"
                img-src="https://elearningindustry.com/wp-content/uploads/2016/07/4-reasons-social-polls-online-learning.jpg">
                <dl>
                    <dt>Total Polls:</dt> <dd>12</dd>
                    <dt>Last Update:</dt> <dd>1 day ago</dd>
                </dl>
                <div class="go-button"><b-button size="lg" variant="primary">Visit Polls</b-button></div>
        </b-card>

        <b-card header-tag="h3" 
                header="Project Members"
                bg-variant="dark"
                text-variant="white"
                img-src="http://www.steinbergsports.com/wp-content/uploads/2013/09/team.jpg">
                <dl>
                    <dt>Total Members:</dt> <dd>22</dd>
                    <dt>Total Moderators:</dt> <dd>2</dd>
                </dl>
                <div class="go-button"><b-button size="lg" variant="primary">View Member List</b-button></div>
        </b-card>
    </b-card-group>
  </div>
</template>


<script> 
export default {
  data() {
    return {
items: [{
        text: 'Projects',
        to: { name: 'projects' }
      }, {
        text: 'Drone Lunch Delivery' // This will be dynamic based on the project we're in
      }]
    }
  }
}

</script>

<style scoped>
div.go-button {
    float: right;
}

dl {
    float: left;
}
</style>