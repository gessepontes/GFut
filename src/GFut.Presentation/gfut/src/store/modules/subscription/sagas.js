import { takeLatest, call, put, all } from 'redux-saga/effects';
import { toast } from 'react-toastify';
import { format } from 'date-fns';

import history from '~/services/history';
import api from '~/services/api';

import { saveSubscriptionFailure, addSubscriptionSuccess,  
          updateSubscriptionSuccess, deleteSubscriptionSuccess, deleteSubscriptionFailure,
          fetchSubscriptionSuccess,  fetchSubscriptionFailure, 
          fetchSubscriptionByIdSuccess, fetchSubscriptionByChampionshipIdSuccess,
          fetchSubscriptionByChampionshipIdFailure} from './actions';

import { loading } from '~/store/modules/auth/actions';          

export function* saveSubscription({ payload }) {
  try {
    
    const {id,championshipId,teamId,state,approvedDate,active,registerDate 
    } = payload.data;

    const subscription = Object.assign(
      { id,championshipId,teamId,state,approvedDate,active,registerDate }
    );

    yield put(loading(true));

    if (id !== 0){
      yield call(api.put, 'subscription/', subscription);
      yield put(updateSubscriptionSuccess(subscription));
    }else{
      yield call(api.post, 'subscription/', subscription); 
      yield put(addSubscriptionSuccess(subscription));
    }
  
    yield put(loading(false));

    toast.success('Operação realizada com sucesso!');
  
    history.push('/subscriptions');
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao realizar a operação!');
    yield put(saveSubscriptionFailure());
  }
}

export function* deleteSubscription({ payload }) {
  try {   
    const Subscription = payload.data;
    
    const id = Subscription.id;
    
    yield put(loading(true));

    yield call(api.delete, `subscription/${id}`);

    yield put(loading(false));

    toast.success('Inscrição excluido com sucesso!');

    yield put(deleteSubscriptionSuccess(id));
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao excluir inscrição, confira seus dados!');
    yield put(deleteSubscriptionFailure());
  }
}

export function* fetchSubscription({ payload }) {
   try {    
    yield put(loading(true));

    const championshipId = payload.data;
    
    const response = yield call(api.get, `subscription/championship/${championshipId}`);

    yield put(loading(false));

    yield put(fetchSubscriptionSuccess(response.data));
  } catch (err) {
    yield put(loading(false));

    toast.error('Erro ao atualizar inscrição, confira seus dados!');
    yield put(fetchSubscriptionFailure());
  }
}

export function* fetchSubscriptionByChampionshipId({ payload }) {
  try {    
   yield put(loading(true));

   const championshipId = payload.data;

   const response = yield call(api.get, `subscription/championship/${championshipId}`);

   yield put(loading(false));

   yield put(fetchSubscriptionByChampionshipIdSuccess(response.data));
 } catch (err) {
   yield put(loading(false));

   toast.error('Erro ao atualizar inscrição, confira seus dados!');
   yield put(fetchSubscriptionByChampionshipIdFailure());
 }
}

export function* fetchSubscriptionById({ payload }) {
  try {

    const { id,championshipId,teamId,state,approvedDate,active,registerDate } 
      = payload.data;

    const subscription = Object.assign(
      { id,championshipId,teamId,state,approvedDate,active,registerDate }
    );

    subscription.approvedDate = format(new Date(subscription.approvedDate),"yyyy-MM-dd");

    yield put(fetchSubscriptionByIdSuccess(subscription));
    history.push('/subscription');
 } catch (err) {
   toast.error('Erro ao realizar a operação!');
 }
}

export function SubscriptionInitialValues() {
  history.push('/subscription');
}

export function subscriptionBack() {
  history.push('/subscriptionChampionship');
}

export default all([
  takeLatest('@subscription/SUBSCRIPTION_INITIAL_VALUES', SubscriptionInitialValues), 
  takeLatest('@subscription/SUBSCRIPTION_BACK', subscriptionBack), 
  takeLatest('@subscription/SAVE_SUBSCRIPTION_REQUEST', saveSubscription),
  takeLatest('@subscription/DELETE_SUBSCRIPTION_REQUEST', deleteSubscription),
  takeLatest('@subscription/FETCH_SUBSCRIPTION_REQUEST', fetchSubscription),
  takeLatest('@subscription/FETCH_SUBSCRIPTION_ID_REQUEST', fetchSubscriptionById),   
  takeLatest('@subscription/FETCH_SUBSCRIPTION_CHAMPIONSHIP_ID_REQUEST', fetchSubscriptionByChampionshipId),  
]);
