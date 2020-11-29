import produce from 'immer';

const INITIAL_STATE = {
  horaryField: {
    id: 0,
    fieldItemId: '',
    hour: '',
    dayWeek: 0,
    state: 0,
    active: true,
    registerDate: new Date(),
  },
  horaryFields: []
};

export default function horaryField(state = INITIAL_STATE, action) {
  return produce(state, draft => {
    switch (action.type) {
      case '@horaryField/FETCH_HORARY_FIELD_SUCCESS': {
        return { ...state, horaryFields: action.payload.data };
      }
      case '@horaryField/FETCH_HORARY_FIELD_ID_FIELD_SUCCESS': {
        return { ...state, horaryFields: action.payload.data };
      }
      case '@horaryField/FETCH_HORARY_FIELD_ID_SUCCESS': {        
        return { 
          ...state, 
          horaryField: action.payload.data 
        };        
      }      
      case '@horaryField/ADD_HORARY_FIELD_SUCCESS': {
        return { ...state, horaryField: action.payload.data };        
      }    
      case '@horaryField/UPDATE_HORARY_FIELD_SUCCESS': {
        return { ...state, horaryField: action.payload.data };  
      }case '@horaryField/DELETE_HORARY_FIELD_SUCCESS': {              
        return { 
                  ...state, 
                  horaryFields: draft.horaryFields.filter(horaryFields => horaryFields.id !== action.payload.data) 
               }; 
      }case '@horaryField/HORARY_FIELD_INITIAL_VALUES': {
        return { ...state, horaryField: INITIAL_STATE.horaryField };  
      }
      default:
        return { ...state };
    }
  });
}