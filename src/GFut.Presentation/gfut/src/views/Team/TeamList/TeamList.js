import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';

import { makeStyles } from '@material-ui/styles';

import { TeamsTable } from './components';
import { BottomRightFAB } from 'components';

import { teamInitialValues } 
from '~/store/modules/team/actions';

import { fetchTeamRequest
} from '~/store/modules/team/actions';

import { fetchPersonRequest
} from '~/store/modules/person/actions';

const useStyles = makeStyles(theme => ({
  root: {
    padding: theme.spacing(3)
  },
  content: {
    marginTop: theme.spacing(2)
  }
}));

const TeamList = () => {
  const classes = useStyles();
  const dispatch = useDispatch();

  const handleClick = () => {
    dispatch(teamInitialValues());
  };

  const profile = useSelector(state => state.user.profile);

  useEffect(() => {
    const fetchData = async () => {
      dispatch(fetchTeamRequest(profile.id));
      dispatch(fetchPersonRequest());
    }

    fetchData();
  });

  return (
    <div className={classes.root}>
        <BottomRightFAB size='small' color='primary' onClick={() => handleClick()} />
      <div className={classes.content}>
        <TeamsTable />
      </div>
    </div>
  );
};

export default TeamList;
