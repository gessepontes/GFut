import { takeLatest, call, put, all } from 'redux-saga/effects';
import { toast } from 'react-toastify';

import history from '~/services/history';
import api from '~/services/api';

import { fetchStandingsSuccess,  fetchStandingsFailure} from './actions';

import { loading } from '~/store/modules/auth/actions';          

export function* fetchStandings({ payload }) {
   try {    
    yield put(loading(true));
    
    const championshipId = payload.data;

    const response = yield call(api.get, `standings/championship/${championshipId}`);

    yield put(loading(false));

    yield put(fetchStandingsSuccess(response.data));
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao carregar a classificação!');
    yield put(fetchStandingsFailure());
  }
}

export function standingsBack() {
  history.push('/standingsListChampionship');
}


export default all([
  takeLatest('@standings/STANDINGS_BACK', standingsBack),   
  takeLatest('@standings/FETCH_STANDINGS_REQUEST', fetchStandings),  
]);
