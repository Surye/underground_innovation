<template>
  <div>
    <b-row>
        <b-breadcrumb :items="items"/>
    </b-row>
    <b-form-checkbox plain v-model="my_projects"> Only Show My Projects</b-form-checkbox>
    <ProjectsSummaryPanel :project="project" v-for="project in filteredProjects" :key="project.project_id" />

    <b-modal ref="addProject" size="lg" center hide-footer title="Create new Project.">
      <ProjectCreatePanel/>
      <b-btn class="mt-3" variant="outline-danger" block @click="hideProjectsAdd">Cancel</b-btn>
    </b-modal>

    <fab
      :position="fab.position"
      :bg-color="fab.bgColor"
      :actions="fab.fabActions"
      @addProject="showProjectsAdd"
    ></fab>
  </div>
</template>

<script>
import ProjectsSummaryPanel from './projects-summary-panel'
import ProjectCreatePanel from './projects-create-panel'
import fab from 'vue-fab'
export default {
  components: { ProjectsSummaryPanel, ProjectCreatePanel, fab },
  computed: {
    filteredProjects() {
      if(!this.my_projects) {
        return this.projects;
      } else {
        return this.projects.filter(proj => proj.member == true);
      }
    }
  },
  methods: {

    hideProjectsAdd () {
      this.$refs.addProject.hide()
    },
    showProjectsAdd () {
      this.$refs.addProject.show()
    }
  },
  data() {
    return {
      items: [{ text: 'Projects' }],
      fab: {
          bgColor: '#778899',
          position: 'bottom-right',
          fabActions: [
              {
                  name: 'addProject',
                  icon: 'note_add',
                  tooltip: 'Create new project.'
              }
          ]
        },
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
