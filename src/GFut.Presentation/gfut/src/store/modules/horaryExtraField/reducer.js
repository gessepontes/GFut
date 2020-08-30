import produce from 'immer';

const INITIAL_STATE = {
  horaryExtraField: {
    id: 0,
    fieldItemId: '',
    hour: '',
    active: true,
    registerDate: new Date(),
  },
  horaryExtraFields: []
};

export default function horaryExtraField(state = INITIAL_STATE, action) {
  return produce(state, draft => {
    switch (action.type) {
      case '@horaryExtraField/FETCH_HORARY_EXTRA_FIELD_SUCCESS': {
        return { ...state, horaryExtraFields: action.payload.data };
      }
      case '@horaryExtraField/FETCH_SEARCH_HORARY_EXTRA_FIELD_SUCCESS': {
        return { ...state, horaryExtraFields: action.payload.data };
      }
      case '@horaryExtraField/FETCH_HORARY_EXTRA_FIELD_ID_SUCCESS': {        
        return { 
          ...state, 
          horaryExtraField: action.payload.data 
        };        
      }      
      case '@horaryExtraField/ADD_HORARY_EXTRA_FIELD_SUCCESS': {
        return { ...state, horaryExtraField: action.payload.data };        
      }    
      case '@horaryExtraField/UPDATE_HORARY_EXTRA_FIELD_SUCCESS': {
        return { ...state, horaryExtraField: action.payload.data };  
      }case '@horaryExtraField/DELETE_HORARY_EXTRA_FIELD_SUCCESS': {              
        return { 
                  ...state, 
                  horaryExtraFields: draft.horaryExtraFields.filter(horaryExtraFields => horaryExtraFields.id !== action.payload.data) 
               }; 
      }case '@horaryExtraField/HORARY_EXTRA_FIELD_INITIAL_VALUES': {
        return { ...state, horaryExtraField: INITIAL_STATE.horaryExtraField };  
      }
      default:
        return { ...state };
    }
  });
}