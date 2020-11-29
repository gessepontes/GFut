import { takeLatest, call, put, all } from 'redux-saga/effects';
import { toast } from 'react-toastify';
import { format } from 'date-fns';

import history from '~/services/history';
import api from '~/services/api';

import { saveHoraryExtraFieldFailure, addHoraryExtraFieldSuccess,  
          updateHoraryExtraFieldSuccess, deleteHoraryExtraFieldSuccess, deleteHoraryExtraFieldFailure,
          fetchHoraryExtraFieldSuccess,  fetchHoraryExtraFieldFailure, 
          fetchHoraryExtraFieldByIdSuccess, fetchHoraryExtraFieldByIdFieldSuccess,
          fetchHoraryExtraFieldByIdFieldFailure} from './actions';

import { loading } from '~/store/modules/auth/actions';          

export function* saveHoraryExtraField({ payload }) {
  try {

    const {id,fieldItemId,hour,date,state
      ,active,registerDate } = payload.data;

    const horaryExtraField = Object.assign(
      { id,fieldItemId,hour,date,state
        ,active,registerDate }
    );

    yield put(loading(true));

    if (id !== 0){
      yield call(api.put, 'horaryExtra/', horaryExtraField);
      yield put(updateHoraryExtraFieldSuccess(horaryExtraField));
    }else{
      yield call(api.post, 'horaryExtra/', horaryExtraField); 
      yield put(addHoraryExtraFieldSuccess(horaryExtraField));
    }
  
    yield put(loading(false));

    toast.success('Operação realizada com sucesso!');
  
    history.push('/horaryExtraFields');
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao realizar a operação!');
    yield put(saveHoraryExtraFieldFailure());
  }
}

export function* deleteHoraryExtraField({ payload }) {
  try {   
    const horaryExtraField = payload.data;
    
    const id = horaryExtraField.id;
    
    yield put(loading(true));
    yield call(api.delete, `horaryExtra/${id}`);
    yield put(loading(false));

    toast.success('Horário excluido com sucesso!');

    yield put(deleteHoraryExtraFieldSuccess(id));
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao excluir campo, confira seus dados!');
    yield put(deleteHoraryExtraFieldFailure());
  }
}

export function* fetchHoraryExtraField() {
   try {    

    yield put(loading(true));

    const response = yield call(api.get, `horaryExtra`);

    yield put(loading(false));

    yield put(fetchHoraryExtraFieldSuccess(response.data));
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao atualizar campo, confira seus dados!');
    yield put(fetchHoraryExtraFieldFailure());
  }
}

export function* fetchHoraryExtraFieldByIdField({ payload }) {
  try {    
   yield put(loading(true));
   
   const IdField  = payload.data;
   
   const response = yield call(api.get, `horaryExtra/field/${IdField}`);

   yield put(fetchHoraryExtraFieldByIdFieldSuccess(response.data));

   yield put(loading(false));
 } catch (err) {
   yield put(loading(false));

   toast.error('Erro ao realizar a operação!');
   yield put(fetchHoraryExtraFieldByIdFieldFailure());
 }
}

export function* fetchHoraryExtraFieldById({ payload }) {
  try {
    const { id,fieldItemId,hour,date,state
      ,active,registerDate } = payload.data;

    const horaryExtraField = Object.assign(
      { id,fieldItemId,hour,date,state
        ,active,registerDate }
    );

    horaryExtraField.date = format(new Date(horaryExtraField.date),"yyyy-MM-dd");

    yield put(fetchHoraryExtraFieldByIdSuccess(horaryExtraField));
    history.push('/horaryExtraField');
 } catch (err) {
   toast.error('Erro ao realizar a operação!');
 }
}

export function HoraryExtraFieldInitialValues() {
  history.push('/horaryExtraField');
}

export function horaryExtraFieldsFieldBack() {
  history.push('/horaryExtraFieldsField');
}

export default all([
  takeLatest('@horaryExtraField/HORARY_EXTRA_FIELD_INITIAL_VALUES', HoraryExtraFieldInitialValues), 
  takeLatest('@horaryExtraField/HORARY_EXTRA_FIELD_BACK', horaryExtraFieldsFieldBack),  
  takeLatest('@horaryExtraField/SAVE_HORARY_EXTRA_FIELD_REQUEST', saveHoraryExtraField),
  takeLatest('@horaryExtraField/DELETE_HORARY_EXTRA_FIELD_REQUEST', deleteHoraryExtraField),
  takeLatest('@horaryExtraField/FETCH_HORARY_EXTRA_FIELD_REQUEST', fetchHoraryExtraField),
  takeLatest('@horaryExtraField/FETCH_HORARY_EXTRA_FIELD_ID_REQUEST', fetchHoraryExtraFieldById),   
  takeLatest('@horaryExtraField/FETCH_HORARY_EXTRA_FIELD_ID_FIELD_REQUEST', fetchHoraryExtraFieldByIdField),   
]);
