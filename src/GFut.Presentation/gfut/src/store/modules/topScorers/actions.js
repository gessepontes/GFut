export function fetchTopScorersRequest(data) {
  return {
    type: '@topScorers/FETCH_TOP_SCORERS_REQUEST',
    payload: { data },
  };
}

export function fetchTopScorersSuccess(data) {
  return {
    type: '@topScorers/FETCH_TOP_SCORERS_SUCCESS',
    payload: { data },
  };
}

export function fetchTopScorersFailure() {
  return {
    type: '@topScorers/FETCH_TOP_SCORERS_FAILURE',
  };
}
export function topScorersBack() {
  return {
    type: '@topScorers/TOP_SCORERS_BACK',
  };
}