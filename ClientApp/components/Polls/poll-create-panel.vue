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
    <template v-for="answer in answers">
      <b-row :key="answer.id">
        <b-col>
          <b-input placeholder="New Answer" v-model="answer.text" class="mb-3"/>
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
export default {
  data () {
    return {
      question: "",
      description: "",
      answers: []
    }
  },
  methods: {
    add_answer () {
      this.answers.push({
        id: null,
        text: ""
      })
    },
    save () {

    },
    reset () {
      this.question = "",
      this.description = "",
      this.answers = []
    }
  }
}
</script>

<style scoped>
  .save-btn {
    float: right
  }
</style>
