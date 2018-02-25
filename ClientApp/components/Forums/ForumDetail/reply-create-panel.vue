<template>
  <div>
    <b-row>
      <b-col cols=2>
        <label><h4>Reply:</h4></label>
      </b-col>
      <b-col>
        <b-form-textarea id="textarea1"
                     v-model="reply"
                     :rows="6"
                     :max-rows="10">
        </b-form-textarea>
      </b-col>
    </b-row>
    <b-row>
      <b-col>

      </b-col>
      <b-col>
        <b-button class="save-btn" @click="save" variant="success">Save</b-button>
      </b-col>
    </b-row>
  </div>
</template>

<script>
import {HTTP} from '../../../http-common'
export default {
  data () {
    return {
      reply: "",
    }
  },
  methods: {

    async save () {
      var reply = await HTTP.post('/api/ForumPost', { content: this.reply, forumId: this.$route.params.forum_id })
      this.$emit('save', reply.data)
    },
    reset () {
      this.reply = ""
    }
  }
}
</script>

<style scoped>
  .save-btn {
    float: right
  }
</style>
