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
        <PollCreatePanel ref="newPoll"/>
        <b-btn class="mt-3" variant="outline-danger" block @click="hidePollsAdd">Cancel</b-btn>
      </b-modal>
    </div>
</template>

<script>
import PollDisplayPanel from './poll-display-panel'
import PollCreatePanel from './poll-create-panel'

import fab from 'vue-fab'

export default {
  components: { PollDisplayPanel, fab, PollCreatePanel },
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
      this.$refs.newPoll.reset()
      this.$refs.addPoll.show()
    }
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
      items: [{
        text: 'Projects',
        to: { name: 'projects' }
      }, {
        text: 'Drone Lunch Delivery', // This will be dynamic based on the project we're in
        to: { name: 'project_details', params: { project_id: this.$route.params.id } }
      }, {
        text: 'Polls',
        active: true
      }],
      polls:  [ // Fake data generated with: https://next.json-generator.com/NycwsRyH4
  {
    "id": 0,
    "question": "Aliqua id eu voluptate nostrud magna elit veniam cupidatat mollit dolor in minim.",
    "author": "Tammie",
    "description": "Exercitation minim mollit Lorem duis laborum in ut. Magna reprehenderit in laborum cillum pariatur et. Ipsum nostrud anim voluptate fugiat sint dolore duis ullamco occaecat nisi consequat mollit sit. Qui do nostrud amet occaecat occaecat magna ut excepteur aliquip. Est Lorem voluptate ea labore elit Lorem dolor aliqua culpa. Fugiat ipsum qui nostrud eiusmod deserunt amet quis nisi et est nisi dolore deserunt Lorem.",
    "create_time": "Wednesday, November 5, 2014 10:16 PM",
    "my_answer": 0,
    "answers": [
      {
        "id": 0,
        "content": "Officia incididunt et exercitation sit ad Lorem dolore consequat et elit ut.",
        "current_selections": 29
      },
      {
        "id": 1,
        "content": "Aliquip fugiat aliquip cupidatat occaecat nostrud officia Lorem laboris amet aliqua pariatur qui.",
        "current_selections": 40
      },
      {
        "id": 2,
        "content": "Elit ex aliqua enim anim et duis non officia adipisicing.",
        "current_selections": 29
      }
    ]
  },
  {
    "id": 1,
    "question": "Eiusmod sint amet pariatur laboris id.",
    "author": "Spencer",
    "description": "Nostrud velit commodo consectetur aliquip. Fugiat amet anim labore eiusmod quis duis sint do mollit non. In do mollit id culpa. Occaecat consectetur do incididunt anim veniam excepteur aute enim elit. Officia velit ut esse ad sunt. Incididunt Lorem et incididunt occaecat laborum do ad aute.",
    "create_time": "Friday, October 24, 2014 12:26 AM",
    "answers": [
      {
        "id": 0,
        "content": "Adipisicing cupidatat exercitation cupidatat culpa ad do consequat aliquip irure.",
        "current_selections": 39
      },
      {
        "id": 1,
        "content": "Nisi tempor est velit enim qui.",
        "current_selections": 20
      }
    ]
  },
  {
    "id": 2,
    "question": "Magna reprehenderit mollit pariatur eu sit adipisicing excepteur anim fugiat.",
    "author": "Fitzgerald",
    "description": "Quis proident reprehenderit enim ullamco ex esse magna nulla minim nisi mollit laborum commodo sint. Anim labore elit fugiat id fugiat tempor commodo ullamco excepteur laborum pariatur do. Enim aute cupidatat qui in et exercitation Lorem nulla. Enim minim ullamco adipisicing quis nulla reprehenderit magna in. Qui sunt sint reprehenderit irure pariatur est duis nisi consectetur incididunt sunt reprehenderit excepteur laborum. Eu aute eu aute velit incididunt anim non incididunt cupidatat ex labore. Id elit duis dolor sunt amet esse veniam in quis adipisicing.",
    "create_time": "Tuesday, March 7, 2017 11:28 AM",
    "my_answer": 2,
    "answers": [
      {
        "id": 0,
        "content": "Id non aute duis excepteur dolor eu cillum amet.",
        "current_selections": 27
      },
      {
        "id": 1,
        "content": "Ea proident esse reprehenderit laboris non dolor.",
        "current_selections": 35
      },
      {
        "id": 2,
        "content": "Non tempor sit ad ut et labore nulla tempor.",
        "current_selections": 31
      }
    ]
  },
  {
    "id": 3,
    "question": "Aliqua nostrud velit quis minim consequat incididunt.",
    "author": "Marva",
    "description": "Mollit do sint nulla aute esse cillum do ex nostrud qui veniam. Culpa qui id voluptate ad. Aliquip fugiat occaecat mollit ipsum ad in. Ut aliquip eiusmod ex excepteur do ea ut veniam aliqua nulla mollit fugiat ea et. Laborum elit dolor sunt amet consequat mollit deserunt.",
    "create_time": "Thursday, April 3, 2014 3:26 PM",
    "my_answer": 3,
    "answers": [
      {
        "id": 0,
        "content": "Voluptate duis dolor in est Lorem ea sunt aliquip.",
        "current_selections": 28
      },
      {
        "id": 1,
        "content": "Magna quis laborum eu consectetur nulla voluptate commodo velit velit tempor.",
        "current_selections": 36
      },
      {
        "id": 2,
        "content": "Commodo est dolore occaecat labore dolore consequat elit.",
        "current_selections": 36
      }
    ]
  },
  {
    "id": 4,
    "question": "Nostrud amet aute cillum sunt adipisicing veniam aute do.",
    "author": "Mosley",
    "description": "Qui commodo veniam adipisicing ipsum laborum nostrud. Mollit pariatur enim cupidatat ex adipisicing cupidatat cillum adipisicing aliquip. Labore qui veniam id qui ex est nulla anim do cillum quis sunt minim.",
    "create_time": "Sunday, November 30, 2014 11:07 AM",
    "my_answer": 4,
    "answers": [
      {
        "id": 0,
        "content": "Aliquip esse magna velit ullamco deserunt id esse.",
        "current_selections": 37
      },
      {
        "id": 1,
        "content": "Enim laboris fugiat et occaecat quis excepteur occaecat sit exercitation eu id.",
        "current_selections": 38
      },
      {
        "id": 2,
        "content": "Esse in nostrud laborum anim mollit elit ex consequat incididunt anim nisi.",
        "current_selections": 35
      },
      {
        "id": 3,
        "content": "Id occaecat incididunt amet tempor elit aute.",
        "current_selections": 37
      }
    ]
  },
  {
    "id": 5,
    "question": "Veniam incididunt dolore velit consequat.",
    "author": "Beatriz",
    "description": "Non voluptate officia culpa occaecat irure. Eiusmod culpa consectetur cillum est id nisi. Dolor commodo quis laborum duis id aute nulla do do occaecat nisi sunt. Cupidatat proident reprehenderit esse aliquip Lorem aute amet culpa consectetur minim. Anim id pariatur aliquip id consequat. Commodo consectetur ut non Lorem consectetur dolore ut aliquip occaecat magna. Fugiat esse magna mollit aliqua.",
    "create_time": "Sunday, August 31, 2014 3:15 PM",
    "my_answer": 5,
    "answers": [
      {
        "id": 0,
        "content": "Labore occaecat dolor dolor ad dolore sit velit et eiusmod reprehenderit sunt duis laboris.",
        "current_selections": 24
      },
      {
        "id": 1,
        "content": "Reprehenderit minim reprehenderit proident commodo qui magna excepteur enim id ipsum pariatur culpa enim esse.",
        "current_selections": 36
      },
      {
        "id": 2,
        "content": "Nisi consequat consequat eiusmod eiusmod incididunt esse commodo consequat incididunt consequat magna consectetur deserunt aliqua.",
        "current_selections": 24
      },
      {
        "id": 3,
        "content": "Excepteur proident pariatur elit commodo.",
        "current_selections": 29
      }
    ]
  },
  {
    "id": 6,
    "question": "Officia nisi reprehenderit sit exercitation commodo elit.",
    "author": "Latonya",
    "description": "Sunt cillum sit fugiat minim minim Lorem adipisicing reprehenderit do laboris. In duis laborum pariatur sit et Lorem ipsum. Lorem mollit cupidatat dolor id fugiat laborum. Et eiusmod magna eiusmod nostrud cupidatat et exercitation aliqua laborum deserunt eu pariatur quis excepteur. Qui anim veniam tempor ex qui. Consequat officia officia irure eiusmod.",
    "create_time": "Wednesday, May 7, 2014 11:40 PM",
    "my_answer": 6,
    "answers": [
      {
        "id": 0,
        "content": "Pariatur amet voluptate consectetur occaecat veniam.",
        "current_selections": 40
      },
      {
        "id": 1,
        "content": "Velit dolor aliquip esse aliquip duis magna proident velit elit laborum duis ex reprehenderit.",
        "current_selections": 33
      },
      {
        "id": 2,
        "content": "Tempor velit proident irure et labore do Lorem.",
        "current_selections": 26
      },
      {
        "id": 3,
        "content": "Eiusmod duis veniam reprehenderit ex nulla occaecat ullamco ullamco est laborum aliquip ullamco.",
        "current_selections": 33
      }
    ]
  },
  {
    "id": 7,
    "question": "Ad ad qui excepteur reprehenderit adipisicing eu aliquip consequat deserunt eu voluptate laborum.",
    "author": "Bender",
    "description": "Reprehenderit exercitation occaecat nisi ullamco non amet sint. Nulla consectetur nulla et laborum est sit mollit proident adipisicing. Sit ex proident Lorem nostrud occaecat ut. Ullamco duis cupidatat do tempor eiusmod. Incididunt do aliquip Lorem culpa labore aute do non adipisicing consectetur nulla. Magna ut magna sint proident minim ut. Voluptate cillum aliquip nostrud fugiat non non veniam ex dolor ea exercitation fugiat sit.",
    "create_time": "Tuesday, December 5, 2017 12:21 PM",
    "my_answer": 7,
    "answers": [
      {
        "id": 0,
        "content": "Sint nisi amet proident consequat officia quis eiusmod ad do aute quis pariatur id.",
        "current_selections": 34
      },
      {
        "id": 1,
        "content": "Elit non sunt anim ad proident nulla duis consequat cillum deserunt laborum reprehenderit nulla.",
        "current_selections": 20
      },
      {
        "id": 2,
        "content": "Ex elit voluptate amet cillum excepteur reprehenderit voluptate nostrud deserunt nulla Lorem dolore quis proident.",
        "current_selections": 26
      },
      {
        "id": 3,
        "content": "Magna irure sit officia adipisicing veniam cupidatat esse magna mollit do laboris.",
        "current_selections": 37
      }
    ]
  }
]
    }
  }
}


</script>

<style>
</style>
