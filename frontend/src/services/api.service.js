const { default: axios } = require("axios")



const ApiService = {
    logIp() {
        return new Promise(async (resolve, reject) => {
            await axios.get('https://track.linkancestors.com/weatherforecast')
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
            await axios.get(`http://ip-api.com/json/${ip}`)
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