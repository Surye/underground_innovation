<template>
    <div>
        <b-row>
            <b-breadcrumb :items="items"/>
        </b-row>
        <b-checkbox v-model="my_projects"> Only Show My Projects</b-checkbox>
        <ProjectsSummaryPanel :project="project" v-for="project in filteredProjects" :key="project.project_id" />
    </div>
</template>

<script> 
import ProjectsSummaryPanel from './projects-summary-panel'
export default {
  components: { ProjectsSummaryPanel },
  computed: {
    filteredProjects() {
      if(!this.my_projects) {
        return this.projects;
      } else {
        return this.projects.filter(proj => proj.member == true);
      }
    }
  },
  data() {
    return {
      items: [{ text: 'Projects' }],
      my_projects: true,
      projects: [
        {
          project_id: 1,
          title: 'Drone Lunch Delivery',
          description: 'Project to develop a drone that can deliver lunch to people out in the field.',
          member: true
        },
        {
          project_id: 2,
          title: 'Xbox in Every Bunker',
          description: 'Aligning resources to ensure proper xbox distribution.',
          member: false
        }
      ]
    }
  }
}

</script>

<style>
</style>
