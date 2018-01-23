<template>
    <b-row>
        <b-col>
            <b-card>
                <b-row>
                    <b-col cols=10>
                        <h4><a href="">{{forum.title}}</a> <b-badge v-if="forum.unread">UNREAD</b-badge></h4>
                    </b-col>
                    <b-col cols=2>
                        Reply Count: {{forum.posts.length}}
                    </b-col>
                </b-row>
                <b-row class="card-footer">
                    <b-col cols=2>
                        <small>
                            <b-row>
                                Author: {{forum.author}}
                            </b-row>
                            <b-row>
                                Post Date: {{forum.create_time}}
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
    return {
    }
  }
}
</script>

<style scoped>
</style>
