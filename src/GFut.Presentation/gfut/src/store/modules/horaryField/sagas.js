import { takeLatest, call, put, all } from 'redux-saga/effects';
import { toast } from 'react-toastify';

import history from '~/services/history';
import api from '~/services/api';

import { saveHoraryFieldFailure, addHoraryFieldSuccess,  
          updateHoraryFieldSuccess, deleteHoraryFieldSuccess, deleteHoraryFieldFailure,
          fetchHoraryFieldSuccess,  fetchHoraryFieldFailure, 
          fetchHoraryFieldByIdSuccess, fetchSearchHoraryFieldFailure,
          fetchSearchHoraryFieldSuccess} from './actions';

import { loading } from '~/store/modules/auth/actions';          

export function* saveHoraryField({ payload }) {
  try {

    const {id,fieldItemId,hour,dayWeek,state
      ,active,registerDate } = payload.data;

    const horaryField = Object.assign(
      { id,fieldItemId,hour,dayWeek,state
        ,active,registerDate }
    );

    yield put(loading(true));

    if (id !== 0){
      yield call(api.put, 'horary/', horaryField);
      yield put(updateHoraryFieldSuccess(horaryField));
    }else{
      yield call(api.post, 'horary/', horaryField); 
      yield put(addHoraryFieldSuccess(horaryField));
    }
  
    yield put(loading(false));

    toast.success('Operação realizada com sucesso!');
  
    history.push('/horaryFields');
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao realizar a operação!');
    yield put(saveHoraryFieldFailure());
  }
}

export function* deleteHoraryField({ payload }) {
  try {   
    const horaryField = payload.data;
    
    const id = horaryField.id;
    
    yield put(loading(true));
    yield call(api.delete, `horary/${id}`);
    yield put(loading(false));

    toast.success('Campo item excluido com sucesso!');

    yield put(deleteHoraryFieldSuccess(id));
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao excluir campo, confira seus dados!');
    yield put(deleteHoraryFieldFailure());
  }
}

export function* fetchHoraryField() {
   try {    

    yield put(loading(true));

    const response = yield call(api.get, `horary`);

    yield put(loading(false));

    yield put(fetchHoraryFieldSuccess(response.data));
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao atualizar campo, confira seus dados!');
    yield put(fetchHoraryFieldFailure());
  }
}

export function* fetchSearchHoraryField({ payload }) {
  try {
    const { search } = payload.data;
    
   yield put(loading(true));

   let response = "";

  if(search === ''){
    response = yield call(api.get, `horary`);
  }else{
    response = yield call(api.get, `horary/search/${search}`);
  }
   yield put(loading(false));

   yield put(fetchSearchHoraryFieldSuccess(response.data));
 } catch (err) {
  yield put(loading(false));

   toast.error('Erro ao pesquisar o campo!');
   yield put(fetchSearchHoraryFieldFailure());
 }
}

export function* fetchHoraryFieldById({ payload }) {
  try {
    const { id,fieldItemId,hour,dayWeek,state
      ,active,registerDate } = payload.data;

    const horaryField = Object.assign(
      { id,fieldItemId,hour,dayWeek,state
        ,active,registerDate }
    );

    yield put(fetchHoraryFieldByIdSuccess(horaryField));
    history.push('/horaryField');
 } catch (err) {
   toast.error('Erro ao realizar a operação!');
 }
}

export function HoraryFieldInitialValues() {
  history.push('/horaryField');
}

export default all([
  takeLatest('@horaryField/HORARY_FIELD_INITIAL_VALUES', HoraryFieldInitialValues), 
  takeLatest('@horaryField/SAVE_HORARY_FIELD_REQUEST', saveHoraryField),
  takeLatest('@horaryField/DELETE_HORARY_FIELD_REQUEST', deleteHoraryField),
  takeLatest('@horaryField/FETCH_HORARY_FIELD_REQUEST', fetchHoraryField),
  takeLatest('@horaryField/FETCH_HORARY_FIELD_ID_REQUEST', fetchHoraryFieldById),   
  takeLatest('@horaryField/FETCH_SEARCH_HORARY_FIELD_REQUEST', fetchSearchHoraryField),  
]);
