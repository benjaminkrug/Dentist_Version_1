<template>
  <div>
    <button @click="backendTest"> Daten aus DB laden</button>
    <button @click="backendTerminTest"> Termin Daten aus DB laden</button>
    {{ test }}
  </div>
</template>

<script>
export default {
  data() {
    return {
      test: 'test'
    }
  },
  methods: {
    async backendTest() {
        this.test = await this.axios
          .get('https://localhost:5001/User')
          .then(response => {
            return response.data
          })
    },
      async backendTerminTest() {
          this.test = await this.axios
            .get('https://localhost:5001/getAllTermine')
            .then(response => {
              return response.data
            })
      },
  }
}
</script>

<style scoped>
</style>
