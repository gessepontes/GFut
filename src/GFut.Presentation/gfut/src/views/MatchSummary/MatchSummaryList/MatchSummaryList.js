import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';

import { makeStyles } from '@material-ui/styles';

import { MatchSummaryTable } from './components';
import { BottomRightFAB } from 'components';

import { fetchSubscriptionByChampionshipIdRequest
} from '~/store/modules/subscription/actions';

import { fetchMatchSummaryRequest, matchSummaryInitialValues,
  matchSummaryBack
} from '~/store/modules/matchSummary/actions';

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

const MatchSummaryList = () => {
  const classes = useStyles();
  const dispatch = useDispatch();

  useEffect(() => {
    const fetchData = async () => {
      dispatch(fetchSubscriptionByChampionshipIdRequest(championship.id));
      dispatch(fetchMatchSummaryRequest(championship.id));
      dispatch(fetchChampionshipRequest());
      dispatch(fetchFieldRequest());
    }

    fetchData();
  });

  const championship = useSelector(state => state.championship.championship);

  const handleClick = () => {
    dispatch(matchSummaryInitialValues());
  };

  const handleClickBack = () => {
    dispatch(matchSummaryBack());
  };

  return (
    <div className={classes.root}>
      <BottomRightFAB size='small' color='primary' back='false' onClick={() => handleClick()} />
      <BottomRightFAB size='small' color='secondary' back='true' onClick={() => handleClickBack()} />
      <div className={classes.content}>
        <MatchSummaryTable />
      </div>
    </div>
  );
};

export default MatchSummaryList;
