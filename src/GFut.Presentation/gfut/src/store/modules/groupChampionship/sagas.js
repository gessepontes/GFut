import { takeLatest, call, put, all } from 'redux-saga/effects';
import { toast } from 'react-toastify';

import history from '~/services/history';
import api from '~/services/api';

import { saveGroupChampionshipFailure, addGroupChampionshipSuccess,  
          updateGroupChampionshipSuccess, deleteGroupChampionshipSuccess, deleteGroupChampionshipFailure,
          fetchGroupChampionshipSuccess,  fetchGroupChampionshipFailure, automaticGroupFailure,
          automaticGroupSuccess, fetchGroupChampionshipByIdSuccess} from './actions';

import { loading } from '~/store/modules/auth/actions';          

export function* saveGroupChampionship({ payload }) {
  try {

    const {id,subscriptionId,groupId,active,registerDate 
    } = payload.data;

    const groupChampionship = Object.assign(
      { id,subscriptionId,groupId,active,registerDate }
    );

    yield put(loading(true));

    if (id !== 0){
      yield call(api.put, 'groupChampionship/', groupChampionship);
      yield put(updateGroupChampionshipSuccess(groupChampionship));
    }else{
      yield call(api.post, 'groupChampionship/', groupChampionship); 
      yield put(addGroupChampionshipSuccess(groupChampionship));
    }
  
    yield put(loading(false));

    toast.success('Operação realizada com sucesso!');
  
    history.push('/groupChampionships');
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao realizar a operação!');
    yield put(saveGroupChampionshipFailure());
  }
}

export function* deleteGroupChampionship({ payload }) {
  try {   
    const GroupChampionship = payload.data;
    
    const id = GroupChampionship.id;
    
    yield put(loading(true));

    yield call(api.delete, `groupChampionship/${id}`);

    yield put(loading(false));

    toast.success('Inscrição excluido com sucesso!');

    yield put(deleteGroupChampionshipSuccess(id));
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao excluir inscrição, confira seus dados!');
    yield put(deleteGroupChampionshipFailure());
  }
}

export function* fetchGroupChampionship({ payload }) {
   try {    
    yield put(loading(true));
    
    const championshipId = payload.data;
    
    const response = yield call(api.get, `groupChampionship/championship/${championshipId}`);

    yield put(loading(false));

    yield put(fetchGroupChampionshipSuccess(response.data));
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao atualizar inscrição, confira seus dados!');
    yield put(fetchGroupChampionshipFailure());
  }
}

export function* fetchGroupChampionshipById({ payload }) {
  try {
    const { id,subscriptionId,groupId,active,registerDate } 
      = payload.data;

    const groupChampionship = Object.assign(
      { id,subscriptionId,groupId,active,registerDate }
    );

    console.log(groupChampionship);
    yield put(fetchGroupChampionshipByIdSuccess(groupChampionship));
    history.push('/groupChampionship');
 } catch (err) {
   toast.error('Erro ao realizar a operação!');
 }
}

export function groupChampionshipInitialValues() {
  history.push('/groupChampionship');
}

export function groupChampionshipBack() {
  history.push('/groupChampionshipChampionship');
}

export function* saveAutomaticGroupChampionship({ payload }) {
  try {

    const { championshipId, quantity } = payload.data;

  const groupChampionship = Object.assign(
    { championshipId, quantity }
  );

    yield put(loading(true));

    yield call(api.post, `GroupChampionship/automaticGroupChampionship?championshipId=${groupChampionship.championshipId}&quantity=${groupChampionship.quantity}`);
    yield put(automaticGroupSuccess(championshipId));
  
    yield put(loading(false));

    toast.success('Operação realizada com sucesso!');
  
    history.push('/automaticGroup');
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao realizar a operação!');
    yield put(automaticGroupFailure());
  }
}


export default all([
  takeLatest('@groupChampionship/GROUP_CHAMPIONSHIP_INITIAL_VALUES', groupChampionshipInitialValues), 
  takeLatest('@groupChampionship/GROUP_CHAMPIONSHIP_BACK', groupChampionshipBack),   
  takeLatest('@groupChampionship/SAVE_GROUP_CHAMPIONSHIP_REQUEST', saveGroupChampionship),
  takeLatest('@groupChampionship/DELETE_GROUP_CHAMPIONSHIP_REQUEST', deleteGroupChampionship),
  takeLatest('@groupChampionship/FETCH_GROUP_CHAMPIONSHIP_REQUEST', fetchGroupChampionship),
  takeLatest('@groupChampionship/FETCH_GROUP_CHAMPIONSHIP_ID_REQUEST', fetchGroupChampionshipById),  
  takeLatest('@groupChampionship/AUTOMATIC_GROUP_CHAMPIONSHIP_ID_REQUEST', saveAutomaticGroupChampionship),    
]);
