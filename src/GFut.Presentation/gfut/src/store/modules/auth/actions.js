export function loading(value) {
  return {
    type: '@auth/LOADING',
    payload:  value ,
  };
}

export function signInRequest(email, password) {
  return {
    type: '@auth/SIGN_IN_REQUEST',
    payload: { email, password },
  };
}

export function signInSuccess(user) {
  return {
    type: '@auth/SIGN_IN_SUCCESS',
    payload: { user },
  };
}

export function signUpRequest(name, email, phone, password) {
  return {
    type: '@auth/SIGN_UP_REQUEST',
    payload: { name, email, phone, password },
  };
}

export function signFailure() {
  return {
    type: '@auth/SIGN_FAILURE',
  };
}

export function signOut() {
  return {
    type: '@auth/SIGN_OUT',
  };
}