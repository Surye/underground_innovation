<template>
  <div>
    <b-row>
      <b-col cols=2>
        <label><h4>Question:</h4></label>
      </b-col>
      <b-col>
        <b-input placeholder="What question would you like to add?" v-model="question"/>
      </b-col>
    </b-row>
    <b-row>
      <b-col cols=2>
        <label><h4>Description:</h4></label>
      </b-col>
      <b-col>
        <b-form-textarea id="textarea1"
                     v-model="description"
                     placeholder="Elaborate details of the question."
                     :rows="3"
                     :max-rows="6">
        </b-form-textarea>
      </b-col>
    </b-row>
    <b-row>
      <b-col>
        <h4>Answers:</h4>
      </b-col>
    </b-row>
    <template v-for="(answer,idx) in answers">
      <b-row :key="idx">
        <b-col>
          <b-input placeholder="New Answer" v-model="answer.answerText" class="mb-3"/>
        </b-col>
      </b-row>
    </template>
    <b-row>
      <b-col>
        <b-button @click="add_answer">Add Answer</b-button>
      </b-col>
      <b-col>
        <b-button class="save-btn" @click="save" variant="success">Save</b-button>
      </b-col>
    </b-row>
  </div>
</template>

<script>
import {HTTP} from '../../http-common'
export default {
  props: ['forumId'],
  data () {
    return {
      question: "",
      description: "",
      answers: [{
        answerText: ""
      }]
    }
  },
  methods: {
    add_answer () {
      this.answers.push({
        answerText: ""
      })
    },
    async save () {
      let poll = {
        question: this.question,
        description: this.description,
        projectId: this.$route.params.project_id,
        pollAnswers: this.answers
      }
      console.log(this.$route.params.forum_id)
      if(this.$route.params.forum_id) {
        poll.forumId = this.$route.params.forum_id
      }

      var newPoll = await HTTP.post('/api/Poll', poll)
      this.$emit('save', newPoll.data)
    },
    reset () {
      this.question = "",
      this.description = "",
      this.answers = [{
        answerText: ""
      }]
    }
  }
}
</script>

<style scoped>
  .save-btn {
    float: right
  }
</style>
