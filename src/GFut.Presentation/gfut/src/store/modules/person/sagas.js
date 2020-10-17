import { takeLatest, call, put, all } from 'redux-saga/effects';
import { toast } from 'react-toastify';
import { format } from 'date-fns';

import history from '~/services/history';
import api from '~/services/api';

import { savePersonFailure, addPersonSuccess,  
  updatePersonSuccess, deletePersonSuccess, deletePersonFailure,
  fetchPersonSuccess,  fetchPersonFailure, 
  fetchPersonByIdSuccess, fetchPersonByIdFailure
} from './actions';

import { loading } from '~/store/modules/auth/actions'; 

export function* savePerson({ payload }) {
  try {

    const { id, name, picture, phone, password, cpf, rg, birthDate, email , 
      active, registerDate, profileType } = payload.data;

    const person = Object.assign(
      { id, name, picture, phone, password, cpf, rg, birthDate, email , active
        , registerDate, profileType }
    );

    yield put(loading(true));

    if (id !== 0){
      yield call(api.put, 'person', person);
      yield put(updatePersonSuccess(person));
    }else{
      yield call(api.post, 'person', person); 
      yield put(addPersonSuccess(person));
    }
  
    yield put(loading(false));

    toast.success('Operação realizada com sucesso!');
  
    history.push('/people');
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao realizar a operação!');
    yield put(savePersonFailure());
  }
}

export function* deletePerson({ payload }) {
  try {   
    const person = payload.data;
    
    const id = person.id;
    
    yield put(loading(true));

    yield call(api.delete, `person/${id}`);

    yield put(loading(false));

    toast.success('Operação realizada com sucesso!');

    yield put(deletePersonSuccess(id));

    history.push('/people');
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao realizar a operação!');
    yield put(deletePersonFailure());
  }
}

export function* fetchPerson() {
   try {    
    yield put(loading(true));
       
    const response = yield call(api.get, `person/`);

    yield put(fetchPersonSuccess(response.data));

    yield put(loading(false));
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao realizar a operação!');
    yield put(fetchPersonFailure());
  }
}

export function* fetchPersonSubscriptions({ payload }) {
  try {    
   yield put(loading(true));
   
   const IdSubscription  = payload.data;
   
   const response = yield call(api.get, `person/Subscription/${IdSubscription}`);

   yield put(fetchPersonSuccess(response.data));

   yield put(loading(false));
 } catch (err) {
   yield put(loading(false));

   toast.error('Erro ao realizar a operação!');
   yield put(fetchPersonFailure());
 }
}

export function* fetchPersonById({ payload }) {
  try {

    const { id, name, picture, phone, password, cpf, rg, birthDate, email , active
      ,profileType, registerDate } = payload.data;

    const person = Object.assign(
      { id, name, picture, phone, password, cpf, rg, birthDate, email , active
      ,profileType, registerDate }
    );

    person.picture = `http://localhost:51933/picture/person/${person.picture}`;

    person.registerDate = format(new Date(person.registerDate),"yyyy-MM-dd");
    person.birthDate = format(new Date(person.birthDate),"yyyy-MM-dd");

    yield put(fetchPersonByIdSuccess(person));

    history.push('/person');
 } catch (err) {
   toast.error('Erro ao realizar a operação!');
   yield put(fetchPersonByIdFailure());
 }
}

export function* fetchPersonAllDrop() {
  try {    
   const response = yield call(api.get, `person\\PersonAllDrop`);
   yield put(fetchPersonSuccess(response.data));
 } catch (err) {
   yield put(fetchPersonFailure());
 }
}

export function* fetchPersonChampionshipDrop() {
  try {    
   const response = yield call(api.get, `person\\PersonChampionshipDrop`);
   yield put(fetchPersonSuccess(response.data));
 } catch (err) {
   yield put(fetchPersonFailure());
 }
}

export function* fetchPersonFieldDrop() {
  try {    
   const response = yield call(api.get, `person\\PersonFieldDrop`);
   yield put(fetchPersonSuccess(response.data));
 } catch (err) {
   yield put(fetchPersonFailure());
 }
}

export function personInitialValues() {
  history.push('/person');
}

export default all([
  takeLatest('@person/PERSON_INITIAL_VALUES', personInitialValues), 
  takeLatest('@person/SAVE_PERSON_REQUEST', savePerson),
  takeLatest('@person/DELETE_PERSON_REQUEST', deletePerson),
  takeLatest('@person/FETCH_PERSON_REQUEST', fetchPerson),
  takeLatest('@person/FETCH_PERSON_SUBSCRIPTIONS_REQUEST', fetchPersonSubscriptions),
  takeLatest('@person/FETCH_PERSON_ID_REQUEST', fetchPersonById),  
  takeLatest('@person/FETCH_PERSON_ALL_DROP_REQUEST', fetchPersonAllDrop),
  takeLatest('@person/FETCH_PERSON_CHAMPIONSHIP_DROP_REQUEST', fetchPersonChampionshipDrop),
  takeLatest('@person/FETCH_PERSON_FIELD_DROP_REQUEST', fetchPersonFieldDrop),
]);