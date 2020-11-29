import produce from 'immer';

const INITIAL_STATE = {
  horaryPrice: {
    id: 0,
    fieldItemId: '',
    startDate: new Date(),
    endDate: null,
    value: 0,
    monthlyValue: 0,
    active: true,
    registerDate: new Date(),
  },
  horaryPrices: []
};

export default function horaryPrice(state = INITIAL_STATE, action) {
  return produce(state, draft => {
    switch (action.type) {
      case '@horaryPrice/FETCH_HORARY_PRICE_SUCCESS': {
        return { ...state, horaryPrices: action.payload.data };
      }
      case '@horaryPrice/FETCH_HORARY_PRICE_ID_FIELD_SUCCESS': {
        return { ...state, horaryPrices: action.payload.data };
      }
      case '@horaryPrice/FETCH_HORARY_PRICE_ID_SUCCESS': {        
        return { 
          ...state, 
          horaryPrice: action.payload.data 
        };        
      }      
      case '@horaryPrice/ADD_HORARY_PRICE_SUCCESS': {
        return { ...state, horaryPrice: action.payload.data };        
      }
      case '@horaryPrice/UPDATE_PICTURE_HORARY_PRICE_SUCCESS': {
        draft.horaryPrice.picture = action.payload.data;
        break;
      }      
      case '@horaryPrice/UPDATE_HORARY_PRICE_SUCCESS': {
        return { ...state, horaryPrice: action.payload.data };  
      }case '@horaryPrice/DELETE_HORARY_PRICE_SUCCESS': {              
        return { 
                  ...state, 
                  horaryPrices: draft.horaryPrices.filter(horaryPrices => horaryPrices.id !== action.payload.data) 
               }; 
      }case '@horaryPrice/HORARY_PRICE_INITIAL_VALUES': {
        return { ...state, horaryPrice: INITIAL_STATE.horaryPrice };  
      }
      default:
        return { ...state };
    }
  });
}