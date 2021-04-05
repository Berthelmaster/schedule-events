<template>
  <q-page class="flex-center q-pa-sm bg-grey-3">
    <div class="column absolute-center relative-position mobile-width">
      <div class="row">
        <h5 class="text-h5 q-my-md"><b>Register</b></h5>
      </div>
      <div class="row">
        <q-card square bordered class="q-pa-lg shadow-1">
          <q-card-section>
            <q-form class="q-gutter-md">
              <q-input square filled clearable v-model="fullname" type="text" label="Full name" />
              <q-input square filled v-model="birth" mask="date" label="Birth">
                  <template v-slot:append>
                    <q-icon name="event" class="cursor-pointer">
                    <q-popup-proxy ref="qDateProxy" transition-show="scale" transition-hide="scale">
                        <q-date v-model="birth">
                        <div class="row items-center justify-end">
                            <q-btn v-close-popup label="Close" color="primary" flat />
                        </div>
                        </q-date>
                    </q-popup-proxy>
                    </q-icon>
                </template>
              </q-input>
              <q-input square filled clearable v-model="email" type="email" label="Email" />
              <q-input square filled clearable v-model="password" type="password" label="Password" />
            </q-form>
          </q-card-section>
          <q-card-actions class="q-px-md">
            <q-btn unelevated color="light-green-7" size="lg" class="full-width" label="Login" @click="Register()" />
          </q-card-actions>
          <q-card-section class="text-center q-pa-none">
            <p class="text-grey-6">Already reigistered? <router-link to="/login">Go to Login</router-link></p>
          </q-card-section>
        </q-card>
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
        email: '',
        password: '',
        fullname: '',
        birth: '2019/02/01'
    }
  },
  methods: {
    async Register(){
      let attempt = await ApiService.register({
        email: this.email,
        password: this.password,
        fullname: this.fullname,
        birth: this.birth
      })
      console.log(attempt);
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