import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';

import { makeStyles } from '@material-ui/styles';

import { HoraryPriceTable } from './components';
import { BottomRightFAB } from 'components';

import { fetchHoraryPriceByIdFieldRequest, horaryPriceInitialValues,
  horaryPriceBack
} from '~/store/modules/horaryPrice/actions';

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

const HoraryPriceList = () => {
  const classes = useStyles();
  const dispatch = useDispatch();

  const handleClick = () => {
    dispatch(horaryPriceInitialValues());
  };

  useEffect(() => {
    const fetchData = async () => {
      dispatch(fetchHoraryPriceByIdFieldRequest(field.id));
      dispatch(fetchFieldItemByIdFieldRequest(field.id));
    }

    fetchData();
  });

  const field = useSelector(state => state.field.field);

  const handleClickBack = () => {
    dispatch(horaryPriceBack());
  };

  return (
    <div className={classes.root}>
        <BottomRightFAB size='small' color='primary' back='false' onClick={() => handleClick()} />
        <BottomRightFAB size='small' color='secondary' back='true' onClick={() => handleClickBack()} />
      <div className={classes.content}>
        <HoraryPriceTable />
      </div>
    </div>
  );
};

export default HoraryPriceList;
