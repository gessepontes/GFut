import produce from 'immer';

const INITIAL_STATE = {
  championship: {
    id: 0,
    name: '',
    championshipType:0,
    refereeType:0,
    Type:0,
    startDate: new Date(),
    endDate: new Date(),
    fieldId : 0,
    amountTeam: 0,
    releaseSubscription: false,
    goBack: false,
    playerRegistration: false,
    picture: '',
    personId: 0,
    active: true,
    registerDate: new Date(),
  },
  championships: []
};

export default function championship(state = INITIAL_STATE, action) {
  return produce(state, draft => {
    switch (action.type) {
      case '@championship/FETCH_CHAMPIONSHIP_SUCCESS': {
        return { ...state, championships: action.payload.data };
      }
      case '@championship/FETCH_GROUP_CHAMPIONSHIP_SUCCESS': {
        return { ...state, championships: action.payload.data };
      }
      case '@championship/FETCH_CHAMPIONSHIP_ID_SUCCESS': {        
        return { 
          ...state, 
          championship: action.payload.data 
        };        
      }      
      case '@championship/ADD_CHAMPIONSHIP_SUCCESS': {
        return { ...state, championship: action.payload.data };        
      }
      case '@championship/UPDATE_PICTURE_CHAMPIONSHIP_SUCCESS': {
        draft.championship.picture = action.payload.data;
        break;
      }      
      case '@championship/UPDATE_CHAMPIONSHIP_SUCCESS': {
        return { ...state, championship: action.payload.data };  
      }case '@championship/DELETE_CHAMPIONSHIP_SUCCESS': {              
        return { 
                  ...state, 
                  championships: draft.championships.filter(championships => championships.id !== action.payload.data) 
               }; 
      }case '@championship/CHAMPIONSHIP_INITIAL_VALUES': {
        return { ...state, championship: INITIAL_STATE.championship };  
      }
      default:
        return { ...state };
    }
  });
}