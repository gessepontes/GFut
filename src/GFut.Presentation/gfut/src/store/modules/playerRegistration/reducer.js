import produce from 'immer';

const INITIAL_STATE = {
  playerRegistration: {
    id: 0,
    playerId:0,
    subscriptionId:0,
    state: "",
    approvedDate: new Date(),
    active: true,
    registerDate: new Date(),
  },
  playerRegistrations: []
};

export default function playerRegistration(state = INITIAL_STATE, action) {
  return produce(state, draft => {
    switch (action.type) {
      case '@playerRegistration/FETCH_PLAYER_REGISTRATION_SUCCESS': {
        return { 
          ...state, playerRegistrations: action.payload.data
         };
      }
      case '@playerRegistration/FETCH_PLAYER_REGISTRATION_ID_SUCCESS': {        
        return { 
          ...state, 
          playerRegistration: action.payload.data 
        };        
      }      
      case '@playerRegistration/ADD_PLAYER_REGISTRATION_SUCCESS': {
        return { ...state, playerRegistration: action.payload.data };        
      }
      case '@playerRegistration/UPDATE_PICTURE_PLAYER_REGISTRATION_SUCCESS': {
        draft.playerRegistration.picture = action.payload.data;
        break;
      }      
      case '@playerRegistration/UPDATE_PLAYER_REGISTRATION_SUCCESS': {
        return { ...state, playerRegistration: action.payload.data };  
      }case '@playerRegistration/DELETE_PLAYER_REGISTRATION_SUCCESS': {              
        return { 
                  ...state, 
                  playerRegistrations: draft.playerRegistrations.filter(playerRegistrations => playerRegistrations.id !== action.payload.data) 
               }; 
      }case '@playerRegistration/PLAYER_REGISTRATION_INITIAL_VALUES': {
        return { ...state, playerRegistration: INITIAL_STATE.playerRegistration };  
      }
      default:
        return { ...state };
    }
  });
}