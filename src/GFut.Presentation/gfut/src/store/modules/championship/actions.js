export function saveChampionshipRequest(data) {
  return {
    type: '@championship/SAVE_CHAMPIONSHIP_REQUEST',
    payload: { data },
  };
}

export function saveChampionshipFailure() {
  return {
    type: '@championship/SAVE_CHAMPIONSHIP_FAILURE',
  };
}

export function addChampionshipSuccess(data) {
  return {
    type: '@championship/ADD_CHAMPIONSHIP_SUCCESS',
    payload: { data },
  };
}

export function updateChampionshipSuccess(data) {
  return {
    type: '@championship/UPDATE_CHAMPIONSHIP_SUCCESS',
    payload: { data },
  };
}

export function deleteChampionshipRequest(data) {
  return {
    type: '@championship/DELETE_CHAMPIONSHIP_REQUEST',
    payload: { data },
  };
}

export function deleteChampionshipSuccess(data) {
  return {
    type: '@championship/DELETE_CHAMPIONSHIP_SUCCESS',
    payload: { data },
  };
}

export function deleteChampionshipFailure() {
  return {
    type: '@championship/DELETE_CHAMPIONSHIP_FAILURE',
  };
}

export function fetchChampionshipRequest() {
  return {
    type: '@championship/FETCH_CHAMPIONSHIP_REQUEST',
  };
}

export function fetchChampionshipSuccess(data) {
  return {
    type: '@championship/FETCH_CHAMPIONSHIP_SUCCESS',
    payload: { data },
  };
}

export function fetchChampionshipFailure() {
  return {
    type: '@championship/FETCH_CHAMPIONSHIP_FAILURE',
  };
}

export function fetchGroupChampionshipRequest() {
  return {
    type: '@championship/FETCH_GROUP_CHAMPIONSHIP_REQUEST',
  };
}

export function fetchGroupChampionshipSuccess(data) {
  return {
    type: '@championship/FETCH_GROUP_CHAMPIONSHIP_SUCCESS',
    payload: { data },
  };
}

export function fetchGroupChampionshipFailure() {
  return {
    type: '@championship/FETCH_GROUP_CHAMPIONSHIP_FAILURE',
  };
}

export function fetchChampionshipByIdRequest(data) {
  return {
    type: '@championship/FETCH_CHAMPIONSHIP_ID_REQUEST',
    payload: { data },
  };
}

export function fetchChampionshipByIdSuccess(data) {
  return {
    type: '@championship/FETCH_CHAMPIONSHIP_ID_SUCCESS',
    payload: { data },
  };
}

export function fetchChampionshipByIdFailure() {
  return {
    type: '@championship/FETCH_CHAMPIONSHIP_ID_FAILURE',
  };
}

export function championshipInitialValues() {
  return {
    type: '@championship/CHAMPIONSHIP_INITIAL_VALUES',
  };
}

export function updatePictureChampionshipSuccess(data) {
  return {
    type: '@championship/UPDATE_PICTURE_CHAMPIONSHIP_SUCCESS',
    payload: { data }
  };
}