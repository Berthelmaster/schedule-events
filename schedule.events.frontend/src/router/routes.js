import Register from '../pages/Register'

const routes = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      { name: 'frontpage', path: '', component: () => import('src/pages/Frontpage.vue')},
      { name: 'login', path: 'login', component: () => import('src/pages/Login.vue')},
      { name: 'register',path: 'register', component: Register},
      { name: 'create-event', path: 'create-event', component: () => import('src/pages/CreateEvent.vue')},
      { name: 'profile', path: 'profile', component: () => import('src/pages/Profile.vue')},
      { name: 'about-and-donate', path: 'about-and-donate', component: () => import('src/pages/About.vue')}
    ],
  },
  {
    path: '*',
    component: () => import('pages/Error404.vue')
  }
]

export default routes
