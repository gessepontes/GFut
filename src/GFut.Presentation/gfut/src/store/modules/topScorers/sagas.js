import { takeLatest, call, put, all } from 'redux-saga/effects';
import { toast } from 'react-toastify';

import history from '~/services/history';
import api from '~/services/api';

import { fetchTopScorersSuccess,  fetchTopScorersFailure} from './actions';

import { loading } from '~/store/modules/auth/actions';          

export function* fetchTopScorers({ payload }) {
   try {    
    yield put(loading(true));
    
    const championshipId = payload.data;

    const response = yield call(api.get, `topScorers/championship/${championshipId}`);

    yield put(loading(false));

    yield put(fetchTopScorersSuccess(response.data));
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao carregar a classificação!');
    yield put(fetchTopScorersFailure());
  }
}

export function topScorersBack() {
  history.push('/topScorersListChampionship');
}


export default all([
  takeLatest('@topScorers/TOP_SCORERS_BACK', topScorersBack),   
  takeLatest('@topScorers/FETCH_TOP_SCORERS_REQUEST', fetchTopScorers),  
]);
