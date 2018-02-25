<template>
  <b-card
    class="mb-2"
    :title="poll.question">

    <b-row class="card-footer">
      <b-col cols=2>
        <small>
          <b-row>
            Author: {{poll.authorName}}
          </b-row>
          <b-row>
            Post Date: {{poll.createdDate  | moment("MMMM Do YYYY hh:mm A")}}
          </b-row>
        </small>
      </b-col>
      <b-col cols=10>
        <p class="card-text">
          {{ poll.description }}
        </p>


        <template v-if="poll.my_answer > -1">
          <h5>
            Total Answers: {{ totalAnswers }}
          </h5>
          <template v-for="option in poll.pollAnswers">
            <strong :key="option.id">{{option.content}}</strong> <small :key="option.id" v-if="poll.my_answer == option.id">(My Answer)</small>
            <b-progress
              class="mb-3"
              show-value
              :key="option.id"
              :value="option.currentSelections"
              :max="totalAnswers"
              :animated="poll.my_answer == option.id"
              :variant="poll.my_answer == option.id ? 'success' : 'info'"></b-progress>
          </template>
        </template>


        <b-form-group label="Please select your response" v-else>
          <b-form-radio-group stacked v-model="selected" plain>
            <b-form-radio v-for="option in poll.pollAnswers" :value="option" :key="option.id" @change="pollSelect"><strong>{{option.answerText}}</strong></b-form-radio>
          </b-form-radio-group>
        </b-form-group>
      </b-col>
    </b-row>
  </b-card>
</template>

<script>
import {HTTP} from '../../http-common'
export default {
  props: {
    poll: Object
  },
  methods: {
    pollSelect (selected) {
      selected.currentSelections += 1
      this.poll.my_answer = selected.id
    }
  },
  data () {
    return {
      selected: null
    }
  },
  computed: {
    totalAnswers () {
      var total = 0
      for(var option of this.poll.pollAnswers) {
        console.log(option)
        total += option.currentSelections
      }

      return total
    }
  }
}
</script>

<style scoped>

</style>
