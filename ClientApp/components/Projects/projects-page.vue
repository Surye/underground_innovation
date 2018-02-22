<template>
  <div>
    <b-row>
        <b-breadcrumb :items="items"/>
    </b-row>
    <b-form-checkbox plain v-model="my_projects"> Only Show My Projects</b-form-checkbox>
    <ProjectsSummaryPanel @join="joinedProject" :member="isMember(project)" :project="project" v-for="project in filteredProjects" :key="project.id" />

    <b-modal ref="addProject" size="lg" center hide-footer title="Create new Project.">
      <ProjectCreatePanel ref="addProjectPanel" @save="saveAddProject"/>
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
  import {HTTP} from '../../http-common';


  export default {
    components: { ProjectsSummaryPanel, ProjectCreatePanel, fab },
    computed: {
      filteredProjects() {
        if(!this.my_projects) {
          return this.projects
        } else {
          return this.projects.filter(proj => this.isMember(proj) == true)
        }
      }
    },
    methods: {
      saveAddProject (proj) {
        this.projects.push(proj)
        this.hideProjectsAdd()
        this.scrollToBottom = true
      },
      hideProjectsAdd () {
        this.$refs.addProject.hide()
      },
      showProjectsAdd () {
        this.$refs.addProjectPanel.reset()
        this.$refs.addProject.show()
      },
      isMember (project) {
        var userId = '13dc3112-2427-4275-bcad-368021f01a2b'
        for(var member of project.projectMembers) {
          if(member.userId == userId) {
            return true
          }
        }
        return false
      },
      joinedProject (project) {
        for(var idx in this.projects) {
          if(this.projects[idx].id == project.id) {
            this.projects.splice(idx, 1, project)
            this.$toasted.success('Joined project '+project.title+'!', {duration: 2000})
          }
        }
      }
    },
    updated () {
      if (this.scrollToBottom) {
        window.scrollTo(0,document.body.scrollHeight)
        this.scrollToBottom = false
      }
    },
    data() {
      return {
        scrollToBottom: false,
        projects: [],
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
        my_projects: false
      }
    },
    async created() {
      const response = await HTTP.get('/api/Project/')
      this.projects = response.data
    }
  }

</script>

<style>
</style>
