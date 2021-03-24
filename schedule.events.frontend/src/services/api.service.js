const { default: axios } = require("axios")

let trackApi = process.env.NODE_ENV === 'development' ? 'https://localhost:44387/' : 'https://track.linkancestors.com'
let backendApi = process.env.NODE_ENV === 'development' ? 'https://localhost:44364/' : 'https://api.linkancestors.com'

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
                console.log(res.data.status)
                if(res.data.status == 'success'){
                    console.log('resolving...')
                    return resolve({
                        result: res.data
                    })
                }else{
                    console.log('qwdqw')
                    console.log(res.data.status)
                    return reject({
                        result: res.data
                    })
                }
                
            })
            .catch(rej => {
                console.log('rejecting...')
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
            await axios.get(`http://www.reddit.com/r/${page}/new.json?sort=best`)
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
    }
}

export default ApiService;