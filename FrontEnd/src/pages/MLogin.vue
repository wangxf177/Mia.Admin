<template>
  <div class="login full-height">
    <div class="loginForm q-pa-lg bg-white fixed-center">
      <div class="q-pb-md text-h5 text-center text-weight-bold">
        {{ $t('systemName') }}
      </div>
      <q-form @submit="onSubmit" class="q-gutter-md">
        <q-input
          dense
          outlined
          v-model="name"
          :placeholder="$t('login.account')"
        >
          <template v-slot:prepend>
            <q-icon name="perm_identity" />
          </template>
        </q-input>
        <q-input
          dense
          outlined
          type="password"
          v-model="password"
          maxlength="20"
          :placeholder="$t('login.password')"
        >
          <template v-slot:prepend>
            <q-icon name="key" />
          </template>
        </q-input>
        <q-select
          dense
          outlined
          use-input
          v-model="language"
          :options="['中文', 'English']"
        >
          <template v-slot:prepend>
            <q-icon name="language" />
          </template>
        </q-select>
        <div class="row">
          <div class="col-7">
            <q-input
              dense
              outlined
              v-model="verificationCode"
              :placeholder="$t('login.verificationCode')"
            >
              <template v-slot:prepend>
                <q-icon name="gpp_good"></q-icon>
              </template>
            </q-input>
          </div>
          <div
            class="col-5 text-subtitle1"
            style="line-height: 40px; text-align: right"
          >
            <span class="text-red">*</span>验证码
          </div>
        </div>
        <q-checkbox
          dense
          v-model="reminber"
          :label="$t('login.rememberPassword')"
        />
        <div class="row">
          <q-btn
            :label="$t('login.signIn')"
            type="submit"
            color="primary"
            no-caps
            class="col-12"
          />
        </div>
      </q-form>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { useQuasar } from 'quasar';
import { onBeforeMount, onMounted, ref } from 'vue';
import { useRouter } from 'vue-router';
import { login } from '../service/user';
const router = useRouter();
const $q = useQuasar();

const name = ref('');
const password = ref('');
const language = ref('');
const verificationCode = ref('');
const reminber = ref(false);
const onSubmit = () => {
  login(name.value, password.value, language.value);
  if (name.value === 'Bruce X Wang' && password.value === 'Feng3364') {
    router.push('/home');
  } else {
    $q.notify({
      color: 'red-5',
      textColor: 'white',
      icon: 'info',
      message: '账号或密码错误',
      position: 'top',
    });
  }
};

onMounted(() => {
  console.log('onMounted');
});
onBeforeMount(() => {
  console.log('onBeforeMount');
});
</script>

<style lang="scss" scoped>
.login {
  background-image: url('../assets/images/login-background.jpg');
  background-size: cover;

  .loginForm {
    width: 400px;
    border-radius: 6px;
  }
}
</style>
