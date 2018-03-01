<template>
    <b-row class="mb-3">
        <b-col>
            <b-card>
                <b-row>
                    <b-col cols=10>
                        <h4><b-link :disabled="!member" :to="{ name: 'project_details', params: { project_id: project.id }}">{{project.title}}</b-link></h4>
                    </b-col>
                    <b-col v-if="!member" cols=2>
                        <b-link @click="joinProject">Join Project</b-link>
                    </b-col>
                </b-row>
                <b-row class="card-footer">
                    <b-col cols=12>
                        {{project.description}}
                    </b-col>
                </b-row>
            </b-card>
        </b-col>
    </b-row>
</template>

<script>
  import {HTTP} from '../../http-common'
  export default {

    props: {
      project: Object,
      member: Boolean
    },
    methods: {
      async joinProject () {
        var proj = await HTTP.post('/api/Project/'+this.project.id+'/Join')
        this.$emit('join', proj.data)
      }
    },
    data() {
      return {
      }
    }
  }
</script>

<style scoped>
  a.disabled {
    pointer-events: none;
    color: darkgray;
  }
</style>
