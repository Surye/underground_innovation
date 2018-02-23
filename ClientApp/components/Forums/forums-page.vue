<template>
  <div>
      <b-row>
          <b-breadcrumb :items="items"/>
      </b-row>
      <ForumsSummaryPanel v-for="forum in forums" :key="forum.id" :forum="forum"/>

      <b-modal ref="addForum" size="lg" center hide-footer title="Add new forum.">
        <ForumsCreatePanel ref='newForum' @save="saveAddForum" />
        <b-btn class="mt-3" variant="outline-danger" block @click="hideForumAdd">Cancel</b-btn>
      </b-modal>

      <fab
        :position="fab.position"
        :bg-color="fab.bgColor"
        :actions="fab.fabActions"
        @addForum="showForumAdd"/>
  </div>
</template>

<script>
import ForumsSummaryPanel from './forums-summary-panel'
import ForumsCreatePanel from './forums-create-panel'
import {HTTP} from '../../http-common'
import fab from 'vue-fab'

export default {
  components: { ForumsSummaryPanel, ForumsCreatePanel, fab },
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
        text: this.project.title,
        to: { name: 'project_details', project_id: this.$route.params.project_id }
      }, {
        text: 'Forums',
        active: true
      }]
    }
  },
  data() {
    return {
      forums: [],
      fab: {
        bgColor: '#778899',
        position: 'bottom-right',
        fabActions: [
            {
                name: 'addForum',
                icon: 'note_add',
                tooltip: 'Add new Forum to forum.'
            }
        ]
      }
    }
  },
  methods: {
    saveAddForum (forum) {
      this.forums.push(forum)
      this.hideForumAdd()
    },
    hideForumAdd () {
      this.$refs.addForum.hide()
    },
    showForumAdd () {
      this.$refs.newForum.reset()
      this.$refs.addForum.show()
    }
  },
  async created() {
    const response = await HTTP.get('/api/Forum/?projectId='+this.$route.params.project_id)
    this.forums = response.data
  }
}


</script>

<style>
</style>
