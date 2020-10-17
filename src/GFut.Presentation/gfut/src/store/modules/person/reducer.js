import produce from 'immer';
import { format } from 'date-fns';

const INITIAL_STATE = {
  person: {
    id: 0,
    name:'',
    cpf:'',
    rg:'',
    password: '',
    birthDate: format(new Date(),"yyyy-MM-dd"),
    picture: '',
    phone: '',
    email: '',
    active: true,
    profileType: [],
    registerDate: new Date()
  },
  people: []
};

export default function person(state = INITIAL_STATE, action) {
  return produce(state, draft => {
    switch (action.type) {
      case '@person/FETCH_PERSON_CHAMPIONSHIP_DROP_SUCCESS': {
        return { ...state, people: action.payload.data };
      }
      case '@person/FETCH_PERSON_FIELD_DROP_SUCCESS': {
        return { ...state, people: action.payload.data };
      }
      case '@person/FETCH_PERSON_ALL_DROP_SUCCESS': {
        return { ...state, people: action.payload.data };
      } 
      case '@person/FETCH_PERSON_SUCCESS': {
        return { ...state, people: action.payload.data };
      }
      case '@person/FETCH_SEARCH_PERSON_SUCCESS': {
        return { ...state, people: action.payload.data };
      }
      case '@person/FETCH_PERSON_ID_SUCCESS': {        
        return { 
          ...state, 
          person: action.payload.data 
        };        
      }      
      case '@person/ADD_PERSON_SUCCESS': {
        return { ...state, person: action.payload.data };        
      }
      case '@person/UPDATE_PICTURE_PERSON_SUCCESS': {
        draft.person.picture = action.payload.data;
        break;
      }      
      case '@person/UPDATE_PERSON_SUCCESS': {
        return { ...state, person: action.payload.data };  
      }case '@person/DELETE_PERSON_SUCCESS': {              
        return { 
                  ...state, 
                  people: draft.people.filter(people => people.id !== action.payload.data) 
               }; 
      }case '@person/PERSON_INITIAL_VALUES': {
        return { ...state, person: INITIAL_STATE.person };  
      }
      default:
        return { ...state };
    }
  });
}