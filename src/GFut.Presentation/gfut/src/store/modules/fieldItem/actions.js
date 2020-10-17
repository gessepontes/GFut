export function saveFieldItemRequest(data) {
  return {
    type: '@fieldItem/SAVE_FIELD_ITEM_REQUEST',
    payload: { data },
  };
}

export function saveFieldItemFailure() {
  return {
    type: '@fieldItem/SAVE_FIELD_ITEM_FAILURE',
  };
}

export function addFieldItemSuccess(data) {
  return {
    type: '@fieldItem/ADD_FIELD_ITEM_SUCCESS',
    payload: { data },
  };
}

export function updateFieldItemSuccess(data) {
  return {
    type: '@fieldItem/UPDATE_FIELD_ITEM_SUCCESS',
    payload: { data },
  };
}

export function deleteFieldItemRequest(data) {
  return {
    type: '@fieldItem/DELETE_FIELD_ITEM_REQUEST',
    payload: { data },
  };
}

export function deleteFieldItemSuccess(data) {
  return {
    type: '@fieldItem/DELETE_FIELD_ITEM_SUCCESS',
    payload: { data },
  };
}

export function deleteFieldItemFailure() {
  return {
    type: '@fieldItem/DELETE_FIELD_ITEM_FAILURE',
  };
}

export function fetchFieldItemRequest() {
  return {
    type: '@fieldItem/FETCH_FIELD_ITEM_REQUEST',
  };
}

export function fetchFieldItemSuccess(data) {
  return {
    type: '@fieldItem/FETCH_FIELD_ITEM_SUCCESS',
    payload: { data },
  };
}

export function fetchFieldItemFailure() {
  return {
    type: '@fieldItem/FETCH_FIELD_ITEM_FAILURE',
  };
}

export function fetchFieldItemByIdRequest(data) {
  return {
    type: '@fieldItem/FETCH_FIELD_ITEM_ID_REQUEST',
    payload: { data },
  };
}

export function fetchFieldItemByIdSuccess(data) {
  return {
    type: '@fieldItem/FETCH_FIELD_ITEM_ID_SUCCESS',
    payload: { data },
  };
}

export function fetchFieldItemByIdFailure() {
  return {
    type: '@fieldItem/FETCH_FIELD_ITEM_ID_FAILURE',
  };
}

export function fieldItemInitialValues() {
  return {
    type: '@fieldItem/FIELD_ITEM_INITIAL_VALUES',
  };
}

export function updatePictureFieldItemSuccess(data) {
  return {
    type: '@fieldItem/UPDATE_PICTURE_FIELD_ITEM_SUCCESS',
    payload: { data }
  };
}

export function fetchFieldItemByIdFieldRequest(data) {
  return {
    type: '@fieldItem/FETCH_FIELD_ITEM_ID_FIELD_REQUEST',
    payload: { data },
  };
}

export function fetchFieldItemByIdFieldSuccess(data) {
  return {
    type: '@fieldItem/FETCH_FIELD_ITEM_ID_FIELD_SUCCESS',
    payload: { data },
  };
}

export function fetchFieldItemByIdFieldFailure() {
  return {
    type: '@fieldItem/FETCH_FIELD_ITEM_ID_FIELD_FAILURE',
  };
}