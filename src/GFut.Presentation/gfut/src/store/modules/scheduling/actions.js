export function saveSchedulingRequest(data) {
  return {
    type: '@scheduling/SAVE_SCHEDULING_REQUEST',
    payload: { data },
  };
}

export function saveSchedulingFailure() {
  return {
    type: '@scheduling/SAVE_SCHEDULING_FAILURE',
  };
}

export function addSchedulingSuccess(data) {
  return {
    type: '@scheduling/ADD_SCHEDULING_SUCCESS',
    payload: { data },
  };
}

export function updateSchedulingSuccess(data) {
  return {
    type: '@scheduling/UPDATE_SCHEDULING_SUCCESS',
    payload: { data },
  };
}

export function deleteSchedulingRequest(data) {
  return {
    type: '@scheduling/DELETE_SCHEDULING_REQUEST',
    payload: { data },
  };
}

export function deleteSchedulingSuccess(data) {
  return {
    type: '@scheduling/DELETE_SCHEDULING_SUCCESS',
    payload: { data },
  };
}

export function deleteSchedulingFailure() {
  return {
    type: '@scheduling/DELETE_SCHEDULING_FAILURE',
  };
}

export function fetchSchedulingRequest() {
  return {
    type: '@scheduling/FETCH_SCHEDULING_REQUEST',
  };
}

export function fetchSchedulingSuccess(data) {
  return {
    type: '@scheduling/FETCH_SCHEDULING_SUCCESS',
    payload: { data },
  };
}

export function fetchSchedulingFailure() {
  return {
    type: '@scheduling/FETCH_SCHEDULING_FAILURE',
  };
}

export function fetchSearchSchedulingRequest(data) {
  return {
    type: '@scheduling/FETCH_SEARCH_SCHEDULING_REQUEST',
    payload: { data },
  };
}

export function fetchSearchSchedulingSuccess(data) {
  return {
    type: '@scheduling/FETCH_SEARCH_SCHEDULING_SUCCESS',
    payload: { data },
  };
}

export function fetchSearchSchedulingFailure() {
  return {
    type: '@scheduling/FETCH_SEARCH_SCHEDULING_FAILURE',
  };
}

export function fetchSchedulingByIdRequest(data) {
  return {
    type: '@scheduling/FETCH_SCHEDULING_ID_REQUEST',
    payload: { data },
  };
}

export function fetchSchedulingByIdSuccess(data) {
  return {
    type: '@scheduling/FETCH_SCHEDULING_ID_SUCCESS',
    payload: { data },
  };
}

export function fetchSchedulingByIdFailure() {
  return {
    type: '@scheduling/FETCH_SCHEDULING_ID_FAILURE',
  };
}

export function schedulingInitialValues() {
  return {
    type: '@scheduling/SCHEDULING_INITIAL_VALUES',
  };
}

export function updatePictureSchedulingSuccess(data) {
  return {
    type: '@scheduling/UPDATE_PICTURE_SCHEDULING_SUCCESS',
    payload: { data }
  };
}

export function fetchSchedulingByIdFieldRequest(data) {
  return {
    type: '@scheduling/FETCH_SCHEDULING_ID_FIELD_REQUEST',
    payload: { data },
  };
}

export function fetchSchedulingByIdFieldSuccess(data) {
  return {
    type: '@scheduling/FETCH_SCHEDULING_ID_FIELD_SUCCESS',
    payload: { data },
  };
}

export function fetchSchedulingByIdFieldFailure() {
  return {
    type: '@scheduling/FETCH_SCHEDULING_ID_FIELD_FAILURE',
  };
}

export function schedulingBack() {
  return {
    type: '@scheduling/SCHEDULING_BACK',
  };
}