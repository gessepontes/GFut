import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';

import { makeStyles } from '@material-ui/styles';

import { SubscriptionTable } from './components';
import { BottomRightFAB } from 'components';

import { fetchSubscriptionRequest, subscriptionInitialValues, subscriptionBack
} from '~/store/modules/subscription/actions';

import { fetchChampionshipRequest
} from '~/store/modules/championship/actions';

import { fetchTeamAllRequest
} from '~/store/modules/team/actions';

const useStyles = makeStyles(theme => ({
  root: {
    padding: theme.spacing(3)
  },
  content: {
    marginTop: theme.spacing(2)
  }
}));

const SubscriptionList = () => {
  const classes = useStyles();
  const dispatch = useDispatch();

  useEffect(() => {
    const fetchData = async () => {
      dispatch(fetchSubscriptionRequest(championship.id));
      dispatch(fetchChampionshipRequest(championship.id));
      dispatch(fetchTeamAllRequest());
    }

    fetchData();
  });

  const championship = useSelector(state => state.championship.championship);

  const handleClick = () => {
    dispatch(subscriptionInitialValues());
  };

  const handleClickBack = () => {
    dispatch(subscriptionBack());
  };

  return (
    <div className={classes.root}>
      <BottomRightFAB size='small' color='primary' back='false' onClick={() => handleClick()} />
      <BottomRightFAB size='small' color='secondary' back='true' onClick={() => handleClickBack()} />
      <div className={classes.content}>
        <SubscriptionTable />
      </div>
    </div>
  );
};

export default SubscriptionList;
