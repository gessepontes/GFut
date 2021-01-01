import { takeLatest, call, put, all } from 'redux-saga/effects';
import { toast } from 'react-toastify';
import { format } from 'date-fns';

import history from '~/services/history';
import api from '~/services/api';

import { saveHoraryPriceFailure, addHoraryPriceSuccess,  
          updateHoraryPriceSuccess, deleteHoraryPriceSuccess, deleteHoraryPriceFailure,
          fetchHoraryPriceSuccess,  fetchHoraryPriceFailure, 
          fetchHoraryPriceByIdSuccess,fetchHoraryPriceByIdFieldSuccess,
          fetchHoraryPriceByIdFieldFailure} from './actions';

import { loading } from '~/store/modules/auth/actions';          

export function* saveHoraryPrice({ payload }) {
  try {

    const {id,fieldItemId,startDate,endDate,value,monthlyValue
      ,active,registerDate } = payload.data;

    const horaryPrice = Object.assign(
      { id,fieldItemId,startDate,endDate,value,monthlyValue
        ,active,registerDate }
    );

    yield put(loading(true));

    if(horaryPrice.endDate === ""){
      horaryPrice.endDate = null;
    }

    if (id !== 0){
      yield call(api.put, 'horaryPrice/', horaryPrice);
      yield put(updateHoraryPriceSuccess(horaryPrice));
    }else{
      yield call(api.post, 'horaryPrice/', horaryPrice); 
      yield put(addHoraryPriceSuccess(horaryPrice));
    }
  
    yield put(loading(false));

    toast.success('Operação realizada com sucesso!');
  
    history.push('/horaryPrices');
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao realizar a operação!');
    yield put(saveHoraryPriceFailure());
  }
}

export function* deleteHoraryPrice({ payload }) {
  try {   
    const horaryPrice = payload.data;
    
    const id = horaryPrice.id;
    
    yield put(loading(true));
    yield call(api.delete, `horaryPrice/${id}`);
    yield put(loading(false));

    toast.success('Campo item excluido com sucesso!');

    yield put(deleteHoraryPriceSuccess(id));
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao excluir campo, confira seus dados!');
    yield put(deleteHoraryPriceFailure());
  }
}

export function* fetchHoraryPrice() {
   try {    
    yield put(loading(true));

    const response = yield call(api.get, `horaryPrice`);
    yield put(loading(false));

    yield put(fetchHoraryPriceSuccess(response.data));
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao atualizar campo, confira seus dados!');
    yield put(fetchHoraryPriceFailure());
  }
}

export function* fetchHoraryPriceById({ payload }) {
  try {

    const { id,fieldItemId,startDate,endDate,value,monthlyValue
      ,active,registerDate } = payload.data;

    const horaryPrice = Object.assign(
      { id,fieldItemId,startDate,endDate,value,monthlyValue
        ,active,registerDate }
    );

    horaryPrice.startDate = format(new Date(horaryPrice.startDate),"yyyy-MM-dd");

    if(horaryPrice.endDate !== null){
      horaryPrice.endDate = format(new Date(horaryPrice.endDate),"yyyy-MM-dd");
    }

    yield put(fetchHoraryPriceByIdSuccess(horaryPrice));
    history.push('/horaryPrice');
 } catch (err) {
   toast.error('Erro ao realizar a operação!');
 }
}

export function* fetchHoraryPriceByIdField({ payload }) {
  try {    
   yield put(loading(true));
   
   const IdField  = payload.data;
   
   const response = yield call(api.get, `horaryPrice/field/${IdField}`);

   yield put(fetchHoraryPriceByIdFieldSuccess(response.data));

   yield put(loading(false));
 } catch (err) {
   yield put(loading(false));

   toast.error('Erro ao realizar a operação!');
   yield put(fetchHoraryPriceByIdFieldFailure());
 }
}

export function HoraryPriceInitialValues() {
  history.push('/horaryPrice');
}

export function horaryPricesFieldBack() {
  history.push('/horaryPricesField');
}

export default all([
  takeLatest('@horaryPrice/HORARY_PRICE_INITIAL_VALUES', HoraryPriceInitialValues), 
  takeLatest('@horaryPrice/HORARY_PRICE_BACK', horaryPricesFieldBack),  
  takeLatest('@horaryPrice/SAVE_HORARY_PRICE_REQUEST', saveHoraryPrice),
  takeLatest('@horaryPrice/DELETE_HORARY_PRICE_REQUEST', deleteHoraryPrice),
  takeLatest('@horaryPrice/FETCH_HORARY_PRICE_REQUEST', fetchHoraryPrice),
  takeLatest('@horaryPrice/FETCH_HORARY_PRICE_ID_REQUEST', fetchHoraryPriceById),
  takeLatest('@horaryPrice/FETCH_HORARY_PRICE_ID_FIELD_REQUEST', fetchHoraryPriceByIdField),      
]);
