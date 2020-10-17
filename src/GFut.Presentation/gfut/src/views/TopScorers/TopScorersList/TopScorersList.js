import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';

import { makeStyles } from '@material-ui/styles';

import { TopScorersListTable } from './components';
import { BottomRightFAB } from 'components';

import { fetchTopScorersRequest, topScorersBack
} from '~/store/modules/topScorers/actions';

const useStyles = makeStyles(theme => ({
  root: {
    padding: theme.spacing(3)
  },
  content: {
    marginTop: theme.spacing(2)
  }
}));

const TopScorersList = () => {
  const classes = useStyles();
  const dispatch = useDispatch();

  useEffect(() => {
    const fetchData = async () => {
      dispatch(fetchTopScorersRequest(championship.id));
    }

    fetchData();
  });

  const championship = useSelector(state => state.championship.championship);

  const handleClickBack = () => {
    dispatch(topScorersBack());
  };

  return (
    <div className={classes.root}>
      <BottomRightFAB size='small' color='secondary' back='true' onClick={() => handleClickBack()} />
      <div className={classes.content}>
        <TopScorersListTable />
      </div>
    </div>
  );
};

export default TopScorersList;
