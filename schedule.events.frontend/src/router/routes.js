
const routes = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      { path: '', component: () => import('src/pages/Frontpage.vue') },
      { path: 'login', component: () => import('src/pages/Login.vue')},
      { path: 'register', component: () => import('src/pages/Register.vue')},
      { path: 'create-event', component: () => import('src/pages/CreateEvent.vue')},
      { path: 'profile', component: () => import('src/pages/Profile.vue')},
      { path: 'about-and-donate', component: () => import('src/pages/About.vue')}
    ],
  },
  {
    path: '*',
    component: () => import('pages/Error404.vue')
  }
]

export default routes
