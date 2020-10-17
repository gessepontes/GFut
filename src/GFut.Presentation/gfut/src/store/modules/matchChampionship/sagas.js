import { takeLatest, call, put, all } from 'redux-saga/effects';
import { toast } from 'react-toastify';

import history from '~/services/history';
import api from '~/services/api';

import { format } from 'date-fns';

import { saveMatchChampionshipFailure, addMatchChampionshipSuccess,  
          updateMatchChampionshipSuccess, deleteMatchChampionshipSuccess, deleteMatchChampionshipFailure,
          fetchMatchChampionshipSuccess,  fetchMatchChampionshipFailure, automaticMatchFailure,
          automaticMatchSuccess, fetchMatchChampionshipByIdSuccess} from './actions';

import { loading } from '~/store/modules/auth/actions';          

export function* saveMatchChampionship({ payload }) {
  try {

    const {id,homeSubscriptionId,guestSubscriptionId,fieldItemId,homePoints,
      guestPoints,matchDate,startTime,calculate,round,active,registerDate 
    } = payload.data;

    const matchChampionship = Object.assign(
      { id,homeSubscriptionId,guestSubscriptionId,fieldItemId,homePoints,
      guestPoints,matchDate,startTime,calculate,round,active,registerDate  }
    );

    yield put(loading(true));

    if (id !== 0){
      yield call(api.put, 'matchChampionship/', matchChampionship);
      yield put(updateMatchChampionshipSuccess(matchChampionship));
    }else{
      yield call(api.post, 'matchChampionship/', matchChampionship); 
      yield put(addMatchChampionshipSuccess(matchChampionship));
    }
  
    yield put(loading(false));

    toast.success('Operação realizada com sucesso!');
  
    history.push('/matchChampionships');
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao realizar a operação!');
    yield put(saveMatchChampionshipFailure());
  }
}

export function* deleteMatchChampionship({ payload }) {
  try {   
    const MatchChampionship = payload.data;
    
    const id = MatchChampionship.id;
    
    yield put(loading(true));

    yield call(api.delete, `matchChampionship/${id}`);

    yield put(loading(false));

    toast.success('Inscrição excluido com sucesso!');

    yield put(deleteMatchChampionshipSuccess(id));
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao excluir inscrição, confira seus dados!');
    yield put(deleteMatchChampionshipFailure());
  }
}

export function* fetchMatchChampionship({ payload }) {
   try {    
    yield put(loading(true));
    
    const matchChampionshipId = payload.data;
  
    const response = yield call(api.get, `matchChampionship/championship/${matchChampionshipId}`);

    yield put(loading(false));

    yield put(fetchMatchChampionshipSuccess(response.data));
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao atualizar inscrição, confira seus dados!');
    yield put(fetchMatchChampionshipFailure());
  }
}

export function* fetchMatchChampionshipById({ payload }) {
  try {
    const { id,homeSubscriptionId,guestSubscriptionId,fieldItem,fieldId,fieldItemId,homePoints,
      guestPoints,matchDate,startTime,calculate,round,active,registerDate  } 
      = payload.data;

    const matchChampionship = Object.assign(
      { id,homeSubscriptionId,guestSubscriptionId,fieldId,fieldItemId,homePoints,
      guestPoints,matchDate,startTime,calculate,round,active,registerDate  }
    );

    matchChampionship.fieldId = fieldItem.fieldId;
    matchChampionship.matchDate = format(new Date(matchChampionship.matchDate),"yyyy-MM-dd");

    yield put(fetchMatchChampionshipByIdSuccess(matchChampionship));
    history.push('/matchChampionship');
 } catch (err) {
   toast.error('Erro ao realizar a operação!');
 }
}

export function matchChampionshipInitialValues() {
  history.push('/matchChampionship');
}

export function matchChampionshipBack() {
  history.push('/matchChampionshipChampionship');
}

export function* saveAutomaticMatchChampionship({ payload }) {
  try {

    const { championshipId } 
      = payload.data;

    const matchChampionship = Object.assign(
      { championshipId }
    );

    yield put(loading(true));

    yield call(api.post, `MatchChampionship/automaticMatchChampionship?championshipId=${matchChampionship.championshipId}`);
    yield put(automaticMatchSuccess(matchChampionship));
  
    yield put(loading(false));

    toast.success('Operação realizada com sucesso!');
  
    history.push('/automaticMatch');
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao realizar a operação!');
    yield put(automaticMatchFailure());
  }
}


export default all([
  takeLatest('@matchChampionship/MATCH_CHAMPIONSHIP_INITIAL_VALUES', matchChampionshipInitialValues), 
  takeLatest('@matchChampionship/MATCH_CHAMPIONSHIP_BACK', matchChampionshipBack),   
  takeLatest('@matchChampionship/SAVE_MATCH_CHAMPIONSHIP_REQUEST', saveMatchChampionship),
  takeLatest('@matchChampionship/DELETE_MATCH_CHAMPIONSHIP_REQUEST', deleteMatchChampionship),
  takeLatest('@matchChampionship/FETCH_MATCH_CHAMPIONSHIP_REQUEST', fetchMatchChampionship),
  takeLatest('@matchChampionship/FETCH_MATCH_CHAMPIONSHIP_ID_REQUEST', fetchMatchChampionshipById),  
  takeLatest('@matchChampionship/AUTOMATIC_MATCH_CHAMPIONSHIP_ID_REQUEST', saveAutomaticMatchChampionship),    
]);
