import produce from 'immer';

const INITIAL_STATE = {
  groupChampionship: {
    id: 0,
    subscriptionId:0,
    groupId: "",
    active: true,
    registerDate: new Date(),
  },
  groupChampionships: []
};

export default function groupChampionship(state = INITIAL_STATE, action) {
  return produce(state, draft => {
    switch (action.type) {
      case '@groupChampionship/FETCH_GROUP_CHAMPIONSHIP_SUCCESS': {
        return { 
          ...state, groupChampionships: action.payload.data
         };
      }
      case '@groupChampionship/FETCH_GROUP_CHAMPIONSHIP_ID_SUCCESS': {        
        return { 
          ...state, 
          groupChampionship: action.payload.data 
        };        
      }      
      case '@groupChampionship/ADD_GROUP_CHAMPIONSHIP_SUCCESS': {
        return { ...state, groupChampionship: action.payload.data };        
      }   
      case '@groupChampionship/UPDATE_GROUP_CHAMPIONSHIP_SUCCESS': {
        return { ...state, groupChampionship: action.payload.data };  
      }case '@groupChampionship/DELETE_GROUP_CHAMPIONSHIP_SUCCESS': {              
        return { 
                  ...state, 
                  groupChampionships: draft.groupChampionships.filter(groupChampionships => groupChampionships.id !== action.payload.data) 
               }; 
      }case '@groupChampionship/GROUP_CHAMPIONSHIP_INITIAL_VALUES': {
        return { ...state, groupChampionship: INITIAL_STATE.groupChampionship };  
      }
      case '@groupChampionship/AUTOMATIC_GROUP_CHAMPIONSHIP_ID_SUCCESS': {
        return { ...state };        
      } 
      default:
        return { ...state };
    }
  });
}