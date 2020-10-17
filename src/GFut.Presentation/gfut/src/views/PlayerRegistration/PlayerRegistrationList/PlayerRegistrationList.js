import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';

import { makeStyles } from '@material-ui/styles';

import { PlayerRegistrationTable } from './components';
import { BottomRightFAB } from 'components';

import { fetchSubscriptionByChampionshipIdRequest
} from '~/store/modules/subscription/actions';

import { fetchPlayerRegistrationRequest, playerRegistrationInitialValues,
  playerRegistrationBack
} from '~/store/modules/playerRegistration/actions';

import { fetchChampionshipRequest
} from '~/store/modules/championship/actions';

const useStyles = makeStyles(theme => ({
  root: {
    padding: theme.spacing(3)
  },
  content: {
    marginTop: theme.spacing(2)
  }
}));

const PlayerRegistrationList = () => {
  const classes = useStyles();
  const dispatch = useDispatch();

  useEffect(() => {
    const fetchData = async () => {
      dispatch(fetchSubscriptionByChampionshipIdRequest(championship.id));
      dispatch(fetchPlayerRegistrationRequest(championship.id));
      dispatch(fetchChampionshipRequest());
    }

    fetchData();
  });

  const championship = useSelector(state => state.championship.championship);

  const handleClick = () => {
    dispatch(playerRegistrationInitialValues());
  };

  const handleClickBack = () => {
    dispatch(playerRegistrationBack());
  };

  return (
    <div className={classes.root}>
      <BottomRightFAB size='small' color='primary' back='false' onClick={() => handleClick()} />
      <BottomRightFAB size='small' color='secondary' back='true' onClick={() => handleClickBack()} />
      <div className={classes.content}>
        <PlayerRegistrationTable />
      </div>
    </div>
  );
};

export default PlayerRegistrationList;
