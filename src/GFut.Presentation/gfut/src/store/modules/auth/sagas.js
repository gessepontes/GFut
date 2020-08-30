import { takeLatest, call, put, all } from 'redux-saga/effects';
import { toast } from 'react-toastify';
import { format } from 'date-fns';

import history from '~/services/history';
import api from '~/services/api';

import { signInSuccess, signFailure } from './actions';

export function* signIn({ payload }) {
  try {
    const { email, password } = payload;

    const response = yield call(api.post, 'user/SignIn/', {
      email,
      password,      
    });

    const user  = response.data;

    if (!user) {
      toast.error('Usuário ou senha incorretos.');
      return;
    }

    if (!user.active) {
      toast.error('Usuário não está ativo.');
      return;
    }

    user.birthDate = format(new Date(user.birthDate),"yyyy-MM-dd");

    api.defaults.headers.Authorization = `Bearer ${user.token}`;

    yield put(signInSuccess(user));

    history.push('/dashboard');
  } catch (err) {
    toast.error('Falha na autenticação, verifique seus dados');
    yield put(signFailure());
  }
}

export function* signUp({ payload }) {
  try {
    const { name, email, phone, password } = payload;

    yield call(api.post, 'user/signup/', {
      name,
      email,
      phone,
      password,
    });

    history.push('/');
  } catch (err) {
    toast.error('Falha no cadastro, verifique seus dados!');

    yield put(signFailure());
  }
}

export function setToken({ payload }) {
  if (!payload) return;

  const { token } = payload.auth;

  if (token) {
    api.defaults.headers.Authorization = `Bearer ${token}`;
  }
}

export function signOut() {
  history.push('/sign-in');
}

export default all([
  takeLatest('persist/REHYDRATE', setToken),
  takeLatest('@auth/SIGN_IN_REQUEST', signIn),
  takeLatest('@auth/SIGN_UP_REQUEST', signUp),
  takeLatest('@auth/SIGN_OUT', signOut),
]);