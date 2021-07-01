  <template>
    <input class="search-input" v-model="text" placeholder="suche" />
  </template>

  <script>
  export default {
    props: {
      searchText: String
    },
    computed: {
      text:{
        get(){
        return this.searchText
      },
        set(value){
          this.$emit("search", value)
        }
      }
    }
  }
  </script>

  <style scoped>
  .search-input{
      border: none;
      border-bottom: solid;
      border-width: .001px;
  }
  </style>
