export function fetchSuspendedPlayersRequest(data) {
  return {
    type: '@suspendedPlayers/FETCH_SUSPENDED_PLAYER_REQUEST',
    payload: { data },
  };
}

export function fetchSuspendedPlayersSuccess(data) {
  return {
    type: '@suspendedPlayers/FETCH_SUSPENDED_PLAYER_SUCCESS',
    payload: { data },
  };
}

export function fetchSuspendedPlayersFailure() {
  return {
    type: '@suspendedPlayers/FETCH_SUSPENDED_PLAYER_FAILURE',
  };
}
export function suspendedPlayersBack() {
  return {
    type: '@suspendedPlayers/SUSPENDED_PLAYER_BACK',
  };
}