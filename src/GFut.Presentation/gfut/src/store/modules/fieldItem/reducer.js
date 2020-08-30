import produce from 'immer';

const INITIAL_STATE = {
  fieldItem: {
    id: 0,
    name: '',
    fieldId: '',
    picture: '',
    active: true,
    registerDate: new Date(),
  },
  fieldItens: []
};

export default function fieldItem(state = INITIAL_STATE, action) {
  return produce(state, draft => {
    switch (action.type) {
      case '@fieldItem/FETCH_FIELD_ITEM_SUCCESS': {
        return { ...state, fieldItens: action.payload.data };
      }
      case '@fieldItem/FETCH_SEARCH_FIELD_ITEM_SUCCESS': {
        return { ...state, fieldItens: action.payload.data };
      }
      case '@fieldItem/FETCH_FIELD_ITEM_ID_SUCCESS': {        
        return { 
          ...state, 
          fieldItem: action.payload.data 
        };        
      }      
      case '@fieldItem/ADD_FIELD_ITEM_SUCCESS': {
        return { ...state, fieldItem: action.payload.data };        
      }
      case '@fieldItem/UPDATE_PICTURE_FIELD_ITEM_SUCCESS': {
        draft.fieldItem.picture = action.payload.data;
        break;
      }      
      case '@fieldItem/UPDATE_FIELD_ITEM_SUCCESS': {
        return { ...state, fieldItem: action.payload.data };  
      }case '@fieldItem/DELETE_FIELD_ITEM_SUCCESS': {              
        return { 
                  ...state, 
                  fieldItens: draft.fieldItens.filter(fieldItens => fieldItens.id !== action.payload.data) 
               }; 
      }case '@fieldItem/FIELD_ITEM_INITIAL_VALUES': {
        return { ...state, fieldItem: INITIAL_STATE.fieldItem };  
      }
      default:
        return { ...state };
    }
  });
}