export function saveHoraryFieldRequest(data) {
  return {
    type: '@horaryField/SAVE_HORARY_FIELD_REQUEST',
    payload: { data },
  };
}

export function saveHoraryFieldFailure() {
  return {
    type: '@horaryField/SAVE_HORARY_FIELD_FAILURE',
  };
}

export function addHoraryFieldSuccess(data) {
  return {
    type: '@horaryField/ADD_HORARY_FIELD_SUCCESS',
    payload: { data },
  };
}

export function updateHoraryFieldSuccess(data) {
  return {
    type: '@horaryField/UPDATE_HORARY_FIELD_SUCCESS',
    payload: { data },
  };
}

export function deleteHoraryFieldRequest(data) {
  return {
    type: '@horaryField/DELETE_HORARY_FIELD_REQUEST',
    payload: { data },
  };
}

export function deleteHoraryFieldSuccess(data) {
  return {
    type: '@horaryField/DELETE_HORARY_FIELD_SUCCESS',
    payload: { data },
  };
}

export function deleteHoraryFieldFailure() {
  return {
    type: '@horaryField/DELETE_HORARY_FIELD_FAILURE',
  };
}

export function fetchHoraryFieldRequest() {
  return {
    type: '@horaryField/FETCH_HORARY_FIELD_REQUEST',
  };
}

export function fetchHoraryFieldSuccess(data) {
  return {
    type: '@horaryField/FETCH_HORARY_FIELD_SUCCESS',
    payload: { data },
  };
}

export function fetchHoraryFieldFailure() {
  return {
    type: '@horaryField/FETCH_HORARY_FIELD_FAILURE',
  };
}

export function fetchSearchHoraryFieldRequest(data) {
  return {
    type: '@horaryField/FETCH_SEARCH_HORARY_FIELD_REQUEST',
    payload: { data },
  };
}

export function fetchSearchHoraryFieldSuccess(data) {
  return {
    type: '@horaryField/FETCH_SEARCH_HORARY_FIELD_SUCCESS',
    payload: { data },
  };
}

export function fetchSearchHoraryFieldFailure() {
  return {
    type: '@horaryField/FETCH_SEARCH_HORARY_FIELD_FAILURE',
  };
}

export function fetchHoraryFieldByIdRequest(data) {
  return {
    type: '@horaryField/FETCH_HORARY_FIELD_ID_REQUEST',
    payload: { data },
  };
}

export function fetchHoraryFieldByIdSuccess(data) {
  return {
    type: '@horaryField/FETCH_HORARY_FIELD_ID_SUCCESS',
    payload: { data },
  };
}

export function fetchHoraryFieldByIdFailure() {
  return {
    type: '@horaryField/FETCH_HORARY_FIELD_ID_FAILURE',
  };
}

export function horaryFieldInitialValues() {
  return {
    type: '@horaryField/HORARY_FIELD_INITIAL_VALUES',
  };
}