import produce from 'immer';

const INITIAL_STATE = {
  matchChampionship: {
    id: 0,
    homeSubscriptionId:0,
    guestSubscriptionId: 0,
    fieldId: 0,
    fieldItemId: 0,
    homePoints: 0,
    guestPoints: 0,
    matchDate: new Date(),
    startTime: "",
    calculate: false,
    round: 0,
    active: true,
    registerDate: new Date(),
  },
  matchChampionships: []
};

export default function matchChampionship(state = INITIAL_STATE, action) {
  return produce(state, draft => {
    switch (action.type) {
      case '@matchChampionship/FETCH_MATCH_CHAMPIONSHIP_SUCCESS': {
        return { 
          ...state, matchChampionships: action.payload.data
         };
      }
      case '@matchChampionship/FETCH_MATCH_CHAMPIONSHIP_ID_SUCCESS': {        
        return { 
          ...state, 
          matchChampionship: action.payload.data 
        };        
      }      
      case '@matchChampionship/ADD_MATCH_CHAMPIONSHIP_SUCCESS': {
        return { ...state, matchChampionship: action.payload.data };        
      }   
      case '@matchChampionship/UPDATE_MATCH_CHAMPIONSHIP_SUCCESS': {
        return { ...state, matchChampionship: action.payload.data };  
      }case '@matchChampionship/DELETE_MATCH_CHAMPIONSHIP_SUCCESS': {              
        return { 
                  ...state, 
                  matchChampionships: draft.matchChampionships.filter(matchChampionships => matchChampionships.id !== action.payload.data) 
               }; 
      }case '@matchChampionship/MATCH_CHAMPIONSHIP_INITIAL_VALUES': {
        return { ...state, matchChampionship: INITIAL_STATE.matchChampionship };  
      }
      case '@matchChampionship/AUTOMATIC_MATCH_CHAMPIONSHIP_ID_SUCCESS': {
        return { ...state };        
      } 
      default:
        return { ...state };
    }
  });
}