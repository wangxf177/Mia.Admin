import { defineStore } from 'pinia';

interface IUserStore {
  token: string;
  isLogin: boolean;
}

export const userStore = defineStore('User', {
  state: (): IUserStore => ({
    token: '',
    isLogin: false,
  }),
  getters: {
    getToken(state) {
      return state.token;
    },
  },
  actions: {
    setLoginState(val: boolean) {
      this.isLogin = val;
      sessionStorage.setItem('isLogin', val.toString());
    },
    setToken(token: string) {
      this.token = token;
      sessionStorage.setItem('token', token);
    },
  },
});
