import { RouteRecordRaw } from 'vue-router';

import MainLayout from 'layouts/MainLayout.vue';

const routes: RouteRecordRaw[] = [
  {
    path: '/home',
    component: () => MainLayout,
    children: [
      { path: '', component: () => import('src/pages/MHome.vue') },
      {
        path: 'role',
        component: () => import('src/pages/MRole.vue'),
      },
      {
        path: 'user',
        component: () => import('src/pages/MUser.vue'),
      },
    ],
  },
  {
    path: '/',
    component: () => import('src/pages/MLogin.vue'),
  },
  {
    path: '/user',
    component: MainLayout,
    children: [
      {
        path: 'profile',
        component: () => import('src/pages/system/user/MProfile.vue'),
        name: 'Profile',
        meta: { title: '个人中心', icon: 'user' },
      },
    ],
  },

  // Always leave this as last one,
  // but you can also remove it
  {
    path: '/:catchAll(.*)*',
    component: () => import('pages/ErrorNotFound.vue'),
  },
];

export default routes;
