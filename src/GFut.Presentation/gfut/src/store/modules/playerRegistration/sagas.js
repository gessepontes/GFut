import { takeLatest, call, put, all } from 'redux-saga/effects';
import { toast } from 'react-toastify';
import { format } from 'date-fns';

import history from '~/services/history';
import api from '~/services/api';

import { savePlayerRegistrationFailure, addPlayerRegistrationSuccess,  
          updatePlayerRegistrationSuccess, deletePlayerRegistrationSuccess, deletePlayerRegistrationFailure,
          fetchPlayerRegistrationSuccess,  fetchPlayerRegistrationFailure, 
          fetchPlayerRegistrationByIdSuccess} from './actions';

import { loading } from '~/store/modules/auth/actions';          

export function* savePlayerRegistration({ payload }) {
  try {
    const {id,playerId,subscriptionId,state,approvedDate,active,registerDate 
    } = payload.data;  
    
    const playerRegistration = Object.assign(
      { id,playerId,subscriptionId,state,approvedDate,active,registerDate }
    );

    playerRegistration.state = "A";  
    
    yield put(loading(true));

    if (id !== 0){
      yield call(api.put, 'playerRegistration/', playerRegistration);
      yield put(updatePlayerRegistrationSuccess(playerRegistration));
    }else{
      yield call(api.post, 'playerRegistration/', playerRegistration); 
      yield put(addPlayerRegistrationSuccess(playerRegistration));
    }
  
    yield put(loading(false));

    toast.success('Operação realizada com sucesso!');
  
    history.push('/playerRegistrations');
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao realizar a operação!');
    yield put(savePlayerRegistrationFailure());
  }
}

export function* deletePlayerRegistration({ payload }) {
  try {   
    const PlayerRegistration = payload.data;
    
    const id = PlayerRegistration.id;
    
    yield put(loading(true));

    yield call(api.delete, `playerRegistration/${id}`);

    yield put(loading(false));

    toast.success('Inscrição excluido com sucesso!');

    yield put(deletePlayerRegistrationSuccess(id));
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao excluir inscrição, confira seus dados!');
    yield put(deletePlayerRegistrationFailure());
  }
}

export function* fetchPlayerRegistration({ payload }) {
   try {    
    yield put(loading(true));
    
    const championshipId = payload.data;

    const response = yield call(api.get, `playerRegistration/championship/${championshipId}`);

    yield put(loading(false));

    yield put(fetchPlayerRegistrationSuccess(response.data));
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao atualizar inscrição, confira seus dados!');
    yield put(fetchPlayerRegistrationFailure());
  }
}

export function* fetchPlayerRegistrationById({ payload }) {
  try {

    const { id,playerId,subscriptionId,state,approvedDate,active,registerDate } 
      = payload.data;

    const playerRegistration = Object.assign(
      { id,playerId,subscriptionId,state,approvedDate,active,registerDate }
    );

    playerRegistration.approvedDate = format(new Date(playerRegistration.approvedDate),"yyyy-MM-dd");

    yield put(fetchPlayerRegistrationByIdSuccess(playerRegistration));
    history.push('/playerRegistration');
 } catch (err) {
   toast.error('Erro ao realizar a operação!');
 }
}

export function playerRegistrationInitialValues() {
  history.push('/playerRegistration');
}

export function playerRegistrationBack() {
  history.push('/playerRegistrationChampionship');
}


export default all([
  takeLatest('@playerRegistration/PLAYER_REGISTRATION_INITIAL_VALUES', playerRegistrationInitialValues), 
  takeLatest('@playerRegistration/PLAYER_REGISTRATION_BACK', playerRegistrationBack),   
  takeLatest('@playerRegistration/SAVE_PLAYER_REGISTRATION_REQUEST', savePlayerRegistration),
  takeLatest('@playerRegistration/DELETE_PLAYER_REGISTRATION_REQUEST', deletePlayerRegistration),
  takeLatest('@playerRegistration/FETCH_PLAYER_REGISTRATION_REQUEST', fetchPlayerRegistration),
  takeLatest('@playerRegistration/FETCH_PLAYER_REGISTRATION_ID_REQUEST', fetchPlayerRegistrationById),    
]);
