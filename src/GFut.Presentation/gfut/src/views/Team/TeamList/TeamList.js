import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';

import { makeStyles } from '@material-ui/styles';

import { TeamsToolbar, TeamsTable } from './components';

import { fetchTeamRequest
} from '~/store/modules/team/actions';

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

  const profile = useSelector(state => state.user.profile);

  useEffect(() => {
    const fetchData = async () => {
      dispatch(fetchTeamRequest(profile.id));
    }

    fetchData();
  });

  return (
    <div className={classes.root}>
      <TeamsToolbar />
      <div className={classes.content}>
        <TeamsTable />
      </div>
    </div>
  );
};

export default TeamList;
