import { takeLatest, call, put, all } from 'redux-saga/effects';
import { toast } from 'react-toastify';

import api from '~/services/api';

import { updateProfileSuccess, updateProfileFailure } from './actions';

import { loading } from '~/store/modules/auth/actions';  

export function* updateProfile({ payload }) {
  try {
    const { id, name, picture, phone, password, cpf, rg, birthDate, email , 
      active, registerDate, profileType } = payload.data;

    const person = Object.assign(
      { id, name, picture, phone, password, cpf, rg, birthDate, email , active
        , registerDate, profileType }
    );

    yield put(loading(true));

    yield call(api.put, 'person/PutUpdateProfile', person);

    yield put(loading(false));

    toast.success('Operação realizada com sucesso!');

    yield put(updateProfileSuccess(person));
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao realizar a operação!');
    yield put(updateProfileFailure());
  }
}


export default all([
  takeLatest('@user/UPDATE_PROFILE_REQUEST', updateProfile)
]);