<template>
  <q-page class="flex-center q-pa-sm bg-grey-3">
    <div>
      <div class="relative-position">
        <div v-if="$q.platform.is.desktop" class="row">
          <div class="col">
            <h3 style="margin-top: 0px">Search</h3>
          </div>
          <div class="q-gutter-sm">
            <q-checkbox class="show-all-checkbox" left-label v-model="show_all" label="Show all" @input="onShowAllChanged" />
          </div>
          <div class="col">
            <q-select rounded outlined :disable="show_all" v-model="selected_country" @input="v => { onCountryChanged(v) }" :options="countryList" label="Select country" />
          </div>
          <div class="col">
            <div v-if="cityList.length > 0">
              <q-select rounded outlined :disable="show_all" v-model="selected_city" @input="v => { onCityChanged(v) }" :options="cityList" label="Select city" />
            </div>
            <div v-if="cityList.length <= 0">
              <q-select rounded outlined :disable="show_all || cityList.length <= 0" v-model="selected_city" :options="cityList" label="Select city" />
            </div>
          </div>
        </div>
        <div v-else>
          <div class="col">
            <h3 style="margin-top: 0px; margin-bottom: 5px">Search</h3>
          </div>
          <div class="q-gutter-sm">
            <q-checkbox class="show-all-checkbox" left-label v-model="show_all" label="Show all" @input="onShowAllChanged"/>
          </div>
          <div class="col" style="margin-top: 0px">
            <q-select rounded outlined :disable="show_all" v-model="selected_country" @input="v => { onCountryChanged(v) }" :options="countryList" label="Select country" />
          </div>
          <div class="col" style="margin-top: 0px">
            <div v-if="cityList.length > 0">
              <q-select rounded outlined :disable="show_all" v-model="selected_city" @input="v => { onCityChanged(v) }" :options="cityList" label="Select city" />
            </div>
            <div v-if="cityList.length <= 0">
              <q-select rounded outlined :disable="show_all || cityList.length <= 0" v-model="selected_city" :options="cityList" label="Select city" />
            </div>
          </div>
        </div>
      </div>
      <div v-if="posts.length > 0">
      <q-infinite-scroll @load="getAdditionalPosts" :offset="800">
      <div class="content-events card-above-create-event" v-for="(event, index) in posts" :key="index">
        <q-card class="my-card">
        
        <q-img v-if="event.image != ''" :src="event.image" />
        <q-img v-else src="https://api.linkancestors.com/download?websitePath=4/27e888de-dd14-4c41-9196-1ab340338101no-image.png" style="max-height: 405px; object-fit: contain;" />
        <q-card-section>
          <q-btn
            fab
            color="primary"
            icon="place"
            class="absolute"
            style="top: 0; right: 12px; transform: translateY(-50%);"
            @click="$router.push(`/view-event?id=${event.id}`)"
          />

          <div class="row no-wrap items-center">
            <div class="col text-h6 ellipsis">
              {{event.title}}
            </div>
            <div class="col-auto text-grey text-caption q-pt-md row no-wrap items-center">
              <q-icon name="place" />
              {{event.city}} - 
              {{event.country}}
            </div>
          </div>

          <q-rating v-model="stars" :max="5" size="32px" />
        </q-card-section>

        <q-card-section class="q-pt-none">
          <div class="text-subtitle1">
            $・{{event.description}}
          </div>
          <div class="text-caption text-grey" v-html="event.content">
          </div>
        </q-card-section>

        <q-separator />
        <div class="row">
                  <q-card-actions>
          <q-btn flat round icon="event" />
          <q-btn flat color="primary">
            Attend
          </q-btn>
        </q-card-actions>
        <q-card-actions>
          <q-btn flat round icon="event" />
          <q-btn flat color="primary">
            Maybe
          </q-btn>
        </q-card-actions>
        <q-card-actions>
          <q-btn flat round icon="event" />
          <q-btn flat color="primary">
            Decline
          </q-btn>
        </q-card-actions>
        </div>
      </q-card>
      </div>
      <template v-slot:loading>
        <div class="row justify-center q-my-md">
          <q-spinner-dots color="primary" size="40px" />
        </div>
      </template>
      </q-infinite-scroll>
      </div>
      <div v-else class="center">
        <div>
          <div class="text-h1">No Content</div>
          <div class="text-subtitle1">- Click search and select your area</div>
        </div>
      </div>
      <div class="relative-position absolute-bottom">
        <q-btn class="btn-full-width" @click="$router.push('/create-event')" color="blue" outlined label="Create event" />
      </div>
    </div>
  </q-page>
</template>

<script>
import ApiService from '../services/api.service';
import { colors, Platform, QSpinnerGears } from 'quasar'

export default {
  name: 'frontpage',

  data () {
    return {
      test_events: [
        {id: 1, name: "event name 1"},
        {id: 2, name: "event name 2"}
      ],
      selected_country: 'default',
      last_selected_country: '',
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
      cityList: [],
      posts: [],
      stars: 4,
      RangeFrom: 0,
      show_all: true
    }
  },
  created() {
    this.onShowAllChanged()
  },
  methods: {
    async onCountryChanged(v){
      // Show loading
      this.$q.loading.show({
        message: 'Loading event...'
      })

      this.RangeFrom = 0
      this.posts = []

      // Reset city list
      this.cityList = Array()

      // Fetch cities
      let cities = await ApiService.getcities(v)

      if(this.last_selected_country != this.selected_country){
        this.posts = []
      }

      this.last_selected_country = this.selected_country;

      // Map cities
      this.mapCities(cities.data.data)
    },
    mapCities(cities){
      if(this.cityList == null || this.cityList == undefined) return;
      this.cityList = cities
      this.selected_city = cities[0]
      this.$q.loading.hide()
      this.onCityChanged(cities[0])
    },
    async onCityChanged(v){
      this.$q.loading.show({
        message: 'Loading...'
      })

      this.RangeFrom = 0
      this.posts = []

      await ApiService.getPosts({
        Country: this.selected_country,
        City: this.selected_city,
        RangeFrom: this.RangeFrom
      })
      .then(res => {
        console.log('ok-?')
        console.log(res)
        this.posts = res.result.data
        this.$q.loading.hide()
      })
      .catch(rej => {
        console.log("fuck-")
        this.posts = []
        this.$q.loading.hide()
      })
    },
    async getAdditionalPosts(index, done){
      this.RangeFrom += 10

      await ApiService.getPosts({
        Country: this.selected_country,
        City: this.selected_city,
        RangeFrom: this.RangeFrom
      })
      .then(res => {
        if(res.result.status == 204){
          done(true)
          return;
        }
        
        if(this.posts){
          for (let index = 0; index < res.result.data.length; index++) {
            this.posts.push(res.result.data[index])
          }
          done()
        }
      })
      .catch(rej => {
        console.log('error')
        done()
      })
    },
    async onShowAllChanged(value, evt){
      console.log(value)

      this.RangeFrom = 0

      if(value == false){
        this.posts = []
      }

      if(value == true || value == undefined){
        await ApiService.getPosts({
        Country: null,
        City: null,
        RangeFrom: this.RangeFrom
      })
      .then(res => {
        console.log('ok-?')
        console.log(res)
        this.posts = res.result.data
        this.$q.loading.hide()
      })
      .catch(rej => {
        console.log("fuck-")
        this.posts = []
        this.$q.loading.hide()
      })

      }


    }


  },
  mounted () {

  }
}
</script>

<style lang="scss">
.btn-full-width{
  width: 100%;
}
.my-card{
  width: 100%;
  max-width: 45rem;
  margin: auto;
  margin-top: 2rem;
}
.card-above-create-event{
  margin-bottom: 3rem;
}

.center {
  margin: auto;
  width: 100%;
  height: 100%;
  padding: 5px;
  text-align: center;
  line-height: 100px;
  text-align: center;
  display: inline-block;
  vertical-align: middle;
}

.show-all-checkbox{
  min-width: 56px !important;
  min-height: 56px !important;
}
</style>
