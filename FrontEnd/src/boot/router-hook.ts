import { boot } from 'quasar/wrappers';

import { userStore } from '../stores/user';

const user = userStore();
export default boot(({ router }) => {
  router.beforeEach(async (to, from, next) => {
    console.log(to, from, next);
    if (user.isLogin) {
      user.$patch((state) => {
        state.isLogin = true;
      });
      return next();
    } else {
      return next();
    }
  });
});
