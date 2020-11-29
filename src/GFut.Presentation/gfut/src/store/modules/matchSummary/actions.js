export function saveMatchSummaryRequest(data) {
  return {
    type: '@matchSummary/SAVE_MATCH_SUMMARY_REQUEST',
    payload: { data },
  };
}

export function saveMatchSummaryFailure() {
  return {
    type: '@matchSummary/SAVE_MATCH_SUMMARY_FAILURE',
  };
}

export function addMatchSummarySuccess(data) {
  return {
    type: '@matchSummary/ADD_MATCH_SUMMARY_SUCCESS',
    payload: { data },
  };
}

export function updateMatchSummarySuccess(data) {
  return {
    type: '@matchSummary/UPDATE_MATCH_SUMMARY_SUCCESS',
    payload: { data },
  };
}

export function deleteMatchSummaryRequest(data) {
  return {
    type: '@matchSummary/DELETE_MATCH_SUMMARY_REQUEST',
    payload: { data },
  };
}

export function deleteMatchSummarySuccess(data) {
  return {
    type: '@matchSummary/DELETE_MATCH_SUMMARY_SUCCESS',
    payload: { data },
  };
}

export function deleteMatchSummaryFailure() {
  return {
    type: '@matchSummary/DELETE_MATCH_SUMMARY_FAILURE',
  };
}

export function fetchMatchSummaryRequest(data) {
  return {
    type: '@matchSummary/FETCH_MATCH_SUMMARY_REQUEST',
    payload: { data },
  };
}

export function fetchMatchSummarySuccess(data) {
  return {
    type: '@matchSummary/FETCH_MATCH_SUMMARY_SUCCESS',
    payload: { data },
  };
}

export function fetchMatchSummaryFailure() {
  return {
    type: '@matchSummary/FETCH_MATCH_SUMMARY_FAILURE',
  };
}

export function fetchMatchSummaryByIdRequest(data) {
  return {
    type: '@matchSummary/FETCH_MATCH_SUMMARY_ID_REQUEST',
    payload: { data },
  };
}

export function fetchMatchSummaryByIdSuccess(data) {
  return {
    type: '@matchSummary/FETCH_MATCH_SUMMARY_ID_SUCCESS',
    payload: { data },
  };
}

export function fetchMatchSummaryByIdFailure() {
  return {
    type: '@matchSummary/FETCH_MATCH_SUMMARY_ID_FAILURE',
  };
}

export function matchSummaryInitialValues() {
  return {
    type: '@matchSummary/MATCH_SUMMARY_INITIAL_VALUES',
  };
}

export function matchSummaryBack() {
  return {
    type: '@matchSummary/MATCH_SUMMARY_BACK',
  };
}