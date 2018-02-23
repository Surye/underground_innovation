<template>
  <b-card
    class="mb-2"
    :title="poll.question">
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
          :value="option.current_selections"
          :max="totalAnswers"
          :animated="poll.my_answer == option.id"
          :variant="poll.my_answer == option.id ? 'success' : 'info'"></b-progress>
      </template>
    </template>


    <b-form-group label="Please select your response" v-else>
      <b-form-radio-group stacked v-model="selected" plain>
        <b-form-radio v-for="option in poll.pollAnswers" :value="option.id" :key="option.id"><strong>{{option.answerText}}</strong></b-form-radio>
      </b-form-radio-group>
    </b-form-group>
  </b-card>
</template>

<script>
export default {
  props: {
    poll: Object
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
        total += 1//option.current_selections
      }

      return total
    }
  }
}
</script>

<style scoped>

</style>
