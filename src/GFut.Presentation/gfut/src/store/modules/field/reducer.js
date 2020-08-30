import produce from 'immer';

const INITIAL_STATE = {
  field: {
    id: 0,
    name: '',
    address:'',
    phone:'',
    value: 0,
    monthlyValue : 0,
    scheduled: false,
    picture: '',
    personId: 0,
    cityId: 0,
    active: true,
    registerDate: new Date(),
  },
  fields: []
};

export default function field(state = INITIAL_STATE, action) {
  return produce(state, draft => {
    switch (action.type) {
      case '@field/FETCH_FIELD_SUCCESS': {
        return { ...state, fields: action.payload.data };
      }
      case '@field/FETCH_SEARCH_FIELD_SUCCESS': {
        return { ...state, fields: action.payload.data };
      }
      case '@field/FETCH_FIELD_ID_SUCCESS': {        
        return { 
          ...state, 
          field: action.payload.data 
        };        
      }      
      case '@field/ADD_FIELD_SUCCESS': {
        return { ...state, field: action.payload.data };        
      }
      case '@field/UPDATE_PICTURE_FIELD_SUCCESS': {
        draft.field.picture = action.payload.data;
        break;
      }      
      case '@field/UPDATE_FIELD_SUCCESS': {
        return { ...state, field: action.payload.data };  
      }case '@field/DELETE_FIELD_SUCCESS': {              
        return { 
                  ...state, 
                  fields: draft.fields.filter(fields => fields.id !== action.payload.data) 
               }; 
      }case '@field/FIELD_INITIAL_VALUES': {
        return { ...state, field: INITIAL_STATE.field };  
      }
      default:
        return { ...state };
    }
  });
}