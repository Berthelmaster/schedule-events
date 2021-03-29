const { default: axios } = require("axios")

/*let trackApi = process.env.NODE_ENV === 'development' ? 'https://localhost:44387/' : 'https://track.linkancestors.com'
/*let backendApi = process.env.NODE_ENV === 'development' ? 'https://localhost:44364/' : 'https://api.linkancestors.com'
*/
// Test

let trackApi = 'https://track.linkancestors.com'
let backendApi = 'https://api.linkancestors.com'

const ApiService = {
    logIp() {
        return new Promise(async (resolve, reject) => {
            await axios.get(trackApi)
            .then(res => {
                return resolve({
                    result: res.data
                })
            })
            .catch(rej => {
                return reject({
                    result: rej.data
                })
            })
        })
    },
    getLocation(ip) {
        return new Promise(async (resolve, reject) => {
            await axios.get(`https://ipapi.co/${ip}/json/`)
            .then(res => {
                if(res.status == 200){
                    return resolve({
                        result: res.data
                    })
                }else{
                    return reject({
                        result: res.data
                    })
                }
                
            })
            .catch(rej => {
                return reject({
                    result: res.data
                })
            })
        })
    },
    postLocation(geolocation) {
        return new Promise(async (resolve, reject) => {
            await axios.post(trackApi, geolocation)
            .then(res => {
                return resolve({
                    result: res.data
                })
            })
            .catch(rej => {
                return reject({
                    result: rej.data
                })
            })
        })
    },
    getSubreddit(page) {
        return new Promise(async (resolve, reject) => {
            await axios.get(`https://www.reddit.com/r/${page}/new.json?sort=best`)
            .then(res => {
                return resolve({
                    result: res.data
                })
            })
            .catch(rej => {
                return reject({
                    result: rej.data
                })
            })
        })
    },
    async getFrontendVersion(){
        return await axios.get(`${backendApi}/Version`)
            .then(res => {
                return res.data
            })
    },
    async getcities(selected){
        return await axios.post('https://countriesnow.space/api/v0.1/countries/cities', {country: selected})
    }
}

export default ApiService;