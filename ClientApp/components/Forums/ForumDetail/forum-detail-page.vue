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
      <template v-for="reply in replies">
        <b-row :key='"reply.type" + reply.id'>
          <b-col center cols="8">
            <ForumPostReply v-if="reply.type == 'reply'" :reply='reply'/>
            <PollDisplayPanel v-if="reply.type == 'poll'" :poll='reply'/>
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
        <PollCreatePanel ref='newPoll'/>
        <b-btn class="mt-3" variant="outline-danger" block @click="hidePollsAdd">Cancel</b-btn>
      </b-modal>

      <b-modal ref="addReply" size="lg" center hide-footer title="Add new reply.">
        <ReplyCreatePanel ref='newReply'/>
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
  import fab from 'vue-fab'

  export default {
    components: {ForumPostDetail, ForumPostReply, ReplyCreatePanel, PollCreatePanel, PollDisplayPanel, fab},
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
              "type":"reply",
              "id":0,
              "author":"Bruce",
              "create_time":"Monday, January 11, 2016 9:43 PM",
              "content":"Aliquip cupidatat in aliqua deserunt Lorem anim excepteur. Eu amet dolor excepteur sint ea consequat quis magna. Nisi Lorem est voluptate irure esse consequat. Reprehenderit eu excepteur enim eu commodo enim exercitation reprehenderit ut quis. Amet nulla ipsum eiusmod culpa cupidatat ex officia excepteur qui velit. Eiusmod voluptate nisi sint nulla cupidatat do non ullamco officia."
          },
          {
              "type":"reply",
              "id":1,
              "author":"Cassandra",
              "create_time":"Sunday, July 31, 2016 1:31 AM",
              "content":"Dolor nisi quis tempor qui ipsum adipisicing. Magna deserunt laborum est ipsum voluptate enim commodo officia consequat Lorem. Ex ad nostrud commodo nostrud sit officia officia proident esse culpa exercitation. Consequat cillum pariatur nulla et laborum ut ullamco."
          },
          {
              "type":"reply",
              "id":2,
              "author":"Marsha",
              "create_time":"Thursday, February 16, 2017 6:25 PM",
              "content":"Commodo labore veniam in adipisicing veniam commodo. Occaecat velit sunt elit voluptate incididunt non culpa aute sunt. Et sunt laborum ex proident tempor anim duis tempor do commodo ea ex. Ullamco laborum ad officia culpa enim eiusmod ipsum sint occaecat tempor veniam esse magna Lorem. Aliquip occaecat ipsum mollit tempor exercitation."
          },
          {
              "type":"reply",
              "id":3,
              "author":"Constance",
              "create_time":"Thursday, August 6, 2015 4:49 PM",
              "content":"Adipisicing occaecat nulla ullamco velit officia nulla tempor duis cupidatat magna pariatur ipsum nisi. Do irure sunt cillum laboris dolor excepteur ad enim. Tempor eiusmod eu sit laborum non deserunt ex officia est ut. Lorem mollit ex consectetur commodo fugiat enim velit. Occaecat fugiat culpa enim commodo irure."
          },
          {
              "type":"poll",
              "id":0,
              "question":"Aliqua id eu voluptate nostrud magna elit veniam cupidatat mollit dolor in minim.",
              "author":"Tammie",
              "description":"Exercitation minim mollit Lorem duis laborum in ut. Magna reprehenderit in laborum cillum pariatur et. Ipsum nostrud anim voluptate fugiat sint dolore duis ullamco occaecat nisi consequat mollit sit. Qui do nostrud amet occaecat occaecat magna ut excepteur aliquip. Est Lorem voluptate ea labore elit Lorem dolor aliqua culpa. Fugiat ipsum qui nostrud eiusmod deserunt amet quis nisi et est nisi dolore deserunt Lorem.",
              "create_time":"Wednesday, November 5, 2014 10:16 PM",
              "my_answer":0,
              "answers":[
                {
                    "id":0,
                    "content":"Officia incididunt et exercitation sit ad Lorem dolore consequat et elit ut.",
                    "current_selections":29
                },
                {
                    "id":1,
                    "content":"Aliquip fugiat aliquip cupidatat occaecat nostrud officia Lorem laboris amet aliqua pariatur qui.",
                    "current_selections":40
                },
                {
                    "id":2,
                    "content":"Elit ex aliqua enim anim et duis non officia adipisicing.",
                    "current_selections":29
                }
              ]
          },
          {
              "type":"reply",
              "id":4,
              "author":"Michael",
              "create_time":"Saturday, August 5, 2017 3:45 AM",
              "content":"Enim nisi velit amet mollit qui laborum aute proident cillum sunt deserunt eu. Nostrud aute ad aliquip velit eiusmod aliqua veniam et qui incididunt. Anim reprehenderit non tempor occaecat id ut duis aliquip consectetur laborum in."
          },
          {
              "type":"poll",
              "id":1,
              "question":"Eiusmod sint amet pariatur laboris id.",
              "author":"Spencer",
              "description":"Nostrud velit commodo consectetur aliquip. Fugiat amet anim labore eiusmod quis duis sint do mollit non. In do mollit id culpa. Occaecat consectetur do incididunt anim veniam excepteur aute enim elit. Officia velit ut esse ad sunt. Incididunt Lorem et incididunt occaecat laborum do ad aute.",
              "create_time":"Friday, October 24, 2014 12:26 AM",
              "answers":[
                {
                    "id":0,
                    "content":"Adipisicing cupidatat exercitation cupidatat culpa ad do consequat aliquip irure.",
                    "current_selections":39
                },
                {
                    "id":1,
                    "content":"Nisi tempor est velit enim qui.",
                    "current_selections":20
                }
              ]
          },
          {
              "type":"reply",
              "id":5,
              "author":"Oliver",
              "create_time":"Friday, March 20, 2015 1:24 AM",
              "content":"Minim aute labore fugiat laboris ex ullamco eu ea labore velit. Ex cillum elit Lorem ea sint ut laboris cupidatat sunt fugiat qui aliqua aliqua. Pariatur do sint minim nulla Lorem minim aliquip. Eiusmod duis fugiat ad sit eu cupidatat pariatur voluptate fugiat."
          }
        ],
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
    methods:{
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
      }
    }
  }
</script>

<style>
</style>
