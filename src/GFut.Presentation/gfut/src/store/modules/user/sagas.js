import { takeLatest, call, put, all } from 'redux-saga/effects';
import { toast } from 'react-toastify';

import api from '~/services/api';

import { updateProfileSuccess, updateProfileFailure } from './actions';

import { loading } from '~/store/modules/auth/actions';  

export function* updateProfile({ payload }) {
  try {
    const { id, name, email, phone,  
      birthDate, password, picture } = payload.data;

    const profile = Object.assign(
      { id, name, email, phone,  
        birthDate, password, picture }
    );

    yield put(loading(true));

    yield call(api.put, 'user', profile);

    yield put(loading(false));

    toast.success('Operação realizada com sucesso!');

    yield put(updateProfileSuccess(profile));
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao realizar a operação!');
    yield put(updateProfileFailure());
  }
}


export default all([
  takeLatest('@user/UPDATE_PROFILE_REQUEST', updateProfile)
]);