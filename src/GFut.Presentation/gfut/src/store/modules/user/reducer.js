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
      case '@user/UPDATE_PROFILE_SUCCESS': 
      {
        // draft.profile.id = action.payload.data.id
        // draft.profile.name = action.payload.data.name
        // draft.profile.email = action.payload.data.email
        // draft.profile.phone = action.payload.data.phone
        // draft.profile.birthDate = action.payload.data.birthDate
        //draft.profile.picture = action.payload.data;
        break;
      } 
      case '@user/UPDATE_TEAM_ACTIVE_SUCCESS': {
        draft.profile.team = action.payload.data;
        break;
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