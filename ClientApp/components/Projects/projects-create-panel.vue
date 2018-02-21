<template>
  <div>
    <b-row>
      <b-col cols=2>
        <label><h4>Project Name:</h4></label>
      </b-col>
      <b-col>
        <b-input placeholder="Project Name" v-model="title"/>
      </b-col>
    </b-row>
    <b-row>
      <b-col cols=2>
        <label><h4>Description:</h4></label>
      </b-col>
      <b-col>
        <b-textarea class="mb-3" rows="15" placeholder="Project Description" v-model="description"/>
      </b-col>
    </b-row>
    <b-row>
      <b-col>
        <b-button class="save-btn" @click="save" variant="success">Save</b-button>
      </b-col>
    </b-row>
  </div>
</template>

<script>
  import {HTTP} from '../../http-common'

  export default {
    data () {
      return {
        title: "",
        description: ""
      }
    },
    methods: {
      async save () {
        var proj = await HTTP.post('/api/Project', { title: this.title, description: this.description })
        this.$emit('save', proj.data)
      },
      reset () {
        this.title = "",
        this.description = ""
      }
    }
  }
</script>

<style scoped>
  .save-btn {
    float: right
  }
</style>
