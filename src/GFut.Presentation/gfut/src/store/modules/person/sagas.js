import { takeLatest, call, put, all } from 'redux-saga/effects';
import { toast } from 'react-toastify';

import api from '~/services/api';

import { updatePersonSuccess, updatePersonFailure } from './actions';

export function* updatePerson({ payload }) {
  try {
    const { name, email, avatar_id, ...rest } = payload.data;

    const person = Object.assign(
      { name, email, avatar_id },
      rest.oldPassword ? rest : {}
    );

    const response = yield call(api.put, 'users', person);

    toast.success('Person atualizado com sucesso!');

    yield put(updatePersonSuccess(response.data));
  } catch (err) {
    toast.error('Erro ao atualizar person, confira seus dados!');
    yield put(updatePersonFailure());
  }
}

export default all([takeLatest('@user/UPDATE_PERSON_REQUEST', updatePerson)]);