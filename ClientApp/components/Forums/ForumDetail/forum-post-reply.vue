<template>
  <b-row class="mb-2">
    <b-col>
      <b-card>
        <b-row class="card-footer">
          <b-col cols=2>
            <small>
              <b-row>
                Author: {{reply.author}}
              </b-row>
              <b-row>
                Post Date: {{reply.create_time}}
              </b-row>
            </small>
          </b-col>
          <b-col cols=10>
            {{reply.content}}
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
