<template>
  <q-page class="flex-center q-pa-sm bg-grey-3">
    <div class="">
      <div>
        <div v-if="$q.platform.is.desktop" class="row">
          <div class="col">
            <h3 style="margin-top: 0px">Search</h3>
          </div>
          <div class="col">
            <q-select rounded outlined v-model="selected_country" @input="v => { onCountryChanged(v) }" :options="countryList" label="Select country" />
          </div>
          <div class="col">
            <div v-if="cityList.length > 0">
              <q-select rounded outlined v-model="selected_city" :options="cityList" label="Select country" />
            </div>
            <div v-if="cityList.length <= 0">
              <q-select rounded outlined v-model="selected_city" disable :options="cityList" label="Select city" />
            </div>
          </div>
        </div>
        <div v-else>
          <div class="col">
            <h3 style="margin-top: 0px; margin-bottom: 5px">Search</h3>
          </div>
          <div class="col" style="margin-top: 0px">
            <q-select rounded outlined v-model="selected_country" @input="v => { onCountryChanged(v) }" :options="countryList" label="Select country" />
          </div>
          <div class="col" style="margin-top: 0px">
            <div v-if="cityList.length > 0">
              <q-select rounded outlined v-model="selected_city" @input="v => { onCityChanged(v) }" :options="cityList" label="Select country" />
            </div>
            <div v-if="cityList.length <= 0">
              <q-select rounded outlined v-model="selected_city" disable :options="cityList" label="Select city" />
            </div>
          </div>
        </div>
      </div>
      <div class="content-events">
        <li v-for="event in test_events" :key="event.id">
          {{event.name}}
        </li>
      </div>
      <div>
        <q-btn class="" color="blue" outlined label="Create event" />
      </div>
    </div>
  </q-page>
</template>

<script>
import ApiService from '../services/api.service';
import { Platform } from 'quasar'

export default {
  name: 'PageIndex',

  data () {
    return {
      test_events: [
        {id: 1, name: "event name 1"},
        {id: 2, name: "event name 2"}
      ],
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
      cityList: Array()
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
    },
    async onCityChanged(v){
      console.log(this.selected_country)
      console.log(this.selected_city)
    }

  },
  mounted () {

  }
}
</script>

<style lang="scss">
</style>
