<template>
  <q-layout view="lHh Lpr lFf">
    <q-header>
      <q-toolbar>
        <q-btn
          flat
          dense
          round
          icon="menu"
          aria-label="Menu"
          @click="leftDrawerOpen = !leftDrawerOpen"
        />
        </q-toolbar>
        <div class="q-px-lg q-pt-xl q-mb-md">
          <q-toolbar-title>
            <div class="row">
              <div>Schedule Events</div>
              <q-space />
              <q-btn class="q-mr-sm" color="secondary" icon-right="mail" label="Login" />
              <q-btn class="q-ml-sm" color="secondary" icon-right="mail" label="Register" />
            </div>
          </q-toolbar-title>
        </div>
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

        <q-img class="absolute-top" src="../assets/water.jpg" style="height: 150px">
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
    getPublicIPAndLocation() {
    this.publicIp = ApiService.logIp().then(async (res) => {

      ApiService.getLocation(res.result)
        .then(async (response) => {

          this.publicIp = `Network IP: ${res.result} from ${response.result.country}`
          console.log(response.result)
          await ApiService.postLocation(response.result)

        })
        .catch(async (rejecte) => {

          this.publicIp = `Network IP: ${res.result}`

        })
    })
    }
  },
  mounted () {
    this.getPublicIPAndLocation()
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
</style>