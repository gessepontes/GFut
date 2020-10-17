import produce from 'immer';

const INITIAL_STATE = {
  topScorers: []
};

export default function topScorers(state = INITIAL_STATE, action) {
  return produce(state, draft => {
    switch (action.type) {
      case '@topScorers/FETCH_TOP_SCORERS_SUCCESS': {
        return { 
          ...state, topScorers: action.payload.data
         };
      }
      default:
        return { ...state };
    }
  });
}