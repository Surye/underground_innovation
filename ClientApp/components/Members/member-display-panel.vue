<template>
<b-row>
  <b-col col="10">
    {{member.name}}
  </b-col>
  <b-col col="2">
    Join Date: {{member.join_date}}
  </b-col>
</b-row>
</template>

<script>
export default {
  props: {
    member: Object
  }
}
</script>

<style scoped>

</style>
