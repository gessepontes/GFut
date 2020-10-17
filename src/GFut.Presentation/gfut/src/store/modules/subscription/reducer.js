import produce from 'immer';

const INITIAL_STATE = {
  subscription: {
    id: 0,
    championshipId:0,
    teamId:0,
    state: "",
    approvedDate: new Date(),
    active: true,
    registerDate: new Date(),
  },
  subscriptions: []
};

export default function subscription(state = INITIAL_STATE, action) {
  return produce(state, draft => {
    switch (action.type) {
      case '@subscription/FETCH_SUBSCRIPTION_SUCCESS': {
        return { ...state, subscriptions: action.payload.data };
      }
      case '@subscription/FETCH_SUBSCRIPTION_CHAMPIONSHIP_ID_SUCCESS': {
        return { ...state, subscriptions: action.payload.data };
      }
      case '@subscription/FETCH_SUBSCRIPTION_ID_SUCCESS': {        
        return { 
          ...state, 
          subscription: action.payload.data 
        };        
      }      
      case '@subscription/ADD_SUBSCRIPTION_SUCCESS': {
        return { ...state, subscription: action.payload.data };        
      }
      case '@subscription/UPDATE_PICTURE_SUBSCRIPTION_SUCCESS': {
        draft.subscription.picture = action.payload.data;
        break;
      }      
      case '@subscription/UPDATE_SUBSCRIPTION_SUCCESS': {
        return { ...state, subscription: action.payload.data };  
      }case '@subscription/DELETE_SUBSCRIPTION_SUCCESS': {              
        return { 
                  ...state, 
                  subscriptions: draft.subscriptions.filter(subscriptions => subscriptions.id !== action.payload.data) 
               }; 
      }case '@subscription/SUBSCRIPTION_INITIAL_VALUES': {
        return { ...state, subscription: INITIAL_STATE.subscription };  
      }
      default:
        return { ...state };
    }
  });
}