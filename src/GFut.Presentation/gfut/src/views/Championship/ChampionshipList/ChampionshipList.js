import React, { useEffect } from 'react';
import { useDispatch } from 'react-redux';

import { makeStyles } from '@material-ui/styles';

import { ChampionshipTable } from './components';
import { BottomRightFAB } from 'components';

import { fetchChampionshipRequest, championshipInitialValues
} from '~/store/modules/championship/actions';

import { fetchPersonChampionshipDropRequest
} from '~/store/modules/person/actions';

import { fetchFieldRequest
} from '~/store/modules/field/actions';

const useStyles = makeStyles(theme => ({
  root: {
    padding: theme.spacing(3)
  },
  content: {
    marginTop: theme.spacing(2)
  }
}));

const ChampionshipList = () => {
  const classes = useStyles();
  const dispatch = useDispatch();

  useEffect(() => {
    const fetchData = async () => {
      dispatch(fetchChampionshipRequest());
      dispatch(fetchPersonChampionshipDropRequest());
      dispatch(fetchFieldRequest());
    }

    fetchData();
  });

  const handleClick = () => {
    dispatch(championshipInitialValues());
  };

  return (
    <div className={classes.root}>
      <BottomRightFAB size='small' color='primary' onClick={() => handleClick()} />
      <div className={classes.content}>
        <ChampionshipTable />
      </div>
    </div>
  );
};

export default ChampionshipList;
