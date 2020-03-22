import produce from 'immer';
import { format } from 'date-fns';

const INITIAL_STATE = {
  profile: {
    id: 0,
    name:'',
    email:'',
    phone: '',
    picture:'',
    birthDate: format(new Date(),"yyyy-MM-dd"),
    password: ''
  },
};

export default function user(state = INITIAL_STATE, action) {
  return produce(state, draft => {
    switch (action.type) {
      case '@auth/SIGN_IN_SUCCESS': {
        draft.profile = action.payload.user;
        break;
      }
      case '@user/UPDATE_PROFILE_SUCCESS': {
        return { ...state, profile: action.payload.data }; 
      }
      case '@user/UPDATE_PICTURE_PROFILE_SUCCESS': {
        draft.profile.picture = action.payload.data;
        break;
      }      
      case '@auth/SIGN_OUT': {
        draft.profile = null;
        break;
      }
      default:
    }
  });
}