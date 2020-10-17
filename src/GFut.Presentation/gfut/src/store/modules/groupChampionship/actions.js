export function saveGroupChampionshipRequest(data) {
  return {
    type: '@groupChampionship/SAVE_GROUP_CHAMPIONSHIP_REQUEST',
    payload: { data },
  };
}

export function saveGroupChampionshipFailure() {
  return {
    type: '@groupChampionship/SAVE_GROUP_CHAMPIONSHIP_FAILURE',
  };
}

export function addGroupChampionshipSuccess(data) {
  return {
    type: '@groupChampionship/ADD_GROUP_CHAMPIONSHIP_SUCCESS',
    payload: { data },
  };
}

export function updateGroupChampionshipSuccess(data) {
  return {
    type: '@groupChampionship/UPDATE_GROUP_CHAMPIONSHIP_SUCCESS',
    payload: { data },
  };
}

export function deleteGroupChampionshipRequest(data) {
  return {
    type: '@groupChampionship/DELETE_GROUP_CHAMPIONSHIP_REQUEST',
    payload: { data },
  };
}

export function deleteGroupChampionshipSuccess(data) {
  return {
    type: '@groupChampionship/DELETE_GROUP_CHAMPIONSHIP_SUCCESS',
    payload: { data },
  };
}

export function deleteGroupChampionshipFailure() {
  return {
    type: '@groupChampionship/DELETE_GROUP_CHAMPIONSHIP_FAILURE',
  };
}

export function fetchGroupChampionshipRequest(data) {
  return {
    type: '@groupChampionship/FETCH_GROUP_CHAMPIONSHIP_REQUEST',
    payload: { data },
  };
}

export function fetchGroupChampionshipSuccess(data) {
  return {
    type: '@groupChampionship/FETCH_GROUP_CHAMPIONSHIP_SUCCESS',
    payload: { data },
  };
}

export function fetchGroupChampionshipFailure() {
  return {
    type: '@groupChampionship/FETCH_GROUP_CHAMPIONSHIP_FAILURE',
  };
}

export function fetchGroupChampionshipByIdRequest(data) {
  return {
    type: '@groupChampionship/FETCH_GROUP_CHAMPIONSHIP_ID_REQUEST',
    payload: { data },
  };
}

export function fetchGroupChampionshipByIdSuccess(data) {
  return {
    type: '@groupChampionship/FETCH_GROUP_CHAMPIONSHIP_ID_SUCCESS',
    payload: { data },
  };
}

export function fetchGroupChampionshipByIdFailure() {
  return {
    type: '@groupChampionship/FETCH_GROUP_CHAMPIONSHIP_ID_FAILURE',
  };
}

export function groupChampionshipInitialValues() {
  return {
    type: '@groupChampionship/GROUP_CHAMPIONSHIP_INITIAL_VALUES',
  };
}

export function groupChampionshipBack() {
  return {
    type: '@groupChampionship/GROUP_CHAMPIONSHIP_BACK',
  };
}


export function automaticGroupFailure() {
  return {
    type: '@groupChampionship/AUTOMATIC_GROUP_CHAMPIONSHIP_FAILURE',
  };
}

export function automaticGroupRequest(data) {
  return {
    type: '@groupChampionship/AUTOMATIC_GROUP_CHAMPIONSHIP_ID_REQUEST',
    payload: { data },
  };
}

export function automaticGroupSuccess(data) {
  return {
    type: '@groupChampionship/AUTOMATIC_GROUP_CHAMPIONSHIP_ID_SUCCESS',
    payload: { data },
  };
}