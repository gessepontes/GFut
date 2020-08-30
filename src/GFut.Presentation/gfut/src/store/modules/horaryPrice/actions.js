export function saveHoraryPriceRequest(data) {
  return {
    type: '@horaryPrice/SAVE_HORARY_PRICE_REQUEST',
    payload: { data },
  };
}

export function saveHoraryPriceFailure() {
  return {
    type: '@horaryPrice/SAVE_HORARY_PRICE_FAILURE',
  };
}

export function addHoraryPriceSuccess(data) {
  return {
    type: '@horaryPrice/ADD_HORARY_PRICE_SUCCESS',
    payload: { data },
  };
}

export function updateHoraryPriceSuccess(data) {
  return {
    type: '@horaryPrice/UPDATE_HORARY_PRICE_SUCCESS',
    payload: { data },
  };
}

export function deleteHoraryPriceRequest(data) {
  return {
    type: '@horaryPrice/DELETE_HORARY_PRICE_REQUEST',
    payload: { data },
  };
}

export function deleteHoraryPriceSuccess(data) {
  return {
    type: '@horaryPrice/DELETE_HORARY_PRICE_SUCCESS',
    payload: { data },
  };
}

export function deleteHoraryPriceFailure() {
  return {
    type: '@horaryPrice/DELETE_HORARY_PRICE_FAILURE',
  };
}

export function fetchHoraryPriceRequest() {
  return {
    type: '@horaryPrice/FETCH_HORARY_PRICE_REQUEST',
  };
}

export function fetchHoraryPriceSuccess(data) {
  return {
    type: '@horaryPrice/FETCH_HORARY_PRICE_SUCCESS',
    payload: { data },
  };
}

export function fetchHoraryPriceFailure() {
  return {
    type: '@horaryPrice/FETCH_HORARY_PRICE_FAILURE',
  };
}

export function fetchSearchHoraryPriceRequest(data) {
  return {
    type: '@horaryPrice/FETCH_SEARCH_HORARY_PRICE_REQUEST',
    payload: { data },
  };
}

export function fetchSearchHoraryPriceSuccess(data) {
  return {
    type: '@horaryPrice/FETCH_SEARCH_HORARY_PRICE_SUCCESS',
    payload: { data },
  };
}

export function fetchSearchHoraryPriceFailure() {
  return {
    type: '@horaryPrice/FETCH_SEARCH_HORARY_PRICE_FAILURE',
  };
}

export function fetchHoraryPriceByIdRequest(data) {
  return {
    type: '@horaryPrice/FETCH_HORARY_PRICE_ID_REQUEST',
    payload: { data },
  };
}

export function fetchHoraryPriceByIdSuccess(data) {
  return {
    type: '@horaryPrice/FETCH_HORARY_PRICE_ID_SUCCESS',
    payload: { data },
  };
}

export function fetchHoraryPriceByIdFailure() {
  return {
    type: '@horaryPrice/FETCH_HORARY_PRICE_ID_FAILURE',
  };
}

export function horaryPriceInitialValues() {
  return {
    type: '@horaryPrice/HORARY_PRICE_INITIAL_VALUES',
  };
}

export function updatePictureHoraryPriceSuccess(data) {
  return {
    type: '@horaryPrice/UPDATE_PICTURE_HORARY_PRICE_SUCCESS',
    payload: { data }
  };
}