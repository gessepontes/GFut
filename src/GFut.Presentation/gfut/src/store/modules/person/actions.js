export function savePersonRequest(data) {
  return {
    type: '@person/SAVE_PERSON_REQUEST',
    payload: { data },
  };
}

export function savePersonFailure() {
  return {
    type: '@person/SAVE_PERSON_FAILURE',
  };
}

export function addPersonRequest(data) {
  return {
    type: '@person/ADD_PERSON_REQUEST',
    payload: { data },
  };
}

export function addPersonSuccess(data) {
  return {
    type: '@person/ADD_PERSON_SUCCESS',
    payload: { data },
  };
}

export function addPersonFailure() {
  return {
    type: '@person/ADD_PERSON_FAILURE',
  };
}

export function updatePersonRequest(data) {
  return {
    type: '@person/UPDATE_PERSON_REQUEST',
    payload: { data },
  };
}

export function updatePersonSuccess(data) {
  return {
    type: '@person/UPDATE_PERSON_SUCCESS',
    payload: { data },
  };
}

export function updatePersonFailure() {
  return {
    type: '@person/UPDATE_PERSON_FAILURE',
  };
}

export function deletePersonRequest(data) {
  return {
    type: '@person/DELETE_PERSON_REQUEST',
    payload: { data },
  };
}

export function deletePersonSuccess(data) {
  return {
    type: '@person/DELETE_PERSON_SUCCESS',
    payload: { data },
  };
}

export function deletePersonFailure() {
  return {
    type: '@person/DELETE_PERSON_REQUEST',
  };
}

export function fetchPersonRequest(data) {
  return {    
    type: '@person/FETCH_PERSON_REQUEST',
    payload: { data },
  };
}

export function fetchPersonSuccess(data) {
  return {
    type: '@person/FETCH_PERSON_SUCCESS',
    payload: { data },
  };
}

export function fetchPersonFailure() {
  return {
    type: '@person/FETCH_PERSON_FAILURE',
  };
}

export function fetchPersonByIdRequest(data) {
  return {
    type: '@person/FETCH_PERSON_ID_REQUEST',
    payload: { data },
  };
}

export function fetchPersonByIdSuccess(data) {
  return {
    type: '@person/FETCH_PERSON_ID_SUCCESS',
    payload: { data },
  };
}

export function fetchPersonByIdFailure() {
  return {
    type: '@person/FETCH_PERSON_ID_FAILURE',
  };
}

export function personInitialValues() {
  return {
    type: '@person/PERSON_INITIAL_VALUES',
  };
}

export function updatePicturePersonSuccess(data) {
  return {
    type: '@person/UPDATE_PICTURE_PERSON_SUCCESS',
    payload: { data }
  };
}

export function fetchPersonChampionshipDropRequest(data) {
  return {
    type: '@person/FETCH_PERSON_CHAMPIONSHIP_DROP_REQUEST',
    payload: { data },
  };
}


export function fetchPersonChampionshipDropSuccess(data) {
  return {
    type: '@person/FETCH_PERSON_CHAMPIONSHIP_DROP_SUCCESS',
    payload: { data },
  };
}

export function fetchPersonChampionshipDropFailure() {
  return {
    type: '@person/FETCH_PERSON_CHAMPIONSHIP_DROP_FAILURE',
  };
}

export function fetchPersonAllDropRequest(data) {
  return {
    type: '@person/FETCH_PERSON_ALL_DROP_REQUEST',
    payload: { data },
  };
}


export function fetchPersonAllDropSuccess(data) {
  return {
    type: '@person/FETCH_PERSON_ALL_DROP_SUCCESS',
    payload: { data },
  };
}

export function fetchPersonAllDropFailure() {
  return {
    type: '@person/FETCH_PERSON_ALL_DROP_FAILURE',
  };
}

export function fetchPersonFieldDropRequest(data) {
  return {
    type: '@person/FETCH_PERSON_FIELD_DROP_REQUEST',
    payload: { data },
  };
}


export function fetchPersonFieldDropSuccess(data) {
  return {
    type: '@person/FETCH_PERSON_FIELD_DROP_SUCCESS',
    payload: { data },
  };
}

export function fetchPersonFieldDropFailure() {
  return {
    type: '@person/FETCH_PERSON_FIELD_DROP_FAILURE',
  };
}

