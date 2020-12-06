import produce from 'immer';
import { format } from 'date-fns';

const INITIAL_STATE = {
  scheduling: {
    id: 0,
    date: format(new Date(),"yyyy-MM-dd"),
    horary: '',
    horaryId: '',
    fieldItemId: 0,
    schedulingType: 0,
    horaryType: 0,
    state: 'A',
    personId: 0,
    customerNotRegistered: '',
    phone: '',
    cancelDate: new Date(),
    personCancelId: 0,
    markedApp: 0,
    active: true,
    registerDate: new Date(),
  },
  schedulings: []
};

export default function scheduling(state = INITIAL_STATE, action) {
  return produce(state, draft => {
    switch (action.type) {
      case '@scheduling/FETCH_SCHEDULING_SUCCESS': {
        return { ...state, schedulings: action.payload.data };
      }
      case '@scheduling/FETCH_SCHEDULING_ID_FIELD_SUCCESS': {
        return { ...state, schedulings: action.payload.data };
      }
      case '@scheduling/FETCH_SCHEDULING_ID_SUCCESS': {        
        return { 
          ...state, 
          scheduling: action.payload.data 
        };        
      }      
      case '@scheduling/ADD_SCHEDULING_SUCCESS': {
        return { ...state, scheduling: action.payload.data };        
      }    
      case '@scheduling/UPDATE_SCHEDULING_SUCCESS': {
        return { ...state, scheduling: action.payload.data };  
      }case '@scheduling/DELETE_SCHEDULING_SUCCESS': {              
        return { 
                  ...state, 
                  schedulings: draft.schedulings.filter(schedulings => schedulings.id !== action.payload.data) 
               }; 
      }case '@scheduling/SCHEDULING_INITIAL_VALUES': {
        return { ...state, scheduling: INITIAL_STATE.scheduling };  
      }
      default:
        return { ...state };
    }
  });
}