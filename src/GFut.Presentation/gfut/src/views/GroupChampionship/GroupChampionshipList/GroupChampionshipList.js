import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';

import { makeStyles } from '@material-ui/styles';

import { GroupChampionshipTable } from './components';
import { BottomRightFAB } from 'components';

import { fetchSubscriptionByChampionshipIdRequest
} from '~/store/modules/subscription/actions';

import { fetchGroupChampionshipRequest, groupChampionshipInitialValues,
  groupChampionshipBack
} from '~/store/modules/groupChampionship/actions';

const useStyles = makeStyles(theme => ({
  root: {
    padding: theme.spacing(3)
  },
  content: {
    marginTop: theme.spacing(2)
  }
}));

const GroupChampionshipList = () => {
  const classes = useStyles();
  const dispatch = useDispatch();

  useEffect(() => {
    const fetchData = async () => {
      dispatch(fetchSubscriptionByChampionshipIdRequest(championship.id));
      dispatch(fetchGroupChampionshipRequest(championship.id));
    }

    fetchData();
  });

  const championship = useSelector(state => state.championship.championship);

  const handleClick = () => {
    dispatch(groupChampionshipInitialValues());
  };

  const handleClickBack = () => {
    dispatch(groupChampionshipBack());
  };

  return (
    <div className={classes.root}>
      <BottomRightFAB size='small' color='primary' back='false' onClick={() => handleClick()} />
      <BottomRightFAB size='small' color='secondary' back='true' onClick={() => handleClickBack()} />
      <div className={classes.content}>
        <GroupChampionshipTable />
      </div>
    </div>
  );
};

export default GroupChampionshipList;
