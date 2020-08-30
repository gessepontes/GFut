export function saveFieldRequest(data) {
  return {
    type: '@field/SAVE_FIELD_REQUEST',
    payload: { data },
  };
}

export function saveFieldFailure() {
  return {
    type: '@field/SAVE_FIELD_FAILURE',
  };
}

export function addFieldSuccess(data) {
  return {
    type: '@field/ADD_FIELD_SUCCESS',
    payload: { data },
  };
}

export function updateFieldSuccess(data) {
  return {
    type: '@field/UPDATE_FIELD_SUCCESS',
    payload: { data },
  };
}

export function deleteFieldRequest(data) {
  return {
    type: '@field/DELETE_FIELD_REQUEST',
    payload: { data },
  };
}

export function deleteFieldSuccess(data) {
  return {
    type: '@field/DELETE_FIELD_SUCCESS',
    payload: { data },
  };
}

export function deleteFieldFailure() {
  return {
    type: '@field/DELETE_FIELD_FAILURE',
  };
}

export function fetchFieldRequest() {
  return {
    type: '@field/FETCH_FIELD_REQUEST',
  };
}

export function fetchFieldSuccess(data) {
  return {
    type: '@field/FETCH_FIELD_SUCCESS',
    payload: { data },
  };
}

export function fetchFieldFailure() {
  return {
    type: '@field/FETCH_FIELD_FAILURE',
  };
}

export function fetchSearchFieldRequest(data) {
  return {
    type: '@field/FETCH_SEARCH_FIELD_REQUEST',
    payload: { data },
  };
}

export function fetchSearchFieldSuccess(data) {
  return {
    type: '@field/FETCH_SEARCH_FIELD_SUCCESS',
    payload: { data },
  };
}

export function fetchSearchFieldFailure() {
  return {
    type: '@field/FETCH_SEARCH_FIELD_FAILURE',
  };
}

export function fetchFieldByIdRequest(data) {
  return {
    type: '@field/FETCH_FIELD_ID_REQUEST',
    payload: { data },
  };
}

export function fetchFieldByIdSuccess(data) {
  return {
    type: '@field/FETCH_FIELD_ID_SUCCESS',
    payload: { data },
  };
}

export function fetchFieldByIdFailure() {
  return {
    type: '@field/FETCH_FIELD_ID_FAILURE',
  };
}

export function fieldInitialValues() {
  return {
    type: '@field/FIELD_INITIAL_VALUES',
  };
}

export function updatePictureFieldSuccess(data) {
  return {
    type: '@field/UPDATE_PICTURE_FIELD_SUCCESS',
    payload: { data }
  };
}