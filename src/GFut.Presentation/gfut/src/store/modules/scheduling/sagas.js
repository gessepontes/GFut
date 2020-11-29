import { takeLatest, call, put, all } from 'redux-saga/effects';
import { toast } from 'react-toastify';
import { format } from 'date-fns';

import history from '~/services/history';
import api from '~/services/api';

import { saveSchedulingFailure, addSchedulingSuccess,  
          updateSchedulingSuccess, deleteSchedulingSuccess, deleteSchedulingFailure,
          fetchSchedulingSuccess,  fetchSchedulingFailure, 
          fetchSchedulingByIdSuccess, fetchSchedulingByIdFieldSuccess,
          fetchSchedulingByIdFieldFailure} from './actions';

import { loading } from '~/store/modules/auth/actions';          

export function* saveScheduling({ payload }) {
  try {

    const { id,date,horaryId,schedulingType,horaryType,state,personId,
      customerNotRegistered,phone,cancelDate,personCancelId,markedApp,
      active,registerDate } = payload.data;

    const scheduling = Object.assign(
      { id,date,horaryId,schedulingType,horaryType,state,personId,
        customerNotRegistered,phone,cancelDate,personCancelId,markedApp,
        active,registerDate }
    );

    scheduling.state = 1;

    yield put(loading(true));

    if (id !== 0){
      yield call(api.put, 'scheduling/', scheduling);
      yield put(updateSchedulingSuccess(scheduling));
    }else{
      yield call(api.post, 'scheduling/', scheduling); 
      yield put(addSchedulingSuccess(scheduling));
    }
  
    yield put(loading(false));

    toast.success('Operação realizada com sucesso!');
  
    history.push('/schedulings');
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao realizar a operação!');
    yield put(saveSchedulingFailure());
  }
}

export function* deleteScheduling({ payload }) {
  try {   
    const scheduling = payload.data;
    
    const id = scheduling.id;
    
    yield put(loading(true));
    yield call(api.delete, `scheduling/${id}`);
    yield put(loading(false));

    toast.success('Agendamento excluido com sucesso!');

    yield put(deleteSchedulingSuccess(id));
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao excluir campo, confira seus dados!');
    yield put(deleteSchedulingFailure());
  }
}

export function* fetchScheduling() {
   try {    
    yield put(loading(true));

    const response = yield call(api.get, `scheduling`);

    yield put(loading(false));

    yield put(fetchSchedulingSuccess(response.data));
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao atualizar campo, confira seus dados!');
    yield put(fetchSchedulingFailure());
  }
}

export function* fetchSchedulingById({ payload }) {
  try {

    const { id,date,horary,horaryId,fieldItemId,schedulingType,horaryType,state,personId,
      customerNotRegistered,phone,cancelDate,personCancelId,markedApp,
      active,registerDate } = payload.data;

    const scheduling = Object.assign(
      { id,date,horary,horaryId,fieldItemId,schedulingType,horaryType,state,personId,
        customerNotRegistered,phone,cancelDate,personCancelId,markedApp,
        active,registerDate }
    );

    scheduling.date = format(new Date(scheduling.date),"yyyy-MM-dd");
    scheduling.fieldItemId = horary.fieldItemId;

    yield put(fetchSchedulingByIdSuccess(scheduling));
    history.push('/scheduling');
 } catch (err) {
   toast.error('Erro ao realizar a operação!');
 }
}

export function* fetchSchedulingByIdField({ payload }) {
  try {    
   yield put(loading(true));
   
   const IdField  = payload.data;
   
   const response = yield call(api.get, `scheduling/field/${IdField}`);

   yield put(fetchSchedulingByIdFieldSuccess(response.data));

   yield put(loading(false));
 } catch (err) {
   yield put(loading(false));

   toast.error('Erro ao realizar a operação!');
   yield put(fetchSchedulingByIdFieldFailure());
 }
}


export function schedulingInitialValues() {
  history.push('/scheduling');
}

export function schedulingFieldBack() {
  history.push('/schedulingField');
}

export default all([
  takeLatest('@scheduling/SCHEDULING_INITIAL_VALUES', schedulingInitialValues), 
  takeLatest('@scheduling/SCHEDULING_BACK', schedulingFieldBack),  
  takeLatest('@scheduling/SAVE_SCHEDULING_REQUEST', saveScheduling),
  takeLatest('@scheduling/DELETE_SCHEDULING_REQUEST', deleteScheduling),
  takeLatest('@scheduling/FETCH_SCHEDULING_REQUEST', fetchScheduling),
  takeLatest('@scheduling/FETCH_SCHEDULING_ID_REQUEST', fetchSchedulingById),
  takeLatest('@scheduling/FETCH_SCHEDULING_ID_FIELD_REQUEST', fetchSchedulingByIdField),     
]);
