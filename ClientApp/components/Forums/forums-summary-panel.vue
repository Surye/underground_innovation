<template>
    <b-row>
        <b-col>
            <b-card>
                <b-row>
                    <b-col cols=10>
                        <h4><b-link :to="{ name: 'project_forums_replies', params: { forum_id: forum.id }}">{{forum.title}}</b-link></h4>
                    </b-col>
                    <b-col cols=2>
                        Reply Count: {{ reply_count }}
                    </b-col>
                </b-row>
                <b-row class="card-footer">
                    <b-col cols=2>
                        <small>
                            <b-row>
                                Author: {{forum.authorName}}
                            </b-row>
                            <b-row>
                                Post Date: {{forum.createdDate | moment("MMMM Do YYYY hh:mm A")}}
                            </b-row>
                        </small>
                    </b-col>
                    <b-col cols=10>
                        {{forum.description}}
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
  },
  computed: {
    reply_count () {
      let count = 0
      if(this.forum.posts)
      {
        count += this.forum.posts.length
      }

      if(this.forum.polls)
      {
        count += this.forum.polls.length
      }

      return count
    }
  },
  data() {
    console.log(this.forum)
    return {
    }
  }
}
</script>


<style scoped>
</style>
