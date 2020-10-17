import { takeLatest, call, put, all } from 'redux-saga/effects';
import { toast } from 'react-toastify';

import history from '~/services/history';
import api from '~/services/api';

import { fetchSuspendedPlayersSuccess,  fetchSuspendedPlayersFailure} from './actions';

import { loading } from '~/store/modules/auth/actions';          

export function* fetchSuspendedPlayers({ payload }) {
   try {    
    yield put(loading(true));
    
    const { championshipId, round } = payload.data;

    const suspendedPlayers = Object.assign(
      { championshipId, round  }
    );

    const response = yield call(api.get, `suspendedPlayers/championship/${suspendedPlayers.championshipId}/${suspendedPlayers.round}`);

    yield put(loading(false));

    yield put(fetchSuspendedPlayersSuccess(response.data));

    history.push('/suspendedPlayersList');
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao carregar a classificação!');
    yield put(fetchSuspendedPlayersFailure());
  }
}

export function suspendedPlayersBack() {
  history.push('/suspendedPlayersChampionship');
}


export default all([
  takeLatest('@suspendedPlayers/SUSPENDED_PLAYER_BACK', suspendedPlayersBack),   
  takeLatest('@suspendedPlayers/FETCH_SUSPENDED_PLAYER_REQUEST', fetchSuspendedPlayers),  
]);
