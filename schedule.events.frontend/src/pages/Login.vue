<template>
  <q-page class="flex-center q-pa-sm bg-grey-3">
    <div class="column absolute-center relative-position mobile-width">
      <div class="row">
        <h5 class="text-h5 text-white q-my-md"><b>Login</b></h5>
      </div>
      <div class="row">
        <q-card square bordered class="q-pa-lg shadow-1">
          <q-card-section>
            <q-form class="q-gutter-md">
              <q-input square filled clearable v-model="email" type="email" label="email" />
              <q-input square filled clearable v-model="password" type="password" label="password" />
            </q-form>
          </q-card-section>
          <q-card-actions class="q-px-md">
            <q-btn unelevated color="light-green-7" size="lg" class="full-width" label="Login" @click="Login()" />
          </q-card-actions>
          <q-card-section class="text-center q-pa-none">
            <p class="text-grey-6">Not reigistered? <router-link to="/register">Go to Register</router-link></p>
          </q-card-section>
        </q-card>
      </div>
    </div>
  </q-page>
</template>

<script>
import ApiService from '../services/api.service';
import localStorageService from '../storage/local.storage.service'
import LocalStaticNames from '../storage/storage.static.names'

export default {
  name: 'PageIndex',

  data () {
    return {
        email: '',
        password: ''
    }
  },
  methods: {

    async Login(){

      this.$q.loading.show()

      await ApiService.login({
        email: this.email,
        password: this.password
      })
      .then(res => {
        // If Successful
        localStorageService.setWithExpiry(LocalStaticNames.USER_INFORMATION, res, 14400) // 10 days expiration

        this.axios.defaults.headers.common['Authorization'] = `Bearer ${localStorageService.getToken()}`;

        this.$q.loading.hide()

        this.$router.push('/')
      })
      .catch(rej => {
        this.$q.loading.hide()
        this.showNotif()
        console.log('error')
      })
    },
    showNotif () {
      this.$q.notify({
        message: 'Error attemping login - Email or password is incorrect',
        caption: 'Server Error',
        color: 'purple'
      })
    }
  },
  mounted () {

  }
}
</script>

<style scoped>
    .mobile-width{
        min-width: 300px !important;
    }
</style>
