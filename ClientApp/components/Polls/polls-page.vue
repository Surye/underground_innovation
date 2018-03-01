<template>
    <div>
        <b-row>
            <b-breadcrumb :items="items"/>
        </b-row>
        <PollDisplayPanel v-for="poll in polls" :key="poll.id" :poll="poll"/>
        <fab
          :position="fab.position"
          :bg-color="fab.bgColor"
          :actions="fab.fabActions"
          @addPollReply="showPollsAdd"
        ></fab>

      <b-modal ref="addPoll" size="lg" center hide-footer title="Add new poll reply.">
        <PollCreatePanel ref="newPoll" @save="savePoll"/>
        <b-btn class="mt-3" variant="outline-danger" block @click="hidePollsAdd">Cancel</b-btn>
      </b-modal>
    </div>
</template>

<script>
import PollDisplayPanel from './poll-display-panel'
import PollCreatePanel from './poll-create-panel'

import fab from 'vue-fab'
import {HTTP} from '../../http-common'

export default {
  components: { PollDisplayPanel, fab, PollCreatePanel },
  methods:{
    savePoll (poll) {
      this.scrollToBottom = true
      this.polls.push(poll)
      this.hidePollsAdd()
    },
    hidePollsAdd () {
      this.$refs.addPoll.hide()
    },
    showPollsAdd () {
      this.$refs.newPoll.reset()
      this.$refs.addPoll.show()
    }
  },
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
        text: 'Polls',
        active: true
      }]
    }
  },
  async created() {
    const response = await HTTP.get('/api/Poll/?projectId='+this.$route.params.project_id)
    this.polls = response.data
  },
  data() {
    return {
      fab: {
        bgColor: '#778899',
        position: 'bottom-right',
        fabActions: [
          {
              name: 'addPollReply',
              icon: 'playlist_add',
              tooltip: 'Add new poll to forum.'
          }
        ]
      },
      polls: []
    }
  }
}


</script>

<style>
</style>
