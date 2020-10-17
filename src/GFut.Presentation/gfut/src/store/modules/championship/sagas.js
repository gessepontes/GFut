import { takeLatest, call, put, all } from 'redux-saga/effects';
import { toast } from 'react-toastify';
import { format } from 'date-fns';

import history from '~/services/history';
import api from '~/services/api';

import { saveChampionshipFailure, addChampionshipSuccess,  
          updateChampionshipSuccess, deleteChampionshipSuccess, deleteChampionshipFailure,
          fetchChampionshipSuccess,  fetchChampionshipFailure, fetchGroupChampionshipFailure,
          fetchGroupChampionshipSuccess, fetchChampionshipByIdSuccess} from './actions';

import { loading } from '~/store/modules/auth/actions';          

export function* saveChampionship({ payload }) {
  try {

    const {id,name,championshipType,refereeType,Type,startDate,endDate,fieldId,amountTeam,
      releaseSubscription,goBack,playerRegistration,picture,personId,active,registerDate 
    } = payload.data;

    const championship = Object.assign(
      { id,name,championshipType,refereeType,Type,startDate,endDate,fieldId,amountTeam,
        releaseSubscription,goBack,playerRegistration,picture,personId,active,registerDate }
    );

    yield put(loading(true));

    if (id !== 0){
      yield call(api.put, 'championship/', championship);
      yield put(updateChampionshipSuccess(championship));
    }else{
      yield call(api.post, 'championship/', championship); 
      yield put(addChampionshipSuccess(championship));
    }
  
    yield put(loading(false));

    toast.success('Operação realizada com sucesso!');
  
    history.push('/championships');
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao realizar a operação!');
    yield put(saveChampionshipFailure());
  }
}

export function* deleteChampionship({ payload }) {
  try {   
    const Championship = payload.data;
    
    const id = Championship.id;
    
    yield put(loading(true));

    yield call(api.delete, `championship/${id}`);

    yield put(loading(false));

    toast.success('Campeonato excluido com sucesso!');

    yield put(deleteChampionshipSuccess(id));
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao excluir campeonato, confira seus dados!');
    yield put(deleteChampionshipFailure());
  }
}

export function* fetchChampionship() {
   try {    
    yield put(loading(true));

    const response = yield call(api.get, `championship`);

    yield put(loading(false));

    yield put(fetchChampionshipSuccess(response.data));
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao atualizar campeonato, confira seus dados!');
    yield put(fetchChampionshipFailure());
  }
}

export function* fetchGroupChampionship() {
  try {    
   yield put(loading(true));

   const response = yield call(api.get, `championship/group`);

   yield put(loading(false));

   yield put(fetchGroupChampionshipSuccess(response.data));
 } catch (err) {
   yield put(loading(false));

   toast.error('Erro ao atualizar campeonato, confira seus dados!');
   yield put(fetchGroupChampionshipFailure());
 }
}

export function* fetchChampionshipById({ payload }) {
  try {

    const { id,name,championshipType,refereeType,Type,startDate,endDate,fieldId,amountTeam,
      releaseSubscription,goBack,playerRegistration,picture,personId,active,registerDate 
    } = payload.data;

    const championship = Object.assign(
      { id,name,championshipType,refereeType,Type,startDate,endDate,fieldId,amountTeam,
        releaseSubscription,goBack,playerRegistration,picture,personId,active,registerDate }
    );

    championship.picture = `http://localhost:51933/picture/championship/${championship.picture}`;

    championship.startDate = format(new Date(championship.startDate),"yyyy-MM-dd");
    championship.endDate = format(new Date(championship.endDate),"yyyy-MM-dd");

    yield put(fetchChampionshipByIdSuccess(championship));
    history.push('/championship');
 } catch (err) {
   toast.error('Erro ao realizar a operação!');
 }
}

export function ChampionshipInitialValues() {
  history.push('/championship');
}


export default all([
  takeLatest('@championship/CHAMPIONSHIP_INITIAL_VALUES', ChampionshipInitialValues), 
  takeLatest('@championship/SAVE_CHAMPIONSHIP_REQUEST', saveChampionship),
  takeLatest('@championship/DELETE_CHAMPIONSHIP_REQUEST', deleteChampionship),
  takeLatest('@championship/FETCH_CHAMPIONSHIP_REQUEST', fetchChampionship),
  takeLatest('@championship/FETCH_GROUP_CHAMPIONSHIP_REQUEST', fetchGroupChampionship),
  takeLatest('@championship/FETCH_CHAMPIONSHIP_ID_REQUEST', fetchChampionshipById),    
]);
