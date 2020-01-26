export function updatePersonRequest(data) {
  return {
    type: '@user/UPDATE_PERSON_REQUEST',
    payload: { data },
  };
}

export function updatePersonSuccess(person) {
  return {
    type: '@user/UPDATE_PERSON_SUCCESS',
    payload: { person },
  };
}

export function updatePersonFailure() {
  return {
    type: '@user/UPDATE_PERSON_REQUEST',
  };
}