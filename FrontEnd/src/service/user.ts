import { api } from 'src/boot/axios';

export const login = (userId: string, password: string, language: string) => {
  return api.post(
    '/api/login?userId=' +
      userId +
      '&password=' +
      password +
      '&language=' +
      language
  );
};
