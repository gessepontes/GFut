export function savePlayerRegistrationRequest(data) {
  return {
    type: '@playerRegistration/SAVE_PLAYER_REGISTRATION_REQUEST',
    payload: { data },
  };
}

export function savePlayerRegistrationFailure() {
  return {
    type: '@playerRegistration/SAVE_PLAYER_REGISTRATION_FAILURE',
  };
}

export function addPlayerRegistrationSuccess(data) {
  return {
    type: '@playerRegistration/ADD_PLAYER_REGISTRATION_SUCCESS',
    payload: { data },
  };
}

export function updatePlayerRegistrationSuccess(data) {
  return {
    type: '@playerRegistration/UPDATE_PLAYER_REGISTRATION_SUCCESS',
    payload: { data },
  };
}

export function deletePlayerRegistrationRequest(data) {
  return {
    type: '@playerRegistration/DELETE_PLAYER_REGISTRATION_REQUEST',
    payload: { data },
  };
}

export function deletePlayerRegistrationSuccess(data) {
  return {
    type: '@playerRegistration/DELETE_PLAYER_REGISTRATION_SUCCESS',
    payload: { data },
  };
}

export function deletePlayerRegistrationFailure() {
  return {
    type: '@playerRegistration/DELETE_PLAYER_REGISTRATION_FAILURE',
  };
}

export function fetchPlayerRegistrationRequest(data) {
  return {
    type: '@playerRegistration/FETCH_PLAYER_REGISTRATION_REQUEST',
    payload: { data },
  };
}

export function fetchPlayerRegistrationSuccess(data) {
  return {
    type: '@playerRegistration/FETCH_PLAYER_REGISTRATION_SUCCESS',
    payload: { data },
  };
}

export function fetchPlayerRegistrationFailure() {
  return {
    type: '@playerRegistration/FETCH_PLAYER_REGISTRATION_FAILURE',
  };
}

export function fetchSearchPlayerRegistrationRequest(data) {
  return {
    type: '@playerRegistration/FETCH_SEARCH_PLAYER_REGISTRATION_REQUEST',
    payload: { data },
  };
}

export function fetchSearchPlayerRegistrationSuccess(data) {
  return {
    type: '@playerRegistration/FETCH_SEARCH_PLAYER_REGISTRATION_SUCCESS',
    payload: { data },
  };
}

export function fetchSearchPlayerRegistrationFailure() {
  return {
    type: '@playerRegistration/FETCH_SEARCH_PLAYER_REGISTRATION_FAILURE',
  };
}

export function fetchPlayerRegistrationByIdRequest(data) {
  return {
    type: '@playerRegistration/FETCH_PLAYER_REGISTRATION_ID_REQUEST',
    payload: { data },
  };
}

export function fetchPlayerRegistrationByIdSuccess(data) {
  return {
    type: '@playerRegistration/FETCH_PLAYER_REGISTRATION_ID_SUCCESS',
    payload: { data },
  };
}

export function fetchPlayerRegistrationByIdFailure() {
  return {
    type: '@playerRegistration/FETCH_PLAYER_REGISTRATION_ID_FAILURE',
  };
}

export function playerRegistrationInitialValues() {
  return {
    type: '@playerRegistration/PLAYER_REGISTRATION_INITIAL_VALUES',
  };
}

export function playerRegistrationBack() {
  return {
    type: '@playerRegistration/PLAYER_REGISTRATION_BACK',
  };
}

export function updatePicturePlayerRegistrationSuccess(data) {
  return {
    type: '@playerRegistration/UPDATE_PICTURE_PLAYER_REGISTRATION_SUCCESS',
    payload: { data }
  };
}