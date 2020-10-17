export function saveSubscriptionRequest(data) {
  return {
    type: '@subscription/SAVE_SUBSCRIPTION_REQUEST',
    payload: { data },
  };
}

export function saveSubscriptionFailure() {
  return {
    type: '@subscription/SAVE_SUBSCRIPTION_FAILURE',
  };
}

export function addSubscriptionSuccess(data) {
  return {
    type: '@subscription/ADD_SUBSCRIPTION_SUCCESS',
    payload: { data },
  };
}

export function updateSubscriptionSuccess(data) {
  return {
    type: '@subscription/UPDATE_SUBSCRIPTION_SUCCESS',
    payload: { data },
  };
}

export function deleteSubscriptionRequest(data) {
  return {
    type: '@subscription/DELETE_SUBSCRIPTION_REQUEST',
    payload: { data },
  };
}

export function deleteSubscriptionSuccess(data) {
  return {
    type: '@subscription/DELETE_SUBSCRIPTION_SUCCESS',
    payload: { data },
  };
}

export function deleteSubscriptionFailure() {
  return {
    type: '@subscription/DELETE_SUBSCRIPTION_FAILURE',
  };
}

export function fetchSubscriptionRequest(data) {
  return {
    type: '@subscription/FETCH_SUBSCRIPTION_REQUEST',
    payload: { data },
  };
}

export function fetchSubscriptionSuccess(data) {
  return {
    type: '@subscription/FETCH_SUBSCRIPTION_SUCCESS',
    payload: { data },
  };
}

export function fetchSubscriptionFailure() {
  return {
    type: '@subscription/FETCH_SUBSCRIPTION_FAILURE',
  };
}

export function fetchSubscriptionByIdRequest(data) {
  return {
    type: '@subscription/FETCH_SUBSCRIPTION_ID_REQUEST',
    payload: { data },
  };
}

export function fetchSubscriptionByIdSuccess(data) {
  return {
    type: '@subscription/FETCH_SUBSCRIPTION_ID_SUCCESS',
    payload: { data },
  };
}

export function fetchSubscriptionByIdFailure() {
  return {
    type: '@subscription/FETCH_SUBSCRIPTION_ID_FAILURE',
  };
}

export function fetchSubscriptionByChampionshipIdRequest(data) {
  return {
    type: '@subscription/FETCH_SUBSCRIPTION_CHAMPIONSHIP_ID_REQUEST',
    payload: { data },
  };
}

export function fetchSubscriptionByChampionshipIdSuccess(data) {
  return {
    type: '@subscription/FETCH_SUBSCRIPTION_CHAMPIONSHIP_ID_SUCCESS',
    payload: { data },
  };
}

export function fetchSubscriptionByChampionshipIdFailure() {
  return {
    type: '@subscription/FETCH_SUBSCRIPTION_CHAMPIONSHIP_ID_FAILURE',
  };
}

export function subscriptionInitialValues() {
  return {
    type: '@subscription/SUBSCRIPTION_INITIAL_VALUES',
  };
}

export function subscriptionBack() {
  return {
    type: '@subscription/SUBSCRIPTION_BACK',
  };
}

export function updatePictureSubscriptionSuccess(data) {
  return {
    type: '@subscription/UPDATE_PICTURE_SUBSCRIPTION_SUCCESS',
    payload: { data }
  };
}