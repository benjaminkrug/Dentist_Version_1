import Vue from "vue";
import Router from "vue-router";


Vue.use(Router);

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '', component: () => import('../components/body/components/BodyMain.vue')
    },
    {
      path: '/test/backend', component: () => import('../components/body/test/TestBackend.vue')
    },
  ]
});

export default router;
