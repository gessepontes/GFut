export function saveHoraryExtraFieldRequest(data) {
  return {
    type: '@horaryExtraField/SAVE_HORARY_EXTRA_FIELD_REQUEST',
    payload: { data },
  };
}

export function saveHoraryExtraFieldFailure() {
  return {
    type: '@horaryExtraField/SAVE_HORARY_EXTRA_FIELD_FAILURE',
  };
}

export function addHoraryExtraFieldSuccess(data) {
  return {
    type: '@horaryExtraField/ADD_HORARY_EXTRA_FIELD_SUCCESS',
    payload: { data },
  };
}

export function updateHoraryExtraFieldSuccess(data) {
  return {
    type: '@horaryExtraField/UPDATE_HORARY_EXTRA_FIELD_SUCCESS',
    payload: { data },
  };
}

export function deleteHoraryExtraFieldRequest(data) {
  return {
    type: '@horaryExtraField/DELETE_HORARY_EXTRA_FIELD_REQUEST',
    payload: { data },
  };
}

export function deleteHoraryExtraFieldSuccess(data) {
  return {
    type: '@horaryExtraField/DELETE_HORARY_EXTRA_FIELD_SUCCESS',
    payload: { data },
  };
}

export function deleteHoraryExtraFieldFailure() {
  return {
    type: '@horaryExtraField/DELETE_HORARY_EXTRA_FIELD_FAILURE',
  };
}

export function fetchHoraryExtraFieldRequest() {
  return {
    type: '@horaryExtraField/FETCH_HORARY_EXTRA_FIELD_REQUEST',
  };
}

export function fetchHoraryExtraFieldSuccess(data) {
  return {
    type: '@horaryExtraField/FETCH_HORARY_EXTRA_FIELD_SUCCESS',
    payload: { data },
  };
}

export function fetchHoraryExtraFieldFailure() {
  return {
    type: '@horaryExtraField/FETCH_HORARY_EXTRA_FIELD_FAILURE',
  };
}

export function fetchSearchHoraryExtraFieldRequest(data) {
  return {
    type: '@horaryExtraField/FETCH_SEARCH_HORARY_EXTRA_FIELD_REQUEST',
    payload: { data },
  };
}

export function fetchSearchHoraryExtraFieldSuccess(data) {
  return {
    type: '@horaryExtraField/FETCH_SEARCH_HORARY_EXTRA_FIELD_SUCCESS',
    payload: { data },
  };
}

export function fetchSearchHoraryExtraFieldFailure() {
  return {
    type: '@horaryExtraField/FETCH_SEARCH_HORARY_EXTRA_FIELD_FAILURE',
  };
}

export function fetchHoraryExtraFieldByIdRequest(data) {
  return {
    type: '@horaryExtraField/FETCH_HORARY_EXTRA_FIELD_ID_REQUEST',
    payload: { data },
  };
}

export function fetchHoraryExtraFieldByIdSuccess(data) {
  return {
    type: '@horaryExtraField/FETCH_HORARY_EXTRA_FIELD_ID_SUCCESS',
    payload: { data },
  };
}

export function fetchHoraryExtraFieldByIdFailure() {
  return {
    type: '@horaryExtraField/FETCH_HORARY_EXTRA_FIELD_ID_FAILURE',
  };
}

export function horaryExtraFieldInitialValues() {
  return {
    type: '@horaryExtraField/HORARY_EXTRA_FIELD_INITIAL_VALUES',
  };
}

export function fetchHoraryExtraFieldByIdFieldRequest(data) {
  return {
    type: '@horaryExtraField/FETCH_HORARY_EXTRA_FIELD_ID_FIELD_REQUEST',
    payload: { data },
  };
}

export function fetchHoraryExtraFieldByIdFieldSuccess(data) {
  return {
    type: '@horaryExtraField/FETCH_HORARY_EXTRA_FIELD_ID_FIELD_SUCCESS',
    payload: { data },
  };
}

export function fetchHoraryExtraFieldByIdFieldFailure() {
  return {
    type: '@horaryExtraField/FETCH_HORARY_EXTRA_FIELD_ID_FIELD_FAILURE',
  };
}

export function horaryExtraFieldBack() {
  return {
    type: '@horaryExtraField/HORARY_EXTRA_FIELD_BACK',
  };
}