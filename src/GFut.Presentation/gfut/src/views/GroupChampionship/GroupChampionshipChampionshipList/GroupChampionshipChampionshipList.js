import React, { useEffect } from 'react';
import { useDispatch } from 'react-redux';

import { makeStyles } from '@material-ui/styles';

import { ChampionshipComponents } from 'components';

import { fetchGroupChampionshipRequest
} from '~/store/modules/championship/actions';

const useStyles = makeStyles(theme => ({
  root: {
    padding: theme.spacing(3)
  },
  content: {
    marginTop: theme.spacing(2)
  }
}));

const GroupChampionshipChampionshipList = () => {
  const classes = useStyles();

  const dispatch = useDispatch();

  useEffect(() => {
    const fetchData = async () => {
      dispatch(fetchGroupChampionshipRequest());
    }

    fetchData();
  });

  return (
    <div className={classes.root}>
      <ChampionshipComponents titleChampionship='Grupos do campeonato' 
        url='groupChampionships' />
    </div>
  );
};

export default GroupChampionshipChampionshipList;
