<template>
  <div>
    <b-row>
      <b-col cols=2>
        <label><h4>Title:</h4></label>
      </b-col>
      <b-col>
        <b-input placeholder="Topic of the Forum" v-model="title"/>
      </b-col>
    </b-row>
    <b-row>
      <b-col cols=2>
        <label><h4>Description:</h4></label>
      </b-col>
      <b-col>
        <b-form-textarea id="textarea1"
                     v-model="description"
                     :rows="3"
                     :max-rows="6">
        </b-form-textarea>
      </b-col>
    </b-row>
    <b-row>
      <b-col>

      </b-col>
      <b-col>
        <b-button class="save-btn mt-3" @click="save" variant="success">Save</b-button>
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
      var forum = await HTTP.post('/api/Forum', { title: this.title, description: this.description, projectId: this.$route.params.project_id })
      this.$emit('save', forum.data)
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
