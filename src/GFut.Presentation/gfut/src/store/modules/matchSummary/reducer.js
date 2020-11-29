import produce from 'immer';

const INITIAL_STATE = {
  matchSummary: {
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
  matchSummarys: []
};

export default function matchSummary(state = INITIAL_STATE, action) {
  return produce(state, draft => {
    switch (action.type) {
      case '@matchSummary/FETCH_MATCH_SUMMARY_SUCCESS': {
        return { 
          ...state, matchSummarys: action.payload.data
         };
      }
      case '@matchSummary/FETCH_MATCH_SUMMARY_ID_SUCCESS': {        
        return { 
          ...state, 
          matchSummary: action.payload.data 
        };        
      }      
      case '@matchSummary/ADD_MATCH_SUMMARY_SUCCESS': {
        return { ...state, matchSummary: action.payload.data };        
      }   
      case '@matchSummary/UPDATE_MATCH_SUMMARY_SUCCESS': {
        return { ...state, matchSummary: action.payload.data };  
      }case '@matchSummary/DELETE_MATCH_SUMMARY_SUCCESS': {              
        return { 
                  ...state, 
                  matchSummarys: draft.matchSummarys.filter(matchSummarys => matchSummarys.id !== action.payload.data) 
               }; 
      }case '@matchSummary/MATCH_SUMMARY_INITIAL_VALUES': {
        return { ...state, matchSummary: INITIAL_STATE.matchSummary };  
      }
      default:
        return { ...state };
    }
  });
}