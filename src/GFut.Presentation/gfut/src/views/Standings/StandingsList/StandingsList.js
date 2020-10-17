import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';

import { makeStyles } from '@material-ui/styles';

import { StandingsListTable } from './components';
import { BottomRightFAB } from 'components';

import { fetchStandingsRequest, standingsBack
} from '~/store/modules/standings/actions';

const useStyles = makeStyles(theme => ({
  root: {
    padding: theme.spacing(3)
  },
  content: {
    marginTop: theme.spacing(2)
  }
}));

const StandingsList = () => {
  const classes = useStyles();
  const dispatch = useDispatch();

  useEffect(() => {
    const fetchData = async () => {
      dispatch(fetchStandingsRequest(championship.id));
    }

    fetchData();
  });

  const championship = useSelector(state => state.championship.championship);

  const handleClickBack = () => {
    dispatch(standingsBack());
  };

  return (
    <div className={classes.root}>
      <BottomRightFAB size='small' color='secondary' back='true' onClick={() => handleClickBack()} />
      <div className={classes.content}>
        <StandingsListTable />
      </div>
    </div>
  );
};

export default StandingsList;
