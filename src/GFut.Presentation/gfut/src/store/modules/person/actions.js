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
