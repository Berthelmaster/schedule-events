<template>
  <q-page class="flex-center q-pa-sm">
    <div>
      <div>Search</div>
      <div class="row">
        <div class="col-6">
          <q-input rounded outlined v-model="inputContent" label="Some Subreddit Name"></q-input>
        </div>
        <q-btn push color="primary" label="Push" @click="GetPage(inputContent)"/>
      </div>
    </div>
    <div>
      <h5>Browsing: {{this.subSelected}}</h5>

      <div>
        {{this.content}}
      </div>
    </div>

    
  </q-page>
</template>

<script>
import ApiService from '../services/api.service';

export default {
  name: 'PageIndex',

  data () {
    return {
      subSelected: 'Nothing selected...',
      content: null,
      inputContent: ''
    }
  },
  methods: {
    GetPage(content) {
      ApiService.getSubreddit(content).then(async (res) => {
        this.subSelected = content
        this.content = res.result
      })
      .catch(async (rej) => {
        this.subSelected = 'Nothing selected...'
        this.content = null
      })
    }
  }
}
</script>
