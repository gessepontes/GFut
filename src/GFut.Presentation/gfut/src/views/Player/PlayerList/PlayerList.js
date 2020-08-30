import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { makeStyles } from '@material-ui/styles';

import {  PlayersTable } from './components';
import { BottomRightFAB } from 'components';

import { fetchPlayerRequest, playerInitialValues
} from '~/store/modules/player/actions';

const useStyles = makeStyles(theme => ({
  root: {
    padding: theme.spacing(3)
  },
  content: {
    marginTop: theme.spacing(2)
  }
}));

const PlayerList = () => {
  const classes = useStyles();
  const teamId = useSelector(state => state.user.profile.team.id);
  const dispatch = useDispatch();

  const handleClick = () => {
    dispatch(playerInitialValues());
  };

  useEffect(() => {
    const fetchData = async () => {
      dispatch(fetchPlayerRequest(teamId));
    }

    fetchData();

  });

  return (
<>
    <div className={classes.root}>
        <BottomRightFAB size='small' color='primary' onClick={() => handleClick()} />
      <div className={classes.content}>
           <PlayersTable />
      </div>
    </div>
    </>
  );
};

export default PlayerList;
