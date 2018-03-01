<template>
<b-list-group-item>
  <b-row>
    <b-col col="11">
      {{member.fullName}}
    </b-col>
    <b-col col="1" style="text-align:right">
      Join Date: {{random_date  | moment("MMMM Do YYYY hh:mm A")}}
    </b-col>
  </b-row>
</b-list-group-item>
</template>

<script>
export default {
  props: {
    member: Object
  },
  computed: {
    random_date () {
      let end = new Date(2017, 12, 1)
      let start = new Date(2018, 2, 28)
      return new Date(start.getTime() + Math.random() * (end.getTime() - start.getTime()));
    }
  }
}
</script>

<style scoped>

</style>
