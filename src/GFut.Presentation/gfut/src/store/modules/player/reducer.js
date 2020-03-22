import produce from 'immer';
import { format } from 'date-fns';

const INITIAL_STATE = {
  player: {
    id: 0,
    teamId: 0,
    name:'',
    birthDate: format(new Date(),"yyyy-MM-dd"),
    picture: '',
    phone: '',
    position: 0,
    dispensed: false,
    dispenseDate: "",
    active: true,
    registerDate: new Date()
  },
  players: []
};

export default function player(state = INITIAL_STATE, action) {
  return produce(state, draft => {
    switch (action.type) {
      case '@player/FETCH_PLAYER_SUCCESS': {
        return { ...state, players: action.payload.data };
      }
      case '@player/FETCH_SEARCH_PLAYER_SUCCESS': {
        return { ...state, players: action.payload.data };
      }
      case '@player/FETCH_PLAYER_ID_SUCCESS': {        
        return { 
          ...state, 
          player: action.payload.data 
        };        
      }      
      case '@player/ADD_PLAYER_SUCCESS': {
        return { ...state, player: action.payload.data };        
      }
      case '@player/UPDATE_PICTURE_PLAYER_SUCCESS': {
        draft.player.picture = action.payload.data;
        break;
      }      
      case '@player/UPDATE_PLAYER_SUCCESS': {
        return { ...state, player: action.payload.data };  
      }case '@player/DELETE_PLAYER_SUCCESS': {              
        return { 
                  ...state, 
                  players: draft.players.filter(players => players.id !== action.payload.data) 
               }; 
      }case '@player/PLAYER_INITIAL_VALUES': {
        return { ...state, player: INITIAL_STATE.player };  
      }
      default:
        return { ...state };
    }
  });
}