import React, { useEffect } from 'react';
import { useDispatch } from 'react-redux';

import { makeStyles } from '@material-ui/styles';

import { ChampionshipComponents } from 'components';

import { fetchChampionshipRequest
} from '~/store/modules/championship/actions';

const useStyles = makeStyles(theme => ({
  root: {
    padding: theme.spacing(3)
  },
  content: {
    marginTop: theme.spacing(2)
  }
}));

const MatchChampionshipChampionshipList = () => {
  const classes = useStyles();

  const dispatch = useDispatch();

  useEffect(() => {
    const fetchData = async () => {
      dispatch(fetchChampionshipRequest());
    }

    fetchData();
  });

  return (
    <div className={classes.root}>
      <ChampionshipComponents titleChampionship='Partidas do campeonato' 
        url='matchChampionships' />
    </div>
  );
};

export default MatchChampionshipChampionshipList;
