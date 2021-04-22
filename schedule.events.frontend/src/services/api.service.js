const { default: axios } = require("axios")
import localStorageService from '../storage/local.storage.service'

/*let trackApi = process.env.NODE_ENV === 'development' ? 'https://localhost:44387/' : 'https://track.linkancestors.com'
/*let backendApi = process.env.NODE_ENV === 'development' ? 'https://localhost:44364/' : 'https://api.linkancestors.com'
*/
// Test

let trackApi = 'https://track.linkancestors.com'
let backendApi = 'https://api.linkancestors.com'
let localhost = 'https://localhost:44364'

axios.defaults.headers.common['Authorization'] = `Bearer ${localStorageService.getToken()}`;
console.log('Fetch Token');

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
    async getcities(selected_country){
        return await axios.post('https://countriesnow.space/api/v0.1/countries/cities', {country: selected_country})
    },
    async register(details){
        await axios.post(`${backendApi}/Authentication/register`, details)
    },
    async login(details){
        return new Promise(async (resolve, reject) => {
            await axios.post(`${backendApi}/Authentication/login`, details)
                .then(response => {
                    return resolve(response.data)
                })
                .catch(response => {
                    return reject(response.data)
                })
        })
    },
    async createPost(postdetails){
        console.log(postdetails)
        return new Promise(async (resolve, reject) => {
            await axios.post(`${backendApi}/post/add?userid=4`, postdetails)
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
    async getPosts(geo){
        return new Promise(async (resolve, reject) => {
            await axios.post(`${backendApi}/post`, geo)
            .then(res => {
                return resolve({
                    result: res
                })
            })
            .catch(rej => {
                return reject({
                    result: rej.data
                })
            })
        })
    },
    async getProfile(){
        return new Promise(async (resolve, reject) => {
            await axios.get(`${backendApi}/user/profile`)
            .then(res => {
                return resolve({
                    result: res
                })
            })
            .catch(rej => {
                return reject({
                    result: rej.data
                })
            })
        })
    },
    async getPost(id){
        return new Promise(async (resolve, reject) => {
            await axios.get(`${backendApi}/post?id=${id}`)
            .then(res => {
                return resolve({
                    result: res
                })
            })
            .catch(rej => {
                return reject({
                    result: rej
                })
            })
        })
    },
    async postComment(postObject){
        return new Promise(async (resolve, reject) => {
            await axios.post(`${backendApi}/comment/add`, postObject)
            .then(res => {
                return resolve({
                    result: res
                })
            })
            .catch(rej => {
                return reject({
                    result: rej
                })
            })
        })
    }
}

export default ApiService;