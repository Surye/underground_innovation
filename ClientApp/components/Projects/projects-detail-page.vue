<template>
<div>
    <b-row>
    <b-breadcrumb :items="items"/>
    </b-row>
    <b-jumbotron :header="project.title" :lead="project.description"></b-jumbotron>
    <b-card-group deck>
        <b-card header-tag="h3"
                header="Forums"
                bg-variant="dark"
                text-variant="white"
                img-src="https://thecareforum.co.uk/wp-content/uploads/2016/09/Forums-vs-Expos-image-MICROSITE.jpg">
            <dl>
            <dt>Total Active Forums:</dt> <dd>{{project.forums.length}}</dd>
            <dt>Last Update:</dt> <dd>5 minutes ago</dd>
            </dl>
            <div class="go-button"><b-button size="lg" variant="primary" :to="{ name: 'project_forums', params: { project_id: project.id }}">Visit Forums</b-button></div>
        </b-card>

        <b-card header-tag="h3"
                header="Polls"
                bg-variant="dark"
                text-variant="white"
                img-src="https://elearningindustry.com/wp-content/uploads/2016/07/4-reasons-social-polls-online-learning.jpg">
                <dl>
                    <dt>Total Polls:</dt> <dd>{{project.polls.length}}</dd>
                    <dt>Last Update:</dt> <dd>1 day ago</dd>
                </dl>
                <div class="go-button"><b-button size="lg" variant="primary" :to="{ name: 'project_polls', params: { project_id: project.id }}">Visit Polls</b-button></div>
        </b-card>

        <b-card header-tag="h3"
                header="Project Members"
                bg-variant="dark"
                text-variant="white"
                img-src="http://www.steinbergsports.com/wp-content/uploads/2013/09/team.jpg">
                <dl>
                    <dt>Total Members:</dt> <dd>{{project.projectMembers.length}}</dd>
                    <dt>Total Moderators:</dt> <dd>{{project.projectMembers.filter(member => member.admin == true).length}}</dd>
                </dl>
                <div class="go-button"><b-button size="lg" variant="primary" :to="{ name: 'project_members', params: { project_id: project.id }}">View Member List</b-button></div>
        </b-card>
    </b-card-group>
  </div>
</template>


<script>
import {HTTP} from '../../http-common'
export default {
  asyncComputed: {
    async project () {
      const response = await HTTP.get('/api/Project/' + this.$route.params.project_id)
      var project = response.data
      return project
    },
    async items () {
      return [{
        text: 'Projects',
        to: { name: 'projects' }
      }, {
        text: this.project.title // This will be dynamic based on the project we're in
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
