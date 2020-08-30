import produce from 'immer';

const INITIAL_STATE = {
  people: []
};

export default function person(state = INITIAL_STATE, action) {
  return produce(state, draft => {
    switch (action.type) {
      case '@person/FETCH_PERSON_SUCCESS': {
        return { ...state, people: action.payload.data };
      }
      default:
    }
  });
}