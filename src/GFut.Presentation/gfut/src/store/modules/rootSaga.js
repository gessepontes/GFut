import { all } from 'redux-saga/effects';

import auth from './auth/sagas';
import user from './user/sagas';
import player from './player/sagas';
import team from './team/sagas';
import field from './field/sagas';
import fieldItem from './fieldItem/sagas';
import horaryPrice from './horaryPrice/sagas';
import horaryField from './horaryField/sagas';
import horaryExtraField from './horaryExtraField/sagas';
import person from './person/sagas';
import scheduling from './scheduling/sagas';

export default function* rootSaga() {
  return yield all([
    auth,
    user,
    player,
    team,
    field,
    fieldItem,
    horaryPrice,
    horaryField,
    horaryExtraField,
    person,
    scheduling
  ]);
}