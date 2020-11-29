import { takeLatest, call, put, all } from 'redux-saga/effects';
import { toast } from 'react-toastify';

import history from '~/services/history';
import api from '~/services/api';

import { saveFieldItemFailure, addFieldItemSuccess,  
          updateFieldItemSuccess, deleteFieldItemSuccess, deleteFieldItemFailure,
          fetchFieldItemSuccess,  fetchFieldItemFailure, fetchFieldItemByIdFieldSuccess,
          fetchFieldItemByIdFieldFailure, fetchFieldItemByIdSuccess} from './actions';

import { loading } from '~/store/modules/auth/actions';          

export function* saveFieldItem({ payload }) {
  try {

    const {id,name,fieldId,picture,active,registerDate } = payload.data;

    const fieldItem = Object.assign(
      { id,name,fieldId,picture,active,registerDate }
    );

    yield put(loading(true));

    if (id !== 0){
      yield call(api.put, 'fieldItem/', fieldItem);
      yield put(updateFieldItemSuccess(fieldItem));
    }else{
      yield call(api.post, 'fieldItem/', fieldItem); 
      yield put(addFieldItemSuccess(fieldItem));
    }
  
    yield put(loading(false));

    toast.success('Operação realizada com sucesso!');
  
    history.push('/fieldItens');
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao realizar a operação!');
    yield put(saveFieldItemFailure());
  }
}

export function* deleteFieldItem({ payload }) {
  try {   
    const fieldItem = payload.data;
    
    const id = fieldItem.id;
    
    yield put(loading(true));
    yield call(api.delete, `fieldItem/${id}`);
    yield put(loading(false));

    toast.success('Campo item excluido com sucesso!');

    yield put(deleteFieldItemSuccess(id));
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao excluir campo, confira seus dados!');
    yield put(deleteFieldItemFailure());
  }
}

export function* fetchFieldItem() {
   try {    
    yield put(loading(true));

    const response = yield call(api.get, `fieldItem`);

    yield put(loading(false));

    yield put(fetchFieldItemSuccess(response.data));
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao atualizar campo, confira seus dados!');
    yield put(fetchFieldItemFailure());
  }
}

export function* fetchFieldItemById({ payload }) {
  try {

    const { id,name,fieldId,picture,active,registerDate } = payload.data;

    const fieldItem = Object.assign(
      { id,name,fieldId,picture,active,registerDate }
    );

    fieldItem.picture = `http://localhost:51933/picture/fieldItem/${fieldItem.picture}`;

    yield put(fetchFieldItemByIdSuccess(fieldItem));
    history.push('/fieldItem');
 } catch (err) {
   toast.error('Erro ao realizar a operação!');
 }
}

export function* fetchFieldItemByIdField({ payload }) {
  try {    
   yield put(loading(true));
   
   const IdField  = payload.data;
   
   const response = yield call(api.get, `fieldItem/field/${IdField}`);

   yield put(fetchFieldItemByIdFieldSuccess(response.data));

   yield put(loading(false));
 } catch (err) {
   yield put(loading(false));

   toast.error('Erro ao realizar a operação!');
   yield put(fetchFieldItemByIdFieldFailure());
 }
}

export function FieldItemInitialValues() {
  history.push('/fieldItem');
}

export function fieldItemBack() {
  history.push('/fieldItensField');
}

export default all([
  takeLatest('@fieldItem/FIELD_ITEM_INITIAL_VALUES', FieldItemInitialValues),
  takeLatest('@fieldItem/FIELD_ITEM_BACK', fieldItemBack),  
  takeLatest('@fieldItem/SAVE_FIELD_ITEM_REQUEST', saveFieldItem),
  takeLatest('@fieldItem/DELETE_FIELD_ITEM_REQUEST', deleteFieldItem),
  takeLatest('@fieldItem/FETCH_FIELD_ITEM_REQUEST', fetchFieldItem),
  takeLatest('@fieldItem/FETCH_FIELD_ITEM_ID_REQUEST', fetchFieldItemById), 
  takeLatest('@fieldItem/FETCH_FIELD_ITEM_ID_FIELD_REQUEST', fetchFieldItemByIdField),  
]);
