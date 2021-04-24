<template>
    <q-page class="flex-center q-pa-sm bg-grey-3" v-if="getEvent">
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
                <div class="topright">
                    <q-btn push color="white" text-color="primary" label="Send" 
                    style="top: 0; transform: translateY(-100%); height: 70px; width: 100px;"
                    @click="PostComment"/>
                </div>
            </section>
        </div>

        <q-separator />
        
        <div>
            <section>
                <div v-for="(comment, index) in comments.slice().reverse()" :key="index">
                    <div class="commment-single rounded-borders">
                        <div>{{comment.writtenBy}} - {{comment.date}}</div>
                        <q-separator />
                        <div v-html="comment.content"></div>
                    </div>
                </div>
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
          editor: "I like this event...",
          comments: []
      }
  },

  computed: {
      async getEvent(){
          console.log(this.id);

          await ApiService.getPost(this.id)
          .then(res => {
              console.log(res)
              this.post = res.result.data
              this.comments = res.result.data.comments
          })
          .catch(rej => {
              console.log(rej)
          })
      }
  },

  methods: {
      async PostComment(){
          let postObject = {
              Content: this.editor,
              PostId: parseInt(this.id)
          }
          await ApiService.postComment(postObject)
          .then(res => {
              console.log(res)
              this.getEvent2()
          })
          .catch(rej => {
              console.log(rej)
          })
      },
      async getEvent2(){
          console.log(this.id);

          await ApiService.getPost(this.id)
          .then(res => {
              console.log(res)
              this.post = res.result.data
              this.comments = res.result.data.comments
          })
          .catch(rej => {
              console.log(rej)
          })
      },
      updateCommentElement(){
          
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
.topright {
    position: absolute;
    right: 10px;
}
.commment-single{
    border-style:inherit;
    padding-top: 10px;
}
</style>