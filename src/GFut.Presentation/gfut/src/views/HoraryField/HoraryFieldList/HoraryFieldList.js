import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';

import { makeStyles } from '@material-ui/styles';

import { HoraryFieldTable } from './components';
import { BottomRightFAB } from 'components';

import { fetchHoraryFieldByIdFieldRequest, horaryFieldInitialValues,
  horaryFieldBack
} from '~/store/modules/horaryField/actions';

import { fetchFieldItemByIdFieldRequest
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
      dispatch(fetchHoraryFieldByIdFieldRequest(field.id));
      dispatch(fetchFieldItemByIdFieldRequest(field.id));
    }

    fetchData();
  });

  
  const field = useSelector(state => state.field.field);

  const handleClick = () => {
    dispatch(horaryFieldInitialValues());
  };

  const handleClickBack = () => {
    dispatch(horaryFieldBack());
  };

  return (
    <div className={classes.root}>
        <BottomRightFAB size='small' color='primary' back='false' onClick={() => handleClick()} />
        <BottomRightFAB size='small' color='secondary' back='true' onClick={() => handleClickBack()} />
      <div className={classes.content}>
        <HoraryFieldTable />
      </div>
    </div>
  );
};

export default HoraryFieldList;
