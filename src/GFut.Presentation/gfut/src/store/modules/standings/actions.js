export function fetchStandingsRequest(data) {
  return {
    type: '@standings/FETCH_STANDINGS_REQUEST',
    payload: { data },
  };
}

export function fetchStandingsSuccess(data) {
  return {
    type: '@standings/FETCH_STANDINGS_SUCCESS',
    payload: { data },
  };
}

export function fetchStandingsFailure() {
  return {
    type: '@standings/FETCH_STANDINGS_FAILURE',
  };
}
export function standingsBack() {
  return {
    type: '@standings/STANDINGS_BACK',
  };
}