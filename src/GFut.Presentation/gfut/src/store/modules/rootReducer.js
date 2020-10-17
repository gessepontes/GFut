import { combineReducers } from 'redux';

import auth from './auth/reducer';
import user from './user/reducer';
import player from './player/reducer';
import team from './team/reducer';
import field from './field/reducer';
import fieldItem from './fieldItem/reducer';
import horaryPrice from './horaryPrice/reducer';
import horaryField from './horaryField/reducer';
import horaryExtraField from './horaryExtraField/reducer';
import person from './person/reducer';
import scheduling from './scheduling/reducer';
import championship from './championship/reducer';
import subscription from './subscription/reducer';
import playerRegistration from './playerRegistration/reducer';
import groupChampionship from './groupChampionship/reducer';
import matchChampionship from './matchChampionship/reducer';
import standings from './standings/reducer';
import topScorers from './topScorers/reducer';
import suspendedPlayers from './suspendedPlayers/reducer';

export default combineReducers({
  auth,
  user,
  player,
  team,
  field,
  fieldItem,
  horaryPrice,
  horaryField,
  horaryExtraField,
  person,
  scheduling,
  championship,
  subscription,
  playerRegistration,
  groupChampionship,
  matchChampionship,
  standings,
  topScorers,
  suspendedPlayers
});