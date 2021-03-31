<template>
    <q-page class="window-height window-width row justify-center items-center bg-grey-3" style="padding: 5px;">
        <div class="column relative-position mobile-width">
        <div class="row">
            <h5 class="text-h5 text-black q-my-md"><b>Create Event</b></h5>
        </div>
        <div class="row">
            <q-card square bordered class="q-pa-lg shadow-1">
            <q-card-section>
                <q-form class="q-gutter-md">
                    <div class="row">
                    <div class="column">
                        <q-input class="input-spacer-padding" square filled clearable v-model="email" type="email" label="email"/>
                        <q-input class="input-spacer-padding" square filled clearable v-model="password" type="password" label="password" />
                        <q-input class="input-spacer-padding" square filled clearable v-model="password" type="password" label="password" />
                        <q-input class="input-spacer-padding" square filled clearable v-model="password" type="password" label="password" />
                    </div>
                        <div class="column">
                        <q-input class="input-spacer-padding" square filled clearable v-model="email" type="email" label="email" />
                        <q-input class="input-spacer-padding" square filled clearable v-model="password" type="password" label="password" />
                        <q-input class="input-spacer-padding" square filled clearable v-model="password" type="password" label="password" />
                        <q-input class="input-spacer-padding" square filled clearable v-model="password" type="password" label="password" />
                    </div>
                    </div>
                    <q-editor v-model="editor" min-height="5rem" />
                </q-form>
            </q-card-section>
            <q-card-actions class="q-px-md">
                <q-btn unelevated color="light-green-7" size="lg" class="full-width" label="Create Event" />
            </q-card-actions>
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
        editor: 'Write your event description here'
    }
  },
  methods: {

  },
  mounted () {

  }
}
</script>

<style scoped>
    .input-spacer-padding{
        padding: 5px;
    }
</style>