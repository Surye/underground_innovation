<template>
  <div>
    <b-row>
      <b-col cols=2>
        <label><h3>Question:</h3></label>
      </b-col>
      <b-col>
        <b-input placeholder="What question would you like to add?" v-model="question"/>
      </b-col>
    </b-row>
    <b-row>
      <b-col>
        <h2>Answers:</h2>
      </b-col>
    </b-row>
    <template v-for="answer in answers">
      <b-row :key="answer.id">
        <b-col>
          <b-input placeholder="New Answer" v-model="answer.text"/>
        </b-col>
      </b-row>
    </template>
    <b-row>
      <b-col>
        <b-button @click="add_answer">Add Answer</b-button>
      </b-col>
      <b-col>
        <b-button class="save-btn" @click="save" style="">Save</b-button>
      </b-col>
    </b-row>
  </div>
</template>

<script>
export default {
  data () {
    return {
      question: "",
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

    }
  }
}
</script>

<style scoped>
  .save-btn {
    float: right
  }
</style>
