<template>
    <b-row>
        <b-col>
            <b-card>
                <b-row>
                    <b-col cols=10>
                        <h4><b-link :disabled="!project.member" :to="{ name: 'project_details', params: { project_id: project.project_id }}">{{project.title}}</b-link></h4>
                    </b-col>
                    <b-col v-if="!project.member" cols=2>
                        <b-link>Join Project</b-link>
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

export default {
  props: {
    project: Object
  },
  data() {
    return {
    }
  }
}
</script>

<style scoped>
</style>
