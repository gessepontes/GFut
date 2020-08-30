import React, { useEffect } from 'react';
import { useDispatch } from 'react-redux';

import { makeStyles } from '@material-ui/styles';

import { HoraryFieldTable } from './components';
import { BottomRightFAB } from 'components';

import { fetchHoraryFieldRequest, horaryFieldInitialValues
} from '~/store/modules/horaryField/actions';

import { fetchFieldItemRequest
} from '~/store/modules/fieldItem/actions';

const useStyles = makeStyles(theme => ({
  root: {
    padding: theme.spacing(3)
  },
  content: {
    marginTop: theme.spacing(2)
  }
}));

const HoraryFieldList = () => {
  const classes = useStyles();
  const dispatch = useDispatch();

  useEffect(() => {
    const fetchData = async () => {
      dispatch(fetchHoraryFieldRequest());
      dispatch(fetchFieldItemRequest());
    }

    fetchData();
  });

  const handleClick = () => {
    dispatch(horaryFieldInitialValues());
  };

  return (
    <div className={classes.root}>
      <BottomRightFAB size='small' color='primary' onClick={() => handleClick()} />
      <div className={classes.content}>
        <HoraryFieldTable />
      </div>
    </div>
  );
};

export default HoraryFieldList;
