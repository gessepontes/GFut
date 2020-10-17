import produce from 'immer';

const INITIAL_STATE = {
  suspendedPlayers: []
};

export default function suspendedPlayers(state = INITIAL_STATE, action) {
  return produce(state, draft => {
    switch (action.type) {
      case '@suspendedPlayers/FETCH_SUSPENDED_PLAYER_SUCCESS': {
        return { 
          ...state, suspendedPlayers: action.payload.data
         };
      }
      default:
        return { ...state };
    }
  });
}