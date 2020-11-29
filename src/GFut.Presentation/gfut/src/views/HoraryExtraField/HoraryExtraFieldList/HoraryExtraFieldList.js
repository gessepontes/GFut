import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';

import { makeStyles } from '@material-ui/styles';

import { HoraryExtraFieldTable } from './components';

import { BottomRightFAB } from 'components';

import { fetchHoraryExtraFieldByIdFieldRequest, horaryExtraFieldInitialValues,
  horaryExtraFieldBack
} from '~/store/modules/horaryExtraField/actions';

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

const HoraryExtraFieldList = () => {
  const classes = useStyles();
  const dispatch = useDispatch();

  useEffect(() => {
    const fetchData = async () => {
      dispatch(fetchHoraryExtraFieldByIdFieldRequest(field.id));
      dispatch(fetchFieldItemByIdFieldRequest(field.id));
    }

    fetchData();
  });

  const field = useSelector(state => state.field.field);

  const handleClick = () => {
    dispatch(horaryExtraFieldInitialValues());
  };

  const handleClickBack = () => {
    dispatch(horaryExtraFieldBack());
  };

  return (
    <div className={classes.root}>
        <BottomRightFAB size='small' color='primary' back='false' onClick={() => handleClick()} />
        <BottomRightFAB size='small' color='secondary' back='true' onClick={() => handleClickBack()} />
      <div className={classes.content}>
        <HoraryExtraFieldTable />
      </div>
    </div>
  );
};

export default HoraryExtraFieldList;
