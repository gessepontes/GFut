import React, { useEffect } from 'react';
import { useDispatch } from 'react-redux';

import { makeStyles } from '@material-ui/styles';

import { HoraryExtraFieldTable } from './components';

import { BottomRightFAB } from 'components';

import { fetchHoraryExtraFieldRequest, horaryExtraFieldInitialValues
} from '~/store/modules/horaryExtraField/actions';

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

const HoraryExtraFieldList = () => {
  const classes = useStyles();
  const dispatch = useDispatch();

  useEffect(() => {
    const fetchData = async () => {
      dispatch(fetchHoraryExtraFieldRequest());
      dispatch(fetchFieldItemRequest());
    }

    fetchData();
  });

  const handleClick = () => {
    dispatch(horaryExtraFieldInitialValues());
  };

  return (
    <div className={classes.root}>
       <BottomRightFAB size='small' color='primary' onClick={() => handleClick()} />
      <div className={classes.content}>
        <HoraryExtraFieldTable />
      </div>
    </div>
  );
};

export default HoraryExtraFieldList;
