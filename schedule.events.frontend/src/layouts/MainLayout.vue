<template>
  <q-layout view="lHh Lpr lFf">
    <q-header>
      <q-toolbar class="q-header-resize">
        <q-btn
          flat
          dense
          round
          icon="menu"
          aria-label="Menu"
          @click="leftDrawerOpen = !leftDrawerOpen"
        />
        <q-toolbar-title>Schedule Events</q-toolbar-title>
        <div class="text-subtitle1" v-if="$q.platform.is.desktop">{{ todaysdate }}</div>

        </q-toolbar>
        <q-img src="../assets/water.jpg" class="header-image absolute-top"></q-img>
    </q-header>

      <q-drawer
        v-model="leftDrawerOpen"
        show-if-above
        :width="200"
        :breakpoint="400"
      >
        <q-scroll-area style="height: calc(100% - 150px); margin-top: 150px; border-right: 1px solid #ddd">
          <q-list padding>
            <q-item clickable v-ripple>
              <q-item-section avatar>
                <q-icon name="inbox" />
              </q-item-section>

              <q-item-section>
                Inbox
              </q-item-section>
            </q-item>

            <q-item active clickable v-ripple>
              <q-item-section avatar>
                <q-icon name="star" />
              </q-item-section>

              <q-item-section>
                Star
              </q-item-section>
            </q-item>

            <q-item clickable v-ripple>
              <q-item-section avatar>
                <q-icon name="send" />
              </q-item-section>

              <q-item-section>
                Send
              </q-item-section>
            </q-item>

            <q-item clickable v-ripple>
              <q-item-section avatar>
                <q-icon name="drafts" />
              </q-item-section>

              <q-item-section>
                Drafts
              </q-item-section>
            </q-item>
          </q-list>
        </q-scroll-area>

        <q-img class="absolute-top" src="../assets/water.jpg" style="height: 150px; filter: grayscale(65%)">
          <div class="absolute-bottom bg-transparent">
            <q-avatar size="56px" class="q-mb-sm">
              <img src="https://cdn.quasar.dev/img/boy-avatar.png">
            </q-avatar>
            <div class="text-weight-bold">Razvan Stoenescu</div>
            <div>@User-name</div>
          </div>
        </q-img>
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
import localStorageService from '../storage/local.storage.service'
import LocalStaticNames from '../storage/storage.static.names'
import { date } from 'quasar'
import { Platform } from 'quasar'

export default {
  name: 'MainLayout',
  components: {  },
  data () {
    return {
      leftDrawerOpen: false,
      publicIp: null,
      todaysdate: null,
      country_name: null
    }
  },
  computed: {
  },
  methods: {
    getPublicIPAndLocation() {
    this.publicIp = ApiService.logIp().then(async (res) => {

      localStorageService.getWithExpiry(LocalStaticNames.COUNTRY_NAME) == null ? await ApiService.getLocation(res.result)
        .then(async (response) => {

          this.result_country = response.result.country_name
          localStorageService.setWithExpiry(LocalStaticNames.COUNTRY_NAME, response.result.country_name, 60)
          this.publicIp = `Network IP: ${res.result} from ${response.result.country_name}`
          await ApiService.postLocation(response.result)

        })
        .catch(async (rejecte) => {

          this.publicIp = `Network IP: ${res.result}`

        }) : localStorageService.setWithExpiry(LocalStaticNames.COUNTRY_NAME, this.country_name, 60)
    })
    },
    todaysDate() {
      let timestamp = Date.now()
      this.todaysdate = date.formatDate(timestamp, 'dddd D MMMM')
    },
    async checkFrontendVersion(){
      let version = await ApiService.getFrontendVersion()

      console.log(version)
      if(version != getWithExpiry(LocalStaticNames.FRONTEND_VERSION)){
        console.log(`Updating from current version: ${getWithExpiry(LocalStaticNames.FRONTEND_VERSION)}`)
        setWithExpiry(LocalStaticNames.FRONTEND_VERSION, version, 1440)
        console.log(`New version: ${getWithExpiry(LocalStaticNames.FRONTEND_VERSION)}`)
        location.reload()
      }
    }
  },
  async mounted () {
    this.getPublicIPAndLocation()
    this.todaysDate()
    await this.checkFrontendVersion()
  }
}
</script>

<style lang="scss">
  .header-image {
    height: 100%;
    z-index: -1;
    opacity: 0.2;
    filter: grayscale(100%)
  }
  .q-header-resize {
    min-height: 150px !important;
  }
</style>