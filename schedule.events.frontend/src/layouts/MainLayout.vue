<template>
  <q-layout view="lHh Lpr lFf">
    <q-header elevated>
      <q-toolbar>
        <q-btn
          flat
          dense
          round
          icon="menu"
          aria-label="Menu"
          @click="leftDrawerOpen = !leftDrawerOpen"
        />

        <q-toolbar-title>
          Reddit Browser App
        </q-toolbar-title>

        <div>Beta version v0.10</div>
      </q-toolbar>
    </q-header>

    <q-drawer
      v-model="leftDrawerOpen"
      show-if-above
      bordered
      content-class="bg-grey-1"
    >
      <q-list padding>

        <q-item clickable v-ripple>
          <q-item-section avatar>
            <q-icon name="list" />
          </q-item-section>
          <q-item-section >
            Todo
          </q-item-section>
        </q-item>

        <q-item clickable v-ripple>
          <q-item-section avatar>
            <q-icon name="help" />
          </q-item-section>
          <q-item-section >
            Help
          </q-item-section>
        </q-item>

        <div v-if="this.publicIp != null" class="fixed-bottom-left non-selectable">
          <q-item-section>{{ this.publicIp }}</q-item-section>
        </div>
      </q-list>
    </q-drawer>

    <q-page-container>
      <keep-alive>
        <router-view />
      </keep-alive>
    </q-page-container>
  </q-layout>
</template>

<script>
import ApiService from '../services/api.service';


export default {
  name: 'MainLayout',
  components: {  },
  data () {
    return {
      leftDrawerOpen: false,
      publicIp: null
    }
  },
  computed: {
  },
  methods: {
  },
  mounted () {
    this.publicIp = ApiService.logIp().then(async (res) => {

      ApiService.getLocation(res.result)
        .then(async (response) => {
          console.log(response)
          this.publicIp = `Network IP: ${res.result} from ${response.result.country}`
        })
        .catch(async (rejecte) => {
          this.publicIp = `Network IP: ${res.result}`
        })
    })
  }
}
</script>
