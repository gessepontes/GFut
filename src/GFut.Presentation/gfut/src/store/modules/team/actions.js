export function saveTeamRequest(data) {
  return {
    type: '@team/SAVE_TEAM_REQUEST',
    payload: { data },
  };
}

export function saveTeamFailure() {
  return {
    type: '@team/SAVE_TEAM_FAILURE',
  };
}

export function addTeamSuccess(data) {
  return {
    type: '@team/ADD_TEAM_SUCCESS',
    payload: { data },
  };
}

export function updateTeamSuccess(data) {
  return {
    type: '@team/UPDATE_TEAM_SUCCESS',
    payload: { data },
  };
}

export function updateStatusTeamRequest(data) {
  return {
    type: '@team/UPDATE_STATUS_TEAM_REQUEST',
    payload: { data },
  };
}

export function updateStatusTeamSuccess(data) {
  return {
    type: '@team/UPDATE_STATUS_TEAM_SUCCESS',
    payload: { data },
  };
}

export function updateStatusTeamFailure() {
  return {
    type: '@team/UPDATE_STATUS_TEAM_FAILURE',
  };
}

export function deleteTeamRequest(data) {
  return {
    type: '@team/DELETE_TEAM_REQUEST',
    payload: { data },
  };
}

export function deleteTeamSuccess(data) {
  return {
    type: '@team/DELETE_TEAM_SUCCESS',
    payload: { data },
  };
}

export function deleteTeamFailure() {
  return {
    type: '@team/DELETE_TEAM_FAILURE',
  };
}

export function fetchTeamRequest(data) {
  return {
    type: '@team/FETCH_TEAM_REQUEST',
    payload: { data },
  };
}

export function fetchTeamSuccess(data) {
  return {
    type: '@team/FETCH_TEAM_SUCCESS',
    payload: { data },
  };
}

export function fetchTeamFailure() {
  return {
    type: '@team/FETCH_TEAM_FAILURE',
  };
}

export function fetchSearchTeamRequest(data) {
  return {
    type: '@team/FETCH_SEARCH_TEAM_REQUEST',
    payload: { data },
  };
}

export function fetchSearchTeamSuccess(data) {
  return {
    type: '@team/FETCH_SEARCH_TEAM_SUCCESS',
    payload: { data },
  };
}

export function fetchSearchTeamFailure() {
  return {
    type: '@team/FETCH_SEARCH_TEAM_FAILURE',
  };
}

export function fetchTeamByIdRequest(data) {
  return {
    type: '@team/FETCH_TEAM_ID_REQUEST',
    payload: { data },
  };
}

export function fetchTeamByIdSuccess(data) {
  return {
    type: '@team/FETCH_TEAM_ID_SUCCESS',
    payload: { data },
  };
}

export function fetchTeamByIdFailure() {
  return {
    type: '@team/FETCH_TEAM_ID_FAILURE',
  };
}

export function teamInitialValues() {
  return {
    type: '@team/TEAM_INITIAL_VALUES',
  };
}

export function updateSimbolTeamSuccess(data) {
  return {
    type: '@team/UPDATE_SIMBOL_TEAM_SUCCESS',
    payload: { data }
  };
}