import { takeLatest, call, put, all } from 'redux-saga/effects';
import { toast } from 'react-toastify';

import history from '~/services/history';
import api from '~/services/api';

import { saveFieldFailure, addFieldSuccess,  
          updateFieldSuccess, deleteFieldSuccess, deleteFieldFailure,
          fetchFieldSuccess,  fetchFieldFailure, 
          fetchFieldByIdSuccess } from './actions';         

export function* saveField({ payload }) {
  try {

    const {id,name,address,phone,value,monthlyValue,scheduled,picture,
      personId,cityId,active,registerDate } = payload.data;

    const field = Object.assign(
      { id,name,address,phone,value,monthlyValue,scheduled,picture,
        personId,cityId,active,registerDate }
    );

    field.cityId = 1;

    field.monthlyValue = parseFloat(field.monthlyValue);
    field.value = parseFloat(field.value);

    if (id !== 0){
      yield call(api.put, 'field/', field);
      yield put(updateFieldSuccess(field));
    }else{
      yield call(api.post, 'field/', field); 
      yield put(addFieldSuccess(field));
    }

    toast.success('Operação realizada com sucesso!');
  
    history.push('/fields');
  } catch (err) {
    toast.error('Erro ao realizar a operação!');
    yield put(saveFieldFailure());
  }
}

export function* deleteField({ payload }) {
  try {   
    const Field = payload.data;
    
    const id = Field.id;

    yield call(api.delete, `field/${id}`);

    toast.success('Campo excluido com sucesso!');

    yield put(deleteFieldSuccess(id));
  } catch (err) {

    toast.error('Erro ao excluir campo, confira seus dados!');
    yield put(deleteFieldFailure());
  }
}

export function* fetchField() {
   try {    
    const response = yield call(api.get, `field`);

    yield put(fetchFieldSuccess(response.data));
  } catch (err) {
    toast.error('Erro ao atualizar campo, confira seus dados!');
    yield put(fetchFieldFailure());
  }
}

export function* fetchFieldById({ payload }) {
  try {

    const { id,name,address,phone,value,monthlyValue,scheduled,picture,
      personId,cityId,active,registerDate } = payload.data;

    const field = Object.assign(
      { id,name,address,phone,value,monthlyValue,scheduled,picture,
        personId,cityId,active,registerDate }
    );

    field.picture = `http://localhost:51933/picture/field/${field.picture}`;

    yield put(fetchFieldByIdSuccess(field));
    history.push('/field');
 } catch (err) {
   toast.error('Erro ao realizar a operação!');
 }
}

export function FieldInitialValues() {
  history.push('/field');
}


export default all([
  takeLatest('@field/FIELD_INITIAL_VALUES', FieldInitialValues), 
  takeLatest('@field/SAVE_FIELD_REQUEST', saveField),
  takeLatest('@field/DELETE_FIELD_REQUEST', deleteField),
  takeLatest('@field/FETCH_FIELD_REQUEST', fetchField),
  takeLatest('@field/FETCH_FIELD_ID_REQUEST', fetchFieldById)  
]);
