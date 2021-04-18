<template>
    <q-page class="flex-center q-pa-sm bg-grey-3">
      <q-field filled label="Email" stack-label>
        <template v-slot:control>
          <div class="self-center full-width no-outline" tabindex="0">{{profile.email}}</div>
        </template>
      </q-field>
      <q-field filled label="Full name" stack-label>
        <template v-slot:control>
          <div class="self-center full-width no-outline" tabindex="1">{{profile.fullName}}</div>
        </template>
      </q-field>
      <q-field filled label="Birthday" stack-label>
        <template v-slot:control>
          <div class="self-center full-width no-outline" tabindex="2">{{profile.birthday}}</div>
        </template>
      </q-field>
      <q-field filled label="Is Approved" stack-label>
        <template v-slot:control>
          <div v-if="profile.isApproved" class="self-center full-width no-outline" tabindex="3">Yes</div>
          <div v-if="!profile.isApproved" class="self-center full-width no-outline" tabindex="3">No</div>
        </template>
      </q-field>
      <q-field filled label="My role" stack-label>
        <template v-slot:control>
          <div class="self-center full-width no-outline" tabindex="4">{{profile.role}}</div>
        </template>
      </q-field>
    </q-page>
</template>

<script>
import ApiService from '../services/api.service';

export default {
    data() {
        return{
            profile: []
        }
    },
    methods: {
        async getProfile(){
            await ApiService.getProfile()
            .then(res => {
                this.profile = res.result.data
            })
            .catch(rej => {
                this.profile = null;
            })
        }
    },
    async created() {
        await this.getProfile();
    }
}
</script>
