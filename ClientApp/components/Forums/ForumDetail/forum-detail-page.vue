<template>
    <div>
      <b-row>
          <b-breadcrumb :items="items"/>
      </b-row>
      <b-row>
        <b-col centered cols="8">
          <ForumPostDetail :forum='forum'/>
        </b-col>
      </b-row>
      <template v-for="reply in forum.replies">
        <b-row :key='"reply.type" + reply.id'>
          <b-col center cols="8">
            <ForumPostReply v-if="reply.type == 'reply'" :reply='reply.reply'/>
            <PollDisplayPanel v-if="reply.type == 'poll'" :poll='reply.poll' :forumId="$route.params.forum_id"/>
          </b-col>
        </b-row>
      </template>

      <fab
        :position="fab.position"
        :bg-color="fab.bgColor"
        :actions="fab.fabActions"
        @addReply="showReplyAdd"
        @addPollReply="showPollsAdd" />

      <b-modal ref="addPoll" size="lg" center hide-footer title="Add new poll reply.">
        <PollCreatePanel ref='newPoll' @save="savePoll" />
        <b-btn class="mt-3" variant="outline-danger" block @click="hidePollsAdd">Cancel</b-btn>
      </b-modal>

      <b-modal ref="addReply" size="lg" center hide-footer title="Add new reply.">
        <ReplyCreatePanel ref='newReply' @save="saveReply" />
        <b-btn class="mt-3" variant="outline-danger" block @click="hideReplyAdd">Cancel</b-btn>
      </b-modal>
    </div>
</template>

<script>
  import ForumPostDetail from './forum-post-detail'
  import ForumPostReply from './forum-post-reply'
  import PollCreatePanel from '../../Polls/poll-create-panel'
  import ReplyCreatePanel from './reply-create-panel'
  import PollDisplayPanel from '../../Polls/poll-display-panel'
  import {HTTP} from '../../../http-common'
  import fab from 'vue-fab'

  export default {
    components: {ForumPostDetail, ForumPostReply, ReplyCreatePanel, PollCreatePanel, PollDisplayPanel, fab},
    asyncComputed: {
      async project () {
        const response = await HTTP.get('/api/Project/' + this.$route.params.project_id)
        var project = response.data
        return project
      },
      async forum () {
        const response = await HTTP.get('/api/Forum/' + this.$route.params.forum_id)
        var forum = response.data
        console.log(forum)
        return forum
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
          to: { name: 'project_forums', params: { project_id: this.$route.params.project_id } }
        }, {
          text: this.forum.title,
          active: true
        }]
      }
    },
    data () {
      return {
        scrollToBottom: false,
        fab: {
          bgColor: '#778899',
          position: 'bottom-right',
          fabActions: [
              {
                  name: 'addReply',
                  icon: 'note_add',
                  tooltip: 'Add new reply to forum.'
              },
              {
                  name: 'addPollReply',
                  icon: 'playlist_add',
                  tooltip: 'Add new poll to forum.'
              }
          ]
        }
      }
    },
    methods: {
      hideReplyAdd () {
        this.$refs.addReply.hide()
      },
      showReplyAdd () {
        this.$refs.newReply.reset()
        this.$refs.addReply.show()
      },
      hidePollsAdd () {
        this.$refs.addPoll.hide()
      },
      showPollsAdd () {
        this.$refs.newPoll.reset()
        this.$refs.addPoll.show()
      },
      savePoll (poll) {
        this.scrollToBottom = true
        this.forum.replies.push({type:'poll', poll})
        this.hidePollsAdd()
      },
      saveReply (reply) {
        this.scrollToBottom = true
        this.forum.replies.push({type:'reply', reply})
        this.hideReplyAdd()
      }
    },
    async created () {
      const response = await HTTP.get('/api/Forum/'+this.$route.params.forum_id)
      this.forum = response.data
    },
    updated () {
      if (this.scrollToBottom) {
        window.scrollTo(0,document.body.scrollHeight)
        this.scrollToBottom = false
      }
    },
  }
</script>

<style>
</style>
