import { combineReducers } from 'redux';

import auth from './auth/reducer';
import user from './user/reducer';
import player from './player/reducer';
import team from './team/reducer';

export default combineReducers({
  auth,
  user,
  player,
  team
});