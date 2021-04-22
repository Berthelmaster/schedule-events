<template>
    <q-page class="flex-center q-pa-sm bg-grey-3" v-if="getEvent">
        {{post}}
    </q-page>
</template>


<script>
import ApiService from '../services/api.service';

export default {
  name: 'View-event',

  data() {
      return {
          id: this.$router.currentRoute.query.id,
          post: {

          }
      }
  },

  computed: {
      async getEvent(){
          console.log(this.id);

          await ApiService.getPost(this.id)
          .then(res => {
              console.log(res)
              this.post = res.result.data
          })
          .catch(rej => {
              console.log(rej)
          })
      }
  }

}

// this.$router.currentRoute.query.id
</script>
