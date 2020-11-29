import { takeLatest, call, put, all } from 'redux-saga/effects';
import { toast } from 'react-toastify';
import { format } from 'date-fns';

import history from '~/services/history';
import api from '~/services/api';

import { saveTeamFailure, addTeamSuccess,  
          updateTeamSuccess, deleteTeamSuccess, deleteTeamFailure,
          fetchTeamSuccess,  fetchTeamFailure, 
          fetchTeamAllSuccess,  fetchTeamAllFailure, 
          fetchTeamByIdSuccess, updateStatusTeamSuccess, 
          updateStatusTeamFailure } from './actions';        

import { loading } from '~/store/modules/auth/actions';  
import { updateTeamActiveSuccess } from '~/store/modules/user/actions';          

export function* saveTeam({ payload }) {
  try {

    const { id, name, personId, observation, type, 
      fundationDate,active, symbol, state, registerDate } = payload.data;

    const team = Object.assign(
      { id, name, personId, observation, type, 
        fundationDate,active, symbol, state, registerDate }
    );

    yield put(loading(true));

    if (id !== 0){
      yield call(api.put, 'team', team);
      yield put(updateTeamSuccess(team));
    }else{
      yield call(api.post, 'team', team); 
      yield put(addTeamSuccess(team));
    }

    yield put(updateTeamActiveSuccess(team));
  
    yield put(loading(false));

    toast.success('Operação realizada com sucesso!');
  
    history.push('/teams');
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao realizar a operação!');
    yield put(saveTeamFailure());
  }
}

export function* deleteTeam({ payload }) {
  try {   
    const team = payload.data;
    
    const id = team.id;
    
    yield put(loading(true));

    yield call(api.delete, `team/${id}`);

    yield put(loading(false));

    toast.success('Time excluido com sucesso!');

    yield put(deleteTeamSuccess(id));
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao excluir team, confira seus dados!');
    yield put(deleteTeamFailure());
  }
}

export function* fetchTeam({ payload }) {
   try {    
    yield put(loading(true));
    
    const id  = payload.data;

//    const response = yield call(api.get, `team/idperson/${id}`);
    const response = yield call(api.get, `team/`);


    yield put(loading(false));

    yield put(fetchTeamSuccess(response.data));
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao atualizar Team, confira seus dados!');
    yield put(fetchTeamFailure());
  }
}

export function* fetchTeamAll({ payload }) {
  try {    
   yield put(loading(true));
   
   const response = yield call(api.get, `team/`);

   yield put(loading(false));

   yield put(fetchTeamAllSuccess(response.data));
 } catch (err) {
   yield put(loading(false));

   toast.error('Erro ao atualizar Team, confira seus dados!');
   yield put(fetchTeamAllFailure());
 }
}

export function* updateStatusTeam({ payload }) {
  try {
    const { id, name, personId, observation, type, 
      fundationDate,active, symbol, state, registerDate } = payload.data;

    const team = Object.assign(
      { id, name, personId, observation, type, 
        fundationDate,active, symbol, state, registerDate }
    );

    yield put(loading(true));

    yield call(api.put, `team/${team.id}`);

    yield put(updateStatusTeamSuccess(team));
   
    yield put(updateTeamActiveSuccess(team));

    const response = yield call(api.get, `team/idPerson/${team.personId}`);

    yield put(loading(false));

    toast.success('status atualizado com sucesso!');

    yield put(fetchTeamSuccess(response.data));

 } catch (err) {
console.log(err); 
   toast.error('Erro ao atualizar o status Team, confira seus dados!');
   yield put(updateStatusTeamFailure());
 }
}

export function* fetchTeamById({ payload }) {
  try {

    const { id, name, personId, observation, type, 
      fundationDate,active, symbol, state, registerDate } = payload.data;

    const team = Object.assign(
      { id, name, personId, observation, type, 
        fundationDate,active, symbol, state, registerDate }
    );

    team.fundationDate = format(new Date(team.fundationDate),"yyyy-MM-dd");
    team.symbol = `http://localhost:51933/picture/team/${team.symbol}`;

    yield put(fetchTeamByIdSuccess(team));
    history.push('/team');
 } catch (err) {
   toast.error('Erro ao realizar a operação!');
   yield put(updateStatusTeamFailure());
 }
}

export function teamInitialValues() {
  history.push('/team');
}


export default all([
  takeLatest('@team/TEAM_INITIAL_VALUES', teamInitialValues), 
  takeLatest('@team/SAVE_TEAM_REQUEST', saveTeam),
  takeLatest('@team/DELETE_TEAM_REQUEST', deleteTeam),
  takeLatest('@team/FETCH_TEAM_REQUEST', fetchTeam),
  takeLatest('@team/FETCH_TEAM_ALL_REQUEST', fetchTeamAll),
  takeLatest('@team/FETCH_TEAM_ID_REQUEST', fetchTeamById),   
  takeLatest('@team/UPDATE_STATUS_TEAM_REQUEST', updateStatusTeam)  
]);
