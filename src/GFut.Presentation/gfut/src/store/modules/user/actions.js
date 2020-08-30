export function updateProfileRequest(data) {
  return {
    type: '@user/UPDATE_PROFILE_REQUEST',
    payload: { data },
  };
}

export function updateProfileSuccess(data) {
  return {
    type: '@user/UPDATE_PROFILE_SUCCESS',
    payload: { data },
  };
}

export function updateTeamActiveSuccess(data) {
  return {
    type: '@user/UPDATE_TEAM_ACTIVE_SUCCESS',
    payload: { data },
  };
}

export function updateProfileFailure() {
  return {
    type: '@user/UPDATE_PROFILE_REQUEST',
  };
}

export function updatePictureProfileSuccess(data) {
  return {
    type: '@user/UPDATE_PICTURE_PROFILE_SUCCESS',
    payload: { data }
  };
}
