import produce from 'immer';
import { format } from 'date-fns';

const INITIAL_STATE = {
  team: {
    id: 0,
    personId: 0,
    name:'',
    observation:'',
    type: 1,
    fundationDate: format(new Date(),"yyyy-MM-dd"),
    registerDate: new Date(),
    symbol: '',
    picture: '',
    state: true,
    active: true
  },
  teams: []
};

export default function team(state = INITIAL_STATE, action) {
  return produce(state, draft => {
    switch (action.type) {
      case '@team/FETCH_TEAM_SUCCESS': {
        return { ...state, teams: action.payload.data };
      }
      case '@team/FETCH_SEARCH_TEAM_SUCCESS': {
        return { ...state, teams: action.payload.data };
      }
      case '@team/FETCH_TEAM_ID_SUCCESS': {        
        return { 
          ...state, 
          team: action.payload.data 
        };        
      }      
      case '@team/ADD_TEAM_SUCCESS': {
        return { ...state, team: action.payload.data };        
      }
      case '@team/UPDATE_SIMBOL_TEAM_SUCCESS': {
        draft.team.symbol = action.payload.data;
        break;
      }      
      case '@team/UPDATE_TEAM_SUCCESS': {
        return { ...state, team: action.payload.data };  
      }case '@team/DELETE_TEAM_SUCCESS': {              
        return { 
                  ...state, 
                  teams: draft.teams.filter(teams => teams.id !== action.payload.data) 
               }; 
      }case '@team/TEAM_INITIAL_VALUES': {
        return { ...state, team: INITIAL_STATE.team };  
      }
      default:
        return { ...state };
    }
  });
}