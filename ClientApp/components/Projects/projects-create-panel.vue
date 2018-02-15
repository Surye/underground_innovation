<template>
  <div>
    <b-row>
      <b-col cols=2>
        <label><h4>Project Name:</h4></label>
      </b-col>
      <b-col>
        <b-input placeholder="Project Name" v-model="pname"/>
      </b-col>
    </b-row>
    <b-row>
      <b-col cols=2>
        <label><h4>Description:</h4></label>
      </b-col>
      <b-col>
        <b-textarea class="mb-3" rows="15" placeholder="Project Description" v-model="desc"/>
      </b-col>
    </b-row>
    <b-row>
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
      pname: "",
      desc: ""
    }
  },
  methods: {
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
