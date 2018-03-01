<template>
    <div>
        <b-row>
            <b-breadcrumb :items="items"/>
        </b-row>
        <b-list-group>
          <MemberDisplayPanel v-for="member in project.projectMembers" :key='member.id' :member='member.user' />
        </b-list-group>
    </div>
</template>

<script>
import MemberDisplayPanel from './member-display-panel'
import {HTTP} from '../../http-common'

export default {
  components: { MemberDisplayPanel },
  asyncComputed: {
    async project () {
      const response = await HTTP.get('/api/Project/' + this.$route.params.project_id)
      var project = response.data
      console.log(project.projectMembers)
      return project
    },
    async items () {
      return [{
        text: 'Projects',
        to: { name: 'projects' }
      }, {
        text: this.project.title,
        to: { name: 'project_details', project_id: this.$route.params.project_id }
      }, {
        text: 'Forums',
        active: true
      }]
    }
  }
}


</script>

<style>
</style>
