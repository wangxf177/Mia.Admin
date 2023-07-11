<template>
  <div class="row q-pa-lg">
    <div class="col-4 q-pr-lg">
      <q-card>
        <q-list bordered separator inset>
          <q-item>
            <q-item-section class="text-subtitle1">个人信息</q-item-section>
          </q-item>
          <q-item class="row justify-center">
            <q-avatar size="120px">
              <img src="../../../assets/images/profile.jpg" />
            </q-avatar>
          </q-item>
          <q-item>
            <q-item-section> 用户名称 </q-item-section>
            <q-item-section style="text-align: right"> admin </q-item-section>
          </q-item>
          <q-item>
            <q-item-section> 手机号码 </q-item-section>
            <q-item-section style="text-align: right">
              13688888888
            </q-item-section>
          </q-item>
          <q-item>
            <q-item-section> 用户邮箱 </q-item-section>
            <q-item-section style="text-align: right">
              wangxf177@163.com
            </q-item-section>
          </q-item>
          <q-item>
            <q-item-section> 所属部门 </q-item-section>
            <q-item-section style="text-align: right">
              研发部门 / 董事长
            </q-item-section>
          </q-item>
          <q-item>
            <q-item-section> 所属角色 </q-item-section>
            <q-item-section style="text-align: right">
              超级管理员
            </q-item-section>
          </q-item>
          <q-item>
            <q-item-section> 创建日期 </q-item-section>
            <q-item-section style="text-align: right">
              2023-04-23 16:11:38
            </q-item-section>
          </q-item>
        </q-list>
      </q-card>
    </div>
    <div class="col-8">
      <q-card>
        <q-list bordered>
          <q-item>
            <q-item-section class="text-subtitle1">基本资料</q-item-section>
          </q-item>

          <q-separator></q-separator>

          <q-item class="q-pb-none">
            <q-tabs inline-label no-caps active-color="primary" align="right">
              <q-tab name="mails" label="基本资料" />
              <q-tab name="alarms" label="修改密码" />
            </q-tabs>
          </q-item>

          <q-separator inset></q-separator>

          <q-item>
            <q-form @submit="onSubmit" class="row full-width">
              <q-item-section class="row-3"> 用户昵称 </q-item-section>
              <q-item-section class="row-9" style="text-align: right"
                ><q-input
                  dense
                  outlined
                  v-model="verificationCode"
                  maxlength="20"
                  :placeholder="$t('login.password')"
                >
                </q-input
              ></q-item-section>
              <q-input
                outlined
                dense
                v-model="verificationCode"
                maxlength="20"
                :placeholder="$t('login.password')"
                label="用户昵称"
                style="width: 100%"
              >
              </q-input
              ><q-input
                outlined
                dense
                v-model="verificationCode"
                maxlength="20"
                :placeholder="$t('login.password')"
                label="用户昵称"
                style="width: 100%"
              >
              </q-input>
            </q-form>
          </q-item>
        </q-list>
      </q-card>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { ref } from 'vue';
const verificationCode = ref('');
const onSubmit = () => {
  console.log(111);
};
</script>

<style lang="scss" scoped>
.root {
  background-color: #f0f0f0;
  width: 1000px;
  height: 800px;
  padding: 30px 20px 0 20px;
}
.left {
  width: 400px;
  height: 600px;
  float: left;
}
.right {
  float: left;
  background-color: white;
  width: calc(100%-500px);
  height: 500px;
}
.div1 {
  height: 65px;
  width: 360px;
  background-color: red;
}
.div2 {
  height: 65px;
  width: 360px;
  background-color: white;
}

.div3 {
  height: 130px;
  width: 360px;
  position: absolute;
  padding: 20px 15px 20px 15px;
  top: 0;
  left: 0;
}
h5,
h6 {
  margin: 0;
  padding: 0;
}
</style>
