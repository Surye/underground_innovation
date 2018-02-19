<template>
    <div>
        <b-row>
            <b-breadcrumb :items="items"/>
        </b-row>
        <MemberDisplayPanel v-for="member in members" :key="member.id" :member="member"/>
    </div>
</template>

<script>
import MemberDisplayPanel from './member-display-panel'

export default {
  components: { MemberDisplayPanel },
  data() {
    return {
      items: [{
        text: 'Projects',
        to: { name: 'projects' }
      }, {
        text: 'Drone Lunch Delivery', // This will be dynamic based on the project we're in
        to: { name: 'project_details', params: { project_id: this.$route.params.id } }
      }, {
        text: 'Members',
        active: true
      }],
      members:  // Fake data generated with: https://next.json-generator.com/NycwsRyH4
      [
        {
          "id": 0,
          "name": "Glenna Steele",
          "join_date": "Tuesday, January 17, 2017 5:07 PM"
        },
        {
          "id": 1,
          "name": "Gretchen Avery",
          "join_date": "Saturday, January 16, 2016 4:11 AM"
        },
        {
          "id": 2,
          "name": "Calderon Cruz",
          "join_date": "Monday, December 19, 2016 11:20 PM"
        },
        {
          "id": 3,
          "name": "Weaver Dale",
          "join_date": "Thursday, March 12, 2015 9:43 AM"
        },
        {
          "id": 4,
          "name": "Rosetta Lawson",
          "join_date": "Tuesday, March 3, 2015 9:11 PM"
        },
        {
          "id": 5,
          "name": "Willie Dejesus",
          "join_date": "Thursday, June 1, 2017 7:13 PM"
        },
        {
          "id": 6,
          "name": "Chen Schneider",
          "join_date": "Tuesday, May 12, 2015 10:20 AM"
        },
        {
          "id": 7,
          "name": "Joann Mendez",
          "join_date": "Sunday, January 3, 2016 4:47 AM"
        },
        {
          "id": 8,
          "name": "Lorena Swanson",
          "join_date": "Sunday, July 20, 2014 8:08 AM"
        },
        {
          "id": 9,
          "name": "Lilian Woodard",
          "join_date": "Sunday, May 18, 2014 11:28 AM"
        },
        {
          "id": 10,
          "name": "Adriana Lewis",
          "join_date": "Sunday, January 8, 2017 7:54 PM"
        },
        {
          "id": 11,
          "name": "Fischer Larson",
          "join_date": "Tuesday, September 16, 2014 7:56 PM"
        },
        {
          "id": 12,
          "name": "Copeland Case",
          "join_date": "Thursday, May 12, 2016 4:03 AM"
        },
        {
          "id": 13,
          "name": "Ilene Rush",
          "join_date": "Thursday, June 1, 2017 1:50 PM"
        },
        {
          "id": 14,
          "name": "Penny Chase",
          "join_date": "Thursday, July 16, 2015 6:16 AM"
        },
        {
          "id": 15,
          "name": "Sophia Benton",
          "join_date": "Friday, October 10, 2014 3:05 PM"
        },
        {
          "id": 16,
          "name": "Shaw Banks",
          "join_date": "Monday, August 3, 2015 4:38 PM"
        },
        {
          "id": 17,
          "name": "Bonnie Moody",
          "join_date": "Friday, May 9, 2014 10:34 PM"
        },
        {
          "id": 18,
          "name": "Roy Page",
          "join_date": "Friday, November 13, 2015 5:39 AM"
        },
        {
          "id": 19,
          "name": "Johns Calderon",
          "join_date": "Sunday, September 7, 2014 11:15 AM"
        },
        {
          "id": 20,
          "name": "Alfreda Kinney",
          "join_date": "Tuesday, June 30, 2015 6:08 AM"
        },
        {
          "id": 21,
          "name": "Kerri Brooks",
          "join_date": "Tuesday, May 31, 2016 7:31 AM"
        },
        {
          "id": 22,
          "name": "Herring Ashley",
          "join_date": "Sunday, June 14, 2015 1:26 PM"
        },
        {
          "id": 23,
          "name": "Reid Sandoval",
          "join_date": "Thursday, February 8, 2018 2:53 AM"
        }
      ]
    }
  }
}


</script>

<style>
</style>
