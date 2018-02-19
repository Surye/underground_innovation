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
        <b-button class="save-btn" @click="save" style="">Save</b-button>
      </b-col>
    </b-row>
  </div>
</template>

<script>
export default {
  data () {
    return {
      reply: "",
    }
  },
  methods: {

    save () {

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
