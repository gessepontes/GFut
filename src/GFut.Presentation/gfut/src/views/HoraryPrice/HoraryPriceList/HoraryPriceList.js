import React, { useEffect } from 'react';
import { useDispatch } from 'react-redux';

import { makeStyles } from '@material-ui/styles';

import { HoraryPriceTable } from './components';
import { BottomRightFAB } from 'components';

import { fetchHoraryPriceRequest, horaryPriceInitialValues
} from '~/store/modules/horaryPrice/actions';

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

const HoraryPriceList = () => {
  const classes = useStyles();
  const dispatch = useDispatch();

  const handleClick = () => {
    dispatch(horaryPriceInitialValues());
  };

  useEffect(() => {
    const fetchData = async () => {
      dispatch(fetchHoraryPriceRequest());
      dispatch(fetchFieldItemRequest());
    }

    fetchData();
  });

  return (
    <div className={classes.root}>
      <BottomRightFAB size='small' color='primary' onClick={() => handleClick()} />
      <div className={classes.content}>
        <HoraryPriceTable />
      </div>
    </div>
  );
};

export default HoraryPriceList;
