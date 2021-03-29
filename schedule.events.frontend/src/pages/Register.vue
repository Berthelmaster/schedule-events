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
              <q-input square filled clearable v-model="fullname" type="text" label="full name" />
              <q-input square filled v-model="date" mask="date">
                  <template v-slot:append>
                    <q-icon name="event" class="cursor-pointer">
                    <q-popup-proxy ref="qDateProxy" transition-show="scale" transition-hide="scale">
                        <q-date v-model="date">
                        <div class="row items-center justify-end">
                            <q-btn v-close-popup label="Close" color="primary" flat />
                        </div>
                        </q-date>
                    </q-popup-proxy>
                    </q-icon>
                </template>
              </q-input>
              <q-input square filled clearable v-model="password" type="text" label="password" />
              <q-input square filled clearable v-model="password" type="text" label="password" />
              <q-input square filled clearable v-model="email" type="email" label="email" />
              <q-input square filled clearable v-model="password" type="password" label="password" />
            </q-form>
          </q-card-section>
          <q-card-actions class="q-px-md">
            <q-btn unelevated color="light-green-7" size="lg" class="full-width" label="Login" />
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

export default {
  name: 'PageIndex',

  data () {
    return {
        email: '',
        password: '',
        fullname: '',
        date: '2019/02/01'
    }
  },
  methods: {

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