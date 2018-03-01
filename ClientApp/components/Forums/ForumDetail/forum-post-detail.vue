<template>
  <b-row class="mb-3">
    <b-col>
      <b-card>
        <b-row>
          <b-col cols=10>
            <h4>
                {{forum.title}}
            </h4>
          </b-col>
        </b-row>
        <b-row class="card-footer">
          <b-col cols=2>
            <small>
              <b-row>
                Author: {{forum.authorName}}
              </b-row>
              <b-row>
                Post Date: {{forum.createdDate  | moment("MMMM Do YYYY hh:mm A")}}
              </b-row>
            </small>
          </b-col>
          <b-col cols=10>
            <p>{{forum.description}}</p>
          </b-col>
        </b-row>
      </b-card>
    </b-col>
  </b-row>
</template>

<script>
export default {
  props: {
    forum: Object
  }
}
</script>

<style scoped>
</style>
