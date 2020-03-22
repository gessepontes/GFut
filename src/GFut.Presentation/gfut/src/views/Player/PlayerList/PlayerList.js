import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { makeStyles } from '@material-ui/styles';

import { PlayerToolbar, PlayersCard } from './components';

import { fetchPlayerRequest
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

  useEffect(() => {
    const fetchData = async () => {
      dispatch(fetchPlayerRequest(teamId));
    }

    fetchData();

  });

  return (
<>
    <div className={classes.root}>
      <PlayerToolbar />
      <div className={classes.content}>
           <PlayersCard />
      </div>
    </div>
    </>
  );
};

export default PlayerList;
