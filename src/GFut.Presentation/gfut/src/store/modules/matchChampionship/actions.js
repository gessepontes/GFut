export function saveMatchChampionshipRequest(data) {
  return {
    type: '@matchChampionship/SAVE_MATCH_CHAMPIONSHIP_REQUEST',
    payload: { data },
  };
}

export function saveMatchChampionshipFailure() {
  return {
    type: '@matchChampionship/SAVE_MATCH_CHAMPIONSHIP_FAILURE',
  };
}

export function addMatchChampionshipSuccess(data) {
  return {
    type: '@matchChampionship/ADD_MATCH_CHAMPIONSHIP_SUCCESS',
    payload: { data },
  };
}

export function updateMatchChampionshipSuccess(data) {
  return {
    type: '@matchChampionship/UPDATE_MATCH_CHAMPIONSHIP_SUCCESS',
    payload: { data },
  };
}

export function deleteMatchChampionshipRequest(data) {
  return {
    type: '@matchChampionship/DELETE_MATCH_CHAMPIONSHIP_REQUEST',
    payload: { data },
  };
}

export function deleteMatchChampionshipSuccess(data) {
  return {
    type: '@matchChampionship/DELETE_MATCH_CHAMPIONSHIP_SUCCESS',
    payload: { data },
  };
}

export function deleteMatchChampionshipFailure() {
  return {
    type: '@matchChampionship/DELETE_MATCH_CHAMPIONSHIP_FAILURE',
  };
}

export function fetchMatchChampionshipRequest(data) {
  return {
    type: '@matchChampionship/FETCH_MATCH_CHAMPIONSHIP_REQUEST',
    payload: { data },
  };
}

export function fetchMatchChampionshipSuccess(data) {
  return {
    type: '@matchChampionship/FETCH_MATCH_CHAMPIONSHIP_SUCCESS',
    payload: { data },
  };
}

export function fetchMatchChampionshipFailure() {
  return {
    type: '@matchChampionship/FETCH_MATCH_CHAMPIONSHIP_FAILURE',
  };
}

export function fetchMatchChampionshipByIdRequest(data) {
  return {
    type: '@matchChampionship/FETCH_MATCH_CHAMPIONSHIP_ID_REQUEST',
    payload: { data },
  };
}

export function fetchMatchChampionshipByIdSuccess(data) {
  return {
    type: '@matchChampionship/FETCH_MATCH_CHAMPIONSHIP_ID_SUCCESS',
    payload: { data },
  };
}

export function fetchMatchChampionshipByIdFailure() {
  return {
    type: '@matchChampionship/FETCH_MATCH_CHAMPIONSHIP_ID_FAILURE',
  };
}

export function matchChampionshipInitialValues() {
  return {
    type: '@matchChampionship/MATCH_CHAMPIONSHIP_INITIAL_VALUES',
  };
}

export function matchChampionshipBack() {
  return {
    type: '@matchChampionship/MATCH_CHAMPIONSHIP_BACK',
  };
}


export function automaticMatchFailure() {
  return {
    type: '@matchChampionship/AUTOMATIC_MATCH_CHAMPIONSHIP_FAILURE',
  };
}

export function automaticMatchRequest(data) {
  return {
    type: '@matchChampionship/AUTOMATIC_MATCH_CHAMPIONSHIP_ID_REQUEST',
    payload: { data },
  };
}

export function automaticMatchSuccess(data) {
  return {
    type: '@matchChampionship/AUTOMATIC_MATCH_CHAMPIONSHIP_ID_SUCCESS',
    payload: { data },
  };
}