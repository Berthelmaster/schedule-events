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
        <q-toolbar-title @click="$router.push('/')" style="cursor: pointer">Schedule Events</q-toolbar-title>
        <div class="q-pa-md">
          <div class="text-subtitle1" v-if="$q.platform.is.desktop">{{ todaysdate }}</div>
          <q-btn v-if="!isLoggedIn()" @click="$router.push('/login')" push stretch color="accent" label="Login" />
          <q-btn v-else @click="logOut()" push stretch color="accent" label="Sign out" />
        </div>
        

        </q-toolbar>
        <q-img src="../assets/water.jpg" class="header-image absolute-top"></q-img>
    </q-header>

      <q-drawer
        v-model="leftDrawerOpen"
        :width="200"
        :breakpoint="400"
      >
        <q-scroll-area style="height: calc(100% - 150px); margin-top: 150px; border-right: 1px solid #ddd">
          <q-list padding>
            <q-item clickable v-ripple @click="$router.push('/')">
              <q-item-section avatar>
                <q-icon name="today" />
              </q-item-section>

              <q-item-section>
                Browse Events
              </q-item-section>
            </q-item>

            <q-item clickable v-ripple @click="$router.push('/create-event')">
              <q-item-section avatar>
                <q-icon name="message" />
              </q-item-section>

              <q-item-section>
                Create Event
              </q-item-section>
            </q-item>

            <q-item clickable v-ripple @click="$router.push('/profile')">
              <q-item-section avatar>
                <q-icon name="face" />
              </q-item-section>

              <q-item-section>
                Profile
              </q-item-section>
            </q-item>

            <q-item clickable v-ripple @click="$router.push('/about-and-donate')">
              <q-item-section avatar>
                <q-icon name="info" />
              </q-item-section>

              <q-item-section>
                About | Donate
              </q-item-section>
            </q-item>
          </q-list>
        </q-scroll-area>

        <q-img v-if="this.profile == null" class="absolute-top" src="../assets/graybg.jpg" style="height: 150px; filter:">
          <div class="absolute-bottom bg-transparent">
            <q-avatar size="56px" class="q-mb-sm">
              <img src="https://cdn.quasar.dev/img/boy-avatar.png">
            </q-avatar>
            <div class="text-weight-bold">John Hancock</div>
            <div>John@Hancock.com</div>
          </div>
        </q-img>
        <q-img v-else class="absolute-top" src="../assets/graybg.jpg" style="height: 150px; filter:">
          <div class="absolute-bottom bg-transparent">
            <q-avatar size="56px" class="q-mb-sm">
              <img src="https://cdn.quasar.dev/img/boy-avatar.png">
            </q-avatar>
            <div class="text-weight-bold">{{profile.fullName}}</div>
            <div>{{profile.email}}</div>
          </div>
        </q-img>
      </q-drawer>

    <q-page-container>
      <router-view />
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
      country_name: null,
      profile: null
    }
  },
  computed: {
  },
  watch: {
    // call again the method if the route changes
    '$route': 'assignProfile',
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

      console.log('Checking for updates...')
      let version = await ApiService.getFrontendVersion()

      if(version != localStorageService.getWithExpiry(LocalStaticNames.FRONTEND_VERSION)){
        console.log(`Updating from current version: ${localStorageService.getWithExpiry(LocalStaticNames.FRONTEND_VERSION)}`)
        localStorageService.setWithExpiry(LocalStaticNames.FRONTEND_VERSION, version, 1440)
        console.log(`New version: ${localStorageService.getWithExpiry(LocalStaticNames.FRONTEND_VERSION)}`)
        location.reload()
      }else{
        console.log('You are running the latest version!')
      }
    },
    assignProfile(){
      let user = localStorageService.getWithExpiry(LocalStaticNames.USER_INFORMATION)

      user == null ? this.profile = null : this.profile = user
    },
    isLoggedIn(){
      return localStorageService.isLoggedIn()
    },
    logOut(){
      localStorageService.logoutUser()
      location.reload()
    }
  },
  async mounted () {
    this.getPublicIPAndLocation()
    this.todaysDate()
    await this.checkFrontendVersion()
    this.assignProfile()
  },
  updated() {
  },
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