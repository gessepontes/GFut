import React from 'react';
import { useDispatch } from 'react-redux';

import { makeStyles } from '@material-ui/styles';

import { SuspendedPlayersListTable } from './components';
import { BottomRightFAB } from 'components';

import { suspendedPlayersBack
} from '~/store/modules/suspendedPlayers/actions';

const useStyles = makeStyles(theme => ({
  root: {
    padding: theme.spacing(3)
  },
  content: {
    marginTop: theme.spacing(2)
  }
}));

const SuspendedPlayersList = () => {
  const classes = useStyles();
   const dispatch = useDispatch();

   const handleClickBack = () => {
    dispatch(suspendedPlayersBack());
  };

  return (
    <div className={classes.root}>
      <BottomRightFAB size='small' color='secondary' back='true' onClick={() => handleClickBack()} />
      <div className={classes.content}>
        <SuspendedPlayersListTable />
      </div>
    </div>
  );
};

export default SuspendedPlayersList;
