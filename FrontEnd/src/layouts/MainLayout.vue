<template>
  <q-layout view="lHh lpR fFf">
    <q-header elevated class="bg-white text-black">
      <q-toolbar>
        <q-btn
          unelevated
          icon="menu"
          @click="showLeftMenu = false"
          v-if="showLeftMenu"
        />
        <q-btn
          unelevated
          icon="menu_open"
          @click="showLeftMenu = true"
          v-else
        />
        <q-breadcrumbs
          active-color="black"
          gutter="none"
          style="font-size: 16px"
          dense
        >
          <q-breadcrumbs-el label="Home" />
          <q-breadcrumbs-el label="Components" />
          <q-breadcrumbs-el label="Toolbar" />
        </q-breadcrumbs>

        <q-space />
        <q-input
          dense
          outlined
          v-model="search"
          placeholder="Search for all"
          style="width: 300px"
        />

        <div class="q-gutter-y-md" style="max-width: 600px">
          <q-tabs
            v-model="tab"
            inline-label
            no-caps
            active-color="primary"
            align="right"
          >
            <q-tab name="mails" label="Home" />
            <q-tab name="alarms" label="View" />
            <q-tab name="admin" label="Admin" />
          </q-tabs>
        </div>
        <div class="q-px-sm q-gutter-sm row items-center no-wrap">
          <q-btn
            v-if="$q.screen.gt.xs"
            dense
            flat
            round
            size="sm"
            icon="notifications"
          />

          <q-avatar size="40px" rounded style="border-radius: 8px">
            <img src="../assets/images/profile.jpg" />
          </q-avatar>

          <q-menu
            fit
            :offset="[0, 20]"
            anchor="top middle"
            self="bottom middle"
          >
            <q-list style="min-width: 40px" dense>
              <q-item clickable v-close-popup to="/user/profile">
                <q-item-section>个人中心</q-item-section>
              </q-item>
              <q-item clickable v-close-popup>
                <q-item-section>布局设置</q-item-section>
              </q-item>
              <q-separator />
              <q-item clickable v-close-popup>
                <q-item-section aria-label="sdf">退出登录</q-item-section>
              </q-item>
            </q-list>
          </q-menu>
        </div>
      </q-toolbar>
    </q-header>

    <q-drawer show-if-above v-model="showLeftMenu" side="left" :width="200">
      <q-scroll-area class="fit" style="background-color: #304156">
        <div
          class="row text-white justify-start items-center"
          style="padding-left: 20px; height: 50px"
        >
          <img src="../assets/images/logo.png" width="42" height="30" />
          <div style="line-height: 30px; margin-left: 10px; margin-right: 10px">
            |
          </div>
          <div class="text-white" style="line-height: 30px">MIA</div>
        </div>
        <q-list>
          <q-expansion-item
            expand-separator
            icon="perm_identity"
            class="text-white"
            style="background-color: #304156"
            label="系统管理"
          >
            <template v-for="(menuItem, index) in menuList" :key="index">
              <q-item
                clickable
                :active="menuItem.label === 'Outbox'"
                v-ripple
                class="bg-blue-grey-10"
                @click="menuClick"
                :to="menuItem.to"
              >
                <q-item-section avatar class="q-pl-md">
                  <q-icon :name="menuItem.icon" />
                </q-item-section>
                <q-item-section>
                  {{ menuItem.label }}
                </q-item-section>
              </q-item>
              <q-separator :key="'sep' + index" v-if="menuItem.separator" />
            </template>
          </q-expansion-item>
          <q-separator />
        </q-list>
      </q-scroll-area>
    </q-drawer>

    <q-page-container class="q-pa-md">
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script lang="ts" setup>
import { ref } from 'vue';
import { useRouter } from 'vue-router';
const router = useRouter();

const tab = ref('mails');
const showLeftMenu = ref(false);
const menuList = ref([
  {
    icon: 'perm_identity',
    label: '用户管理',
    separator: false,
    to: '/home/user',
  },
  {
    icon: 'menu',
    label: '角色管理',
    separator: false,
    to: '/home/role',
  },
]);
const search = ref(null);
const menuClick = () => {
  router.push('/home/miarole');
};
</script>

<style lang="scss" scoped>
.logoBtn::after {
  content: '|DMSTest1003_8';
}
.logBtn {
  min-width: 180px;
}
</style>
