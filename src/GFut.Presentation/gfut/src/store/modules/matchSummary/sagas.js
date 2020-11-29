import { takeLatest, call, put, all } from 'redux-saga/effects';
import { toast } from 'react-toastify';

import history from '~/services/history';
import api from '~/services/api';

import { format } from 'date-fns';

import { saveMatchSummaryFailure, addMatchSummarySuccess,  
          updateMatchSummarySuccess,
          fetchMatchSummarySuccess,  fetchMatchSummaryFailure, fetchMatchSummaryByIdSuccess} from './actions';

import { loading } from '~/store/modules/auth/actions';          

export function* saveMatchSummary({ payload }) {
  try {

    const {id,homeSubscriptionId,guestSubscriptionId,fieldItemId,homePoints,
      guestPoints,matchDate,startTime,calculate,round,active,registerDate 
    } = payload.data;

    const matchSummary = Object.assign(
      { id,homeSubscriptionId,guestSubscriptionId,fieldItemId,homePoints,
      guestPoints,matchDate,startTime,calculate,round,active,registerDate  }
    );

    yield put(loading(true));

    if (id !== 0){
      yield call(api.put, 'matchSummary/', matchSummary);
      yield put(updateMatchSummarySuccess(matchSummary));
    }else{
      yield call(api.post, 'matchSummary/', matchSummary); 
      yield put(addMatchSummarySuccess(matchSummary));
    }
  
    yield put(loading(false));

    toast.success('Operação realizada com sucesso!');
  
    history.push('/matchSummarys');
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao realizar a operação!');
    yield put(saveMatchSummaryFailure());
  }
}


export function* fetchMatchSummary({ payload }) {
   try {    
    yield put(loading(true));
    
    const matchSummaryId = payload.data;
  
    const response = yield call(api.get, `matchSummary/championship/${matchSummaryId}`);

    yield put(loading(false));

    yield put(fetchMatchSummarySuccess(response.data));
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao atualizar inscrição, confira seus dados!');
    yield put(fetchMatchSummaryFailure());
  }
}

export function* fetchMatchSummaryById({ payload }) {
  try {
    const { id,homeSubscriptionId,guestSubscriptionId,fieldItem,fieldId,fieldItemId,homePoints,
      guestPoints,matchDate,startTime,calculate,round,active,registerDate  } 
      = payload.data;

    const matchSummary = Object.assign(
      { id,homeSubscriptionId,guestSubscriptionId,fieldId,fieldItemId,homePoints,
      guestPoints,matchDate,startTime,calculate,round,active,registerDate  }
    );

    matchSummary.fieldId = fieldItem.fieldId;
    matchSummary.matchDate = format(new Date(matchSummary.matchDate),"yyyy-MM-dd");

    yield put(fetchMatchSummaryByIdSuccess(matchSummary));
    history.push('/matchSummary');
 } catch (err) {
   toast.error('Erro ao realizar a operação!');
 }
}

export function matchSummaryInitialValues() {
  history.push('/matchSummary');
}

export function matchSummaryBack() {
  history.push('/matchSummaryChampionship');
}

export default all([
  takeLatest('@matchSummary/MATCH_SUMMARY_INITIAL_VALUES', matchSummaryInitialValues), 
  takeLatest('@matchSummary/MATCH_SUMMARY_BACK', matchSummaryBack),   
  takeLatest('@matchSummary/SAVE_MATCH_SUMMARY_REQUEST', saveMatchSummary),
  takeLatest('@matchSummary/FETCH_MATCH_SUMMARY_REQUEST', fetchMatchSummary),
  takeLatest('@matchSummary/FETCH_MATCH_SUMMARY_ID_REQUEST', fetchMatchSummaryById)   
]);
