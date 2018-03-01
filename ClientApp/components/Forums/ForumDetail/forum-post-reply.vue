<template>
  <b-row class="mb-2">
    <b-col>
      <b-card>
        <b-row class="card-footer">
          <b-col cols=2>
            <small>
              <b-row>
                Author: {{reply.authorName}}
              </b-row>
              <b-row>
                Post Date: {{reply.createdDate | moment("MMMM Do YYYY hh:mm A")}}
              </b-row>
            </small>
          </b-col>
          <b-col cols=10>
            <p>{{reply.content}}</p>
          </b-col>
        </b-row>
      </b-card>
    </b-col>
  </b-row>
</template>

<script>
export default {
  props: {
    reply: Object
  }
}
</script>

<style scoped>
</style>
