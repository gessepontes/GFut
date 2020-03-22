export function savePlayerRequest(data) {
  return {
    type: '@player/SAVE_PLAYER_REQUEST',
    payload: { data },
  };
}

export function savePlayerFailure() {
  return {
    type: '@player/SAVE_PLAYER_FAILURE',
  };
}

export function addPlayerRequest(data) {
  return {
    type: '@player/ADD_PLAYER_REQUEST',
    payload: { data },
  };
}

export function addPlayerSuccess(data) {
  return {
    type: '@player/ADD_PLAYER_SUCCESS',
    payload: { data },
  };
}

export function addPlayerFailure() {
  return {
    type: '@player/ADD_PLAYER_FAILURE',
  };
}

export function updatePlayerRequest(data) {
  return {
    type: '@player/UPDATE_PLAYER_REQUEST',
    payload: { data },
  };
}

export function updatePlayerSuccess(data) {
  return {
    type: '@player/UPDATE_PLAYER_SUCCESS',
    payload: { data },
  };
}

export function updatePlayerFailure() {
  return {
    type: '@player/UPDATE_PLAYER_FAILURE',
  };
}

export function deletePlayerRequest(data) {
  return {
    type: '@player/DELETE_PLAYER_REQUEST',
    payload: { data },
  };
}

export function deletePlayerSuccess(data) {
  return {
    type: '@player/DELETE_PLAYER_SUCCESS',
    payload: { data },
  };
}

export function deletePlayerFailure() {
  return {
    type: '@player/DELETE_PLAYER_REQUEST',
  };
}

export function fetchPlayerRequest(data) {
  return {    
    type: '@player/FETCH_PLAYER_REQUEST',
    payload: { data },
  };
}

export function fetchPlayerSuccess(data) {
  return {
    type: '@player/FETCH_PLAYER_SUCCESS',
    payload: { data },
  };
}

export function fetchPlayerFailure() {
  return {
    type: '@player/FETCH_PLAYER_FAILURE',
  };
}

export function fetchSearchPlayerRequest(data) {
  return {
    type: '@player/FETCH_SEARCH_PLAYER_REQUEST',
    payload: { data },
  };
}

export function fetchSearchPlayerSuccess(data) {
  return {
    type: '@player/FETCH_SEARCH_PLAYER_SUCCESS',
    payload: { data },
  };
}

export function fetchSearchPlayerFailure() {
  return {
    type: '@player/FETCH_SEARCH_PLAYER_FAILURE',
  };
}

export function fetchPlayerByIdRequest(data) {
  return {
    type: '@player/FETCH_PLAYER_ID_REQUEST',
    payload: { data },
  };
}

export function fetchPlayerByIdSuccess(data) {
  return {
    type: '@player/FETCH_PLAYER_ID_SUCCESS',
    payload: { data },
  };
}

export function fetchPlayerByIdFailure() {
  return {
    type: '@player/FETCH_PLAYER_ID_FAILURE',
  };
}

export function playerInitialValues() {
  return {
    type: '@player/PLAYER_INITIAL_VALUES',
  };
}

export function updatePicturePlayerSuccess(data) {
  return {
    type: '@player/UPDATE_PICTURE_PLAYER_SUCCESS',
    payload: { data }
  };
}