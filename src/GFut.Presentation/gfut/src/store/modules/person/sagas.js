import { takeLatest, call, put, all } from 'redux-saga/effects';

import api from '~/services/api';

import { fetchPersonSuccess
,fetchPersonFailure } from './actions';

export function* fetchPerson() {
  try {    
   const response = yield call(api.get, `person\\campeonato`);
   yield put(fetchPersonSuccess(response.data));
 } catch (err) {
   yield put(fetchPersonFailure());
 }
}


export default all([
  takeLatest('@person/FETCH_PERSON_REQUEST', fetchPerson),
]);