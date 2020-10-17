import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';

import { makeStyles } from '@material-ui/styles';

import { MatchChampionshipTable } from './components';
import { BottomRightFAB } from 'components';

import { fetchSubscriptionByChampionshipIdRequest
} from '~/store/modules/subscription/actions';

import { fetchMatchChampionshipRequest, matchChampionshipInitialValues,
  matchChampionshipBack
} from '~/store/modules/matchChampionship/actions';

import { fetchChampionshipRequest
} from '~/store/modules/championship/actions';

import { fetchFieldRequest
} from '~/store/modules/field/actions';

const useStyles = makeStyles(theme => ({
  root: {
    padding: theme.spacing(3)
  },
  content: {
    marginTop: theme.spacing(2)
  }
}));

const MatchChampionshipList = () => {
  const classes = useStyles();
  const dispatch = useDispatch();

  useEffect(() => {
    const fetchData = async () => {
      dispatch(fetchSubscriptionByChampionshipIdRequest(championship.id));
      dispatch(fetchMatchChampionshipRequest(championship.id));
      dispatch(fetchChampionshipRequest());
      dispatch(fetchFieldRequest());
    }

    fetchData();
  });

  const championship = useSelector(state => state.championship.championship);

  const handleClick = () => {
    dispatch(matchChampionshipInitialValues());
  };

  const handleClickBack = () => {
    dispatch(matchChampionshipBack());
  };

  return (
    <div className={classes.root}>
      <BottomRightFAB size='small' color='primary' back='false' onClick={() => handleClick()} />
      <BottomRightFAB size='small' color='secondary' back='true' onClick={() => handleClickBack()} />
      <div className={classes.content}>
        <MatchChampionshipTable />
      </div>
    </div>
  );
};

export default MatchChampionshipList;
