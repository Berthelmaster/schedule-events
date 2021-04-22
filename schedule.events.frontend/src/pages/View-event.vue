<template>
    <q-page class="flex-center q-pa-sm bg-grey-3" v-if="getEvent">
        {{post}}
        <div class="text-h3">
            <section class="center-it">{{post.title}}</section>
        </div>

        <q-separator />
        
        <div>
            <section>
                <q-img v-if="post.image != ''" :src="post.image" 
                style="max-width: 100%; height: 30rem; width: 100%;"
                contain/>
                <q-img v-else src="https://api.linkancestors.com/download?websitePath=4/27e888de-dd14-4c41-9196-1ab340338101no-image.png" 
                style="max-width: 100%; height: 30rem; width: 100%;"
                contain/>
            </section>
        </div>

        <q-separator />

        <div>
            <section>
                <div class="text-h5"><b>Description: </b> {{post.description}}</div>
                <div class="text-h5"><b>Content: </b>{{post.content}}</div>
            </section>
        </div>

        <q-separator />

        <div>
            <section>
                <div id="comments" class="text-h4">0 Comments</div>
                <q-editor v-model="editor" min-height="5rem" />
            </section>
        </div>
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

          },
          editor: "I like this event..."
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


<style scoped>
.center-it{
  margin: auto;
  width: 50%;
  text-align: center;
  margin-bottom: 1rem;
}
</style>