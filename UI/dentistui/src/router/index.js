import Vue from "vue";
import Router from "vue-router";


Vue.use(Router);

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '', component: () => import('../components/body/components/Tagesbehandlungen/Rezeption/RezeptionMain.vue')
    },
    {
      path: '/Tagesbehandlungen',
      component: () => import('../components/body/components/Tagesbehandlungen/TagesbehandlungenMain.vue'),
      children: [
        {
          // UserProfile will be rendered inside User's <router-view>
          // when /user/:id/profile is matched
          path: 'Behandlungsraum',
          component: () => import('../components/body/components/Tagesbehandlungen/Behandlungsraum/BehandlungsraumMain.vue'),
          props: true
        }
      ]

    },
    {
      path: '/Patient', component: () => import('../components/body/components/Patient/PatientMain.vue')
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
