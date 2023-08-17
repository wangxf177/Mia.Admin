import { api } from 'src/boot/axios';

export const loginIn = (loginDto: any) => {
  return api.post('/api/account/loginIn', loginDto);
};
