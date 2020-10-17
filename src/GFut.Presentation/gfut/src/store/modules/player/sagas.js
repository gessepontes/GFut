import { takeLatest, call, put, all } from 'redux-saga/effects';
import { toast } from 'react-toastify';
import { format } from 'date-fns';

import history from '~/services/history';
import api from '~/services/api';

import { savePlayerFailure, addPlayerSuccess,  
          updatePlayerSuccess, deletePlayerSuccess, deletePlayerFailure,
          fetchPlayerSuccess,  fetchPlayerFailure, fetchPlayerByIdSubscriptionsSuccess,
          fetchPlayerByIdSubscriptionsFailure,fetchPlayerByIdSuccess, fetchPlayerByIdFailure
        } from './actions';

import { loading } from '~/store/modules/auth/actions';          

export function* savePlayer({ payload }) {
  try {

    const { id, teamId, name, picture, phone, position, 
      birthDate, dispensed, dispenseDate, active, registerDate } = payload.data;

    const player = Object.assign(
      { id, teamId, name, picture, phone, position, 
        birthDate, dispensed, dispenseDate, active, registerDate }
    );

    if(!dispensed){
      player.dispenseDate = "";
    }

    yield put(loading(true));

    if (id !== 0){
      yield call(api.put, 'player', player);
      yield put(updatePlayerSuccess(player));
    }else{
      yield call(api.post, 'player', player); 
      yield put(addPlayerSuccess(player));
    }
  
    yield put(loading(false));

    toast.success('Operação realizada com sucesso!');
  
    history.push('/players');
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao realizar a operação!');
    yield put(savePlayerFailure());
  }
}

export function* deletePlayer({ payload }) {
  try {   
    const player = payload.data;
    
    const id = player.id;
    
    yield put(loading(true));

    yield call(api.delete, `player/${id}`);

    yield put(loading(false));

    toast.success('Operação realizada com sucesso!');

    yield put(deletePlayerSuccess(id));

    history.push('/players');
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao realizar a operação!');
    yield put(deletePlayerFailure());
  }
}

export function* fetchPlayer({ payload }) {
   try {    
    yield put(loading(true));
    
    const id  = payload.data;
    
    const response = yield call(api.get, `player/idTeam/${id}`);

    yield put(fetchPlayerSuccess(response.data));

    yield put(loading(false));
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao realizar a operação!');
    yield put(fetchPlayerFailure());
  }
}

export function* fetchPlayerSubscriptions({ payload }) {
  try {    
   yield put(loading(true));
   
   const IdSubscription  = payload.data;
   
   const response = yield call(api.get, `player/Subscription/${IdSubscription}`);

   yield put(fetchPlayerByIdSubscriptionsSuccess(response.data));

   yield put(loading(false));
 } catch (err) {
   yield put(loading(false));

   toast.error('Erro ao realizar a operação!');
   yield put(fetchPlayerByIdSubscriptionsFailure());
 }
}

export function* fetchPlayerById({ payload }) {
  try {

    const { id, teamId, name, picture, phone, position, 
      birthDate, dispensed, dispenseDate, active, registerDate } = payload.data;

    const player = Object.assign(
      { id, teamId, name, picture, phone, position, 
        birthDate, dispensed, dispenseDate, active, registerDate }
    );

    player.picture = `http://localhost:51933/picture/player/${player.picture}`;

    if(!dispensed){
      player.dispenseDate = "";
    }else{
      player.dispenseDate = format(new Date(player.dispenseDate),"yyyy-MM-dd");
    }

    player.registerDate = format(new Date(player.registerDate),"yyyy-MM-dd");
    player.birthDate = format(new Date(player.birthDate),"yyyy-MM-dd");

    yield put(fetchPlayerByIdSuccess(player));

    history.push('/player');
 } catch (err) {
   toast.error('Erro ao realizar a operação!');
   yield put(fetchPlayerByIdFailure());
 }
}

export function playerInitialValues() {
  history.push('/player');
}


export default all([
  takeLatest('@player/PLAYER_INITIAL_VALUES', playerInitialValues), 
  takeLatest('@player/SAVE_PLAYER_REQUEST', savePlayer),
  takeLatest('@player/DELETE_PLAYER_REQUEST', deletePlayer),
  takeLatest('@player/FETCH_PLAYER_REQUEST', fetchPlayer),
  takeLatest('@player/FETCH_PLAYER_ID_SUBSCRIPTION_REQUEST', fetchPlayerSubscriptions),
  takeLatest('@player/FETCH_PLAYER_ID_REQUEST', fetchPlayerById),     
]);
