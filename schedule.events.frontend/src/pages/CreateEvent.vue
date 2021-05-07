<template>
    <q-page class="window-width row justify-center items-center bg-grey-3" style="">
        <div>
        <div class="row">
            <h5 class="text-h5 q-my-md"><b>Create Event</b></h5>
        </div>
        <div class="row">
            <q-card square bordered class="q-pa-lg shadow-1">
            <q-card-section v-bind:class="{ activeDesktop: isDesktop}">
                <q-form class="q-gutter-md">
                <q-input square filled :rules="[val => !!val || 'Field is required']"
                 clearable v-model="Event_Name" type="text" label="Event Name" />
                <q-input square filled :rules="[val => !!val || 'Field is required']"
                 clearable v-model="Description" type="text" label="Description" />
                <q-input square filled :rules="[val => !!val || 'Field is required']"
                 v-model="StartsDate" mask="date" label="Select date">
                  <template v-slot:append>
                    <q-icon name="event" class="cursor-pointer">
                      <q-popup-proxy ref="qDateProxy" transition-show="scale" transition-hide="scale">
                          <q-date v-model="StartsDate">
                          <div class="row items-center justify-end">
                              <q-btn v-close-popup label="Close" color="primary" flat />
                          </div>
                          </q-date>
                      </q-popup-proxy>
                    </q-icon>
                  </template>
                </q-input>
                <q-input square filled :rules="[val => !!val || 'Field is required']"
                 v-model="Starts" type="time" label="Starts" />
                <q-input square filled :rules="[val => !!val || 'Field is required']"
                 v-model="Ends" type="time" label="Ends" />
                <q-select square filled :rules="[val => !!val || 'Field is required']"
                 outlined v-model="selected_country" @input="v => { onCountryChanged(v) }" :options="countryList" label="Select country" />
                <div v-if="cityList.length > 0">
                    <q-select square filled :rules="[val => !!val || 'Field is required']"
                     outlined v-model="selected_city" @input="v => { onCityChanged(v) }" :options="cityList" label="Select city"/>
                </div>
                <div>
                  <q-uploader
                    color="teal"
                    flat
                    style="width: inherit"
                    label="Upload event image - Max size 200kb"
                    :factory="uploadImage"
                    @uploaded="onAccepted"
                    @rejected="onRejected"
                    accept=".jpg, .png"
                    max-files="1"
                    max-total-size="201332"
                    auto-upload
                    
                  />
                </div>
                <div>
                    <q-editor v-model="content" min-height="8rem" />
                </div>
                </q-form>
            </q-card-section>
            <q-card-actions class="q-px-md">
                <q-btn v-if="isLoggedIn()" unelevated color="light-green-7" size="lg" class="full-width" label="Create Event" @click="createPost" />
                <q-btn disable v-else unelevated color="light-green-7" size="lg" class="full-width" label="Create Event" />
                <q-tooltip v-if="!isLoggedIn()" content-class="bg-purple" content-style="font-size: 16px">
                  You must be logged in to create events
                </q-tooltip>
            </q-card-actions>
            </q-card>
        </div>
        </div>
    </q-page>
</template>

<script>
import ApiService from '../services/api.service';
import localStorageService from '../storage/local.storage.service'
import { colors, Platform, QSpinnerGears, date } from 'quasar'

export default {

  data () {
    return {
      Event_Name: '',
      Description: '',
      content: 'Write your event description here',
      selected_country: 'default',
      countryList: [
        "Afghanistan",
        "Albania",
        "Algeria",
        "Andorra",
        "Angola",
        "Anguilla",
        "Antarctica",
        "Antigua and Barbuda",
        "Argentina",
        "Armenia",
        "Aruba",
        "Australia",
        "Austria",
        "Azerbaijan",
        "Bahamas (the)",
        "Bahrain",
        "Bangladesh",
        "Barbados",
        "Belarus",
        "Belgium",
        "Belize",
        "Benin",
        "Bermuda",
        "Bhutan",
        "Bolivia",
        "Bonaire, Sint Eustatius and Saba",
        "Bosnia and Herzegovina",
        "Botswana",
        "Bouvet Island",
        "Brazil",
        "British Indian Ocean Territory",
        "Brunei Darussalam",
        "Bulgaria",
        "Burkina Faso",
        "Burundi",
        "Cabo Verde",
        "Cambodia",
        "Cameroon",
        "Canada",
        "Cayman Islands",
        "Central African Republic",
        "Chad",
        "Chile",
        "China",
        "Christmas Island",
        "Colombia",
        "Comoros",
        "Congo",
        "Cook Islands",
        "Costa Rica",
        "Croatia",
        "Cuba",
        "Curaçao",
        "Cyprus",
        "Czechia",
        "Côte d'Ivoire",
        "Denmark",
        "Djibouti",
        "Dominica",
        "Dominican Republic",
        "Ecuador",
        "Egypt",
        "El Salvador",
        "Equatorial Guinea",
        "Eritrea",
        "Estonia",
        "Eswatini",
        "Ethiopia",
        "Falkland Islands",
        "Faroe Islands",
        "Fiji",
        "Finland",
        "France",
        "French Guiana",
        "French Polynesia",
        "French Southern Territories",
        "Gabon",
        "Gambia",
        "Georgia",
        "Germany",
        "Ghana",
        "Gibraltar",
        "Greece",
        "Greenland",
        "Grenada",
        "Guadeloupe",
        "Guam",
        "Guatemala",
        "Guernsey",
        "Guinea",
        "Guinea-Bissau",
        "Guyana",
        "Haiti",
        "Heard Island and McDonald Islands",
        "Holy See",
        "Honduras",
        "Hong Kong",
        "Hungary",
        "Iceland",
        "India",
        "Indonesia",
        "Iran",
        "Iraq",
        "Ireland",
        "Isle of Man",
        "Israel",
        "Italy",
        "Jamaica",
        "Japan",
        "Jersey",
        "Jordan",
        "Kazakhstan",
        "Kenya",
        "Kiribati",
        "Korea",
        "Kuwait",
        "Kyrgyzstan",
        "Lao People's Democratic Republic",
        "Latvia",
        "Lebanon",
        "Lesotho",
        "Liberia",
        "Libya",
        "Liechtenstein",
        "Lithuania",
        "Luxembourg",
        "Macao",
        "Madagascar",
        "Malawi",
        "Malaysia",
        "Maldives",
        "Mali",
        "Malta",
        "Marshall Islands",
        "Martinique",
        "Mauritania",
        "Mauritius",
        "Mayotte",
        "Mexico",
        "Micronesia",
        "Moldova",
        "Monaco",
        "Mongolia",
        "Montenegro",
        "Montserrat",
        "Morocco",
        "Mozambique",
        "Myanmar",
        "Namibia",
        "Nauru",
        "Nepal",
        "Netherlands",
        "New Caledonia",
        "New Zealand",
        "Nicaragua",
        "Niger",
        "Nigeria",
        "Niue",
        "Norfolk Island",
        "Northern Mariana Islands",
        "Norway",
        "Oman",
        "Pakistan",
        "Palau",
        "Palestine, State of",
        "Panama",
        "Papua New Guinea",
        "Paraguay",
        "Peru",
        "Philippines",
        "Pitcairn",
        "Poland",
        "Portugal",
        "Puerto Rico",
        "Qatar",
        "Republic of North Macedonia",
        "Romania",
        "Russian Federation",
        "Rwanda",
        "Réunion",
        "Saint Barthélemy",
        "Saint Helena, Ascension and Tristan da Cunha",
        "Saint Kitts and Nevis",
        "Saint Lucia",
        "Saint Martin",
        "Saint Pierre and Miquelon",
        "Saint Vincent and the Grenadines",
        "Samoa",
        "San Marino",
        "Sao Tome and Principe",
        "Saudi Arabia",
        "Senegal",
        "Serbia",
        "Seychelles",
        "Sierra Leone",
        "Singapore",
        "Sint Maarten",
        "Slovakia",
        "Slovenia",
        "Solomon Islands",
        "Somalia",
        "South Africa",
        "South Georgia and the South Sandwich Islands",
        "South Sudan",
        "Spain",
        "Sri Lanka",
        "Sudan",
        "Suriname",
        "Svalbard and Jan Mayen",
        "Sweden",
        "Switzerland",
        "Syrian Arab Republic",
        "Taiwan",
        "Tajikistan",
        "Tanzania, United Republic of",
        "Thailand",
        "Timor-Leste",
        "Togo",
        "Tokelau",
        "Tonga",
        "Trinidad and Tobago",
        "Tunisia",
        "Turkey",
        "Turkmenistan",
        "Turks and Caicos Islands",
        "Tuvalu",
        "Uganda",
        "Ukraine",
        "United Arab Emirates",
        "United Kingdom",
        "United States",
        "Uruguay",
        "Uzbekistan",
        "Vanuatu",
        "Venezuela",
        "Vietnam",
        "Virgin Islands",
        "Virgin Islands",
        "Wallis and Futuna",
        "Western Sahara",
        "Yemen",
        "Zambia",
        "Zimbabwe"
      ],
      selected_city: 'default',
      cityList: Array(),
      isDesktop: !this.$q.platform.is.mobile,
      file: "",
      Starts: "11 AM",
      Ends: "8 PM",
      StartsDate: ""
    }
  },
  methods: {
    async onCountryChanged(v){
      // Reset city list
      this.cityList = Array()

      // Fetch cities
      let cities = await ApiService.getcities(v)

      // Map cities
      this.mapCities(cities.data.data)
    },
    mapCities(cities){
      if(this.cityList == null || this.cityList == undefined) return;
      this.cityList = cities
      this.selected_city = cities[0]
    },
    async onCityChanged(v){
      console.log(this.selected_country)
      console.log(this.selected_city)
    },
    isLoggedIn(){
      return localStorageService.isLoggedIn()
    },
    uploadImage (file) {
      return new Promise((resolve, reject) => {
        // Retrieve JWT token from your store.
        resolve({
          url: 'https://api.linkancestors.com/upload',
          method: 'POST',
          headers: [
            { name: 'Access-Control-Allow-Origin', value: '*' },
            { name: 'Authorization', value: `Bearer ${localStorageService.getToken()}` }
          ]
        })
    })
    },
    onAccepted (server){
      this.file = server.xhr.response
    },
    async createPost(){
      console.log('HIT!')
      let timeStamp = Date.now()
      let formattedString = date.formatDate(timeStamp, 'YYYY-MM-DDTHH:mm:ss.SSSZ')
      this.$q.loading.show({
        message: 'Creating event...'
      })
      await ApiService.createPost({
        Title: this.Event_Name,
        Description: this.Description,
        Content: this.content,
        DateStarts: formattedString,
        Starts: this.Starts,
        Ends: this.Ends,
        Country: this.selected_country,
        City: this.selected_city,
        Image: this.file
      })
      .then(async res => {
        console.log('ok?')
        await this.showLoading('Event created successfully!', 'green')
        this.$destroy()
        this.$router.push('/')
      })
      .catch(async rej => {
        await this.showLoading('Server error - Try again', 'red')
      })
    },
      showLoading (msg, color) {

      this.timer = setTimeout(async () => {
        this.$q.loading.show({
          spinner: QSpinnerGears,
          spinnerColor: color,
          message: msg
        })

        this.timer = setTimeout(async () => {
          this.$q.loading.hide()
          this.timer = void 0
        }, 3000)
      }, 2000)
      return new Promise(resolve => setTimeout(resolve, 5000));
    },
    onRejected(file){
      this.$q.notify({
        position: "bottom",
        timeout: 4000,
        multiLine: true,
        message: `The file does not meet requirements \n Reason: File is too large. ${(file[0].file.size) / 1000}kb exceeds 200kb`,
        textColor: "white",
        color: "red"
      })
    }

  },
  mounted () {

  }
}
</script>

<style scoped>
    .input-spacer-padding{
        padding: 5px;
    }

    .activeDesktop{
        max-width: 45rem !important;
        width: 45rem !important;
        margin: auto !important;
    }
</style>