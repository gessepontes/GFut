import produce from 'immer';

const INITIAL_STATE = {
  standings: []
};

export default function standings(state = INITIAL_STATE, action) {
  return produce(state, draft => {
    switch (action.type) {
      case '@standings/FETCH_STANDINGS_SUCCESS': {
        return { 
          ...state, standings: action.payload.data
         };
      }
      default:
        return { ...state };
    }
  });
}