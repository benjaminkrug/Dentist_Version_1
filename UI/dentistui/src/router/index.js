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
      path: '/Patient', component: () => import('../components/body/components/Patient/PatientMain.vue')
    },
    {
      path: '/Wartezimmer', component: () => import('../components/body/components/Wartezimmer/WartezimmerMain.vue')
    },
    {
      path: '/Rechnung', component: () => import('../components/body/components/Rechnung/RechnungMain.vue')
    },
    {
      path: '/Abrechnung', component: () => import('../components/body/components/Abrechnung/AbrechnungMain.vue')
    },
    {
      path: '/Einstellungen', component: () => import('../components/body/components/Einstellungen/EinstellungenMain.vue')
    },
    {
      path: '/Zusatzmodule', component: () => import('../components/body/components/Zusatzmodule/ZusatzmoduleMain.vue')
    },
    {
      path: '/test/backend', component: () => import('../components/body/test/TestBackend.vue')
    },
  ]
});

export default router;
