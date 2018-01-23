<template>
    <div>
        <b-row>
            <b-breadcrumb :items="items"/>
        </b-row>
        <b-row>
        </b-row>

    </div>
</template>

<script> 

export default {

  data() {
    return {
      items: [{ text: 'Projects' }]
    }
  }
}

</script>

<style>
</style>
