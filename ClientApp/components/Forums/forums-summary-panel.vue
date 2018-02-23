<template>
    <b-row>
        <b-col>
            <b-card>
                <b-row>
                    <b-col cols=10>
                        <h4><b-link :to="{ name: 'project_forums_replies', params: { forum_id: forum.id }}">{{forum.title}}</b-link></h4>
                    </b-col>
                    <b-col cols=2>
                        Reply Count: {{forum.posts.length + forum.polls.length}}
                    </b-col>
                </b-row>
                <b-row class="card-footer">
                    <b-col cols=2>
                        <small>
                            <b-row>
                                Author: {{forum.authorName}}
                            </b-row>
                            <b-row>
                                Post Date: {{forum.createdDate}}
                            </b-row>
                        </small>
                    </b-col>
                    <b-col cols=10>
                        {{forum.content}}
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
  data() {
    console.log(this.forum)
    return {
    }
  }
}
</script>


<style scoped>
</style>
