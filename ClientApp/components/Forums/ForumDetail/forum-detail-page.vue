<template>
    <div>
      <b-row>
          <b-breadcrumb :items="items"/>
      </b-row>
      <b-row>
        <ForumPostDetail :forum='forum'/>
      </b-row>
      <template v-for="reply in replies">
        <b-row :key='reply.id'>
          <ForumPostReply :reply='reply' :key='reply.id'/>
        </b-row>
      </template>

      <fab
        :position="fab.position"
        :bg-color="fab.bgColor"
        :actions="fab.fabActions"
        @cache="cache"
        @alertMe="alert"
        @addPollReply="showPollsAdd"
      ></fab>

      <b-modal ref="addPoll" size="lg" center hide-footer title="Add new poll reply.">
        <PollCreatePanel/>
        <b-btn class="mt-3" variant="outline-danger" block @click="hidePollsAdd">Cancel</b-btn>
      </b-modal>
    </div>
</template>

<script>
  import ForumPostDetail from './forum-post-detail'
  import ForumPostReply from './forum-post-reply'
  import PollCreatePanel from '../../Polls/poll-create-panel'
  import fab from 'vue-fab'

  export default {
    components: {ForumPostDetail, ForumPostReply, PollCreatePanel, fab},
    computed: {
      items () {
        return  [{
          text: 'Projects',
          to: { name: 'projects' }
        }, {
          text: 'Drone Lunch Delivery', // This will be dynamic based on the project we're in
          to: { name: 'project_details', params: { project_id: this.$route.params.project_id } }
        }, {
          text: 'Forums',
          to: { name: 'project_forums', params: { project_id: this.$route.params.project_id } }
        }, {
          text: this.forum.title,
          active: true
        }]
      }
    },
    data() {
      return {
        forum: { // Fake data generated with: https://next.json-generator.com/NyYdzo2LV
          "id": 0,
          "title": "Aliquip non laboris magna laborum dolore ea.",
          "author": "Trevino",
          "content": "Laborum fugiat ea irure nulla. Cupidatat excepteur exercitation culpa cupidatat ut sunt. Voluptate nisi eiusmod in ut ut magna incididunt laboris elit est aliqua ex. Fugiat pariatur deserunt in laboris aliquip ullamco est mollit id aliquip nulla. Id occaecat ipsum excepteur consectetur consectetur in fugiat Lorem velit non eu esse. Irure pariatur occaecat pariatur reprehenderit consequat aliquip.",
          "unread": false,
          "create_time": "Saturday, July 18, 2015 3:31 AM"
        },
        replies: [
          {
            "id": 0,
            "author": "Desiree",
            "create_time": "Saturday, November 26, 2016 5:04 PM",
            "content": "Exercitation excepteur sint excepteur aliquip excepteur pariatur quis magna culpa cupidatat. Commodo ullamco magna nulla culpa cillum Lorem labore nisi do. Excepteur qui officia consequat Lorem ut qui fugiat cupidatat dolore ex. Reprehenderit incididunt pariatur voluptate laborum amet sint irure nulla sint ut esse enim."
          },
          {
            "id": 1,
            "author": "Louisa",
            "create_time": "Thursday, September 1, 2016 9:36 AM",
            "content": "Occaecat ex cillum consectetur exercitation reprehenderit culpa incididunt. Et enim irure qui pariatur elit aliqua. Exercitation non laboris deserunt id Lorem duis cupidatat incididunt ad esse incididunt anim. Proident non cupidatat magna enim et ex nulla sunt fugiat adipisicing eiusmod occaecat."
          },
          {
            "id": 2,
            "author": "Erica",
            "create_time": "Thursday, February 11, 2016 10:48 PM",
            "content": "Quis id dolore Lorem non anim sunt aliquip qui. Do occaecat sit duis velit aute amet aliqua ad mollit irure. Aute nisi mollit velit velit officia esse adipisicing reprehenderit duis Lorem mollit. Esse tempor qui deserunt non amet deserunt incididunt dolor consequat aute veniam incididunt ut. Ullamco eiusmod velit laborum aliqua consequat ea proident duis. Elit fugiat incididunt consectetur aute enim id."
          },
          {
            "id": 3,
            "author": "Trisha",
            "create_time": "Monday, June 15, 2015 10:12 PM",
            "content": "Cupidatat elit culpa quis aliquip enim exercitation tempor. Amet nostrud voluptate commodo eu sit mollit mollit cillum proident commodo enim exercitation labore esse. Anim ullamco mollit nostrud non enim commodo. Et laborum nulla commodo consectetur deserunt esse ex amet enim officia culpa."
          },
          {
            "id": 4,
            "author": "Stokes",
            "create_time": "Wednesday, February 7, 2018 4:54 PM",
            "content": "Quis officia mollit officia culpa consequat duis magna ipsum nisi. Culpa aliquip exercitation culpa esse ad adipisicing qui sit irure labore nisi. Sunt do sunt esse cillum sunt quis. Do labore commodo pariatur consequat mollit. Irure ipsum anim dolore sit."
          },
          {
            "id": 5,
            "author": "Stuart",
            "create_time": "Tuesday, June 3, 2014 3:39 AM",
            "content": "Amet officia Lorem ut nisi mollit sint commodo consectetur labore nisi irure sint sunt tempor. Anim incididunt non non qui voluptate cillum aliqua ex. Enim adipisicing non tempor ut nulla aute proident. Minim sint ad ullamco laboris eu ullamco veniam culpa pariatur commodo. Veniam ipsum esse incididunt nulla enim cillum et aliquip aliqua laboris irure."
          },
          {
            "id": 6,
            "author": "Cora",
            "create_time": "Sunday, August 27, 2017 12:14 PM",
            "content": "Non do minim nostrud excepteur voluptate incididunt. Ut labore elit labore exercitation irure excepteur. Nostrud laborum tempor sit anim qui et nostrud reprehenderit eiusmod exercitation quis magna minim aliqua."
          },
          {
            "id": 7,
            "author": "Karin",
            "create_time": "Wednesday, February 26, 2014 2:07 AM",
            "content": "Aute sint excepteur consectetur amet laborum. Magna ea irure Lorem sit in laboris excepteur sint ullamco enim dolore occaecat culpa proident. Eu elit enim laboris deserunt et exercitation excepteur officia. Irure qui duis cupidatat excepteur est sint veniam est. Excepteur voluptate in fugiat sunt nulla. Ut elit consequat excepteur ex elit ipsum excepteur labore Lorem. Quis consequat incididunt aute mollit sint culpa ut velit consectetur Lorem tempor nostrud pariatur et."
          }
        ],
        fab: {
          bgColor: '#778899',
          position: 'bottom-right',
          fabActions: [
              {
                  name: 'cache',
                  icon: 'cached',
                  tooltip: 'Refresh forum.'
              },
              {
                  name: 'alertMe',
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
    methods:{
      cache(){
          console.log('Cache Cleared');
      },
      alert(){
          alert('Clicked on alert icon');
      },
      hidePollsAdd () {
        this.$refs.addPoll.hide()
      },
      showPollsAdd () {
        this.$refs.addPoll.show()
      }
    }
  }
</script>

<style>
</style>
