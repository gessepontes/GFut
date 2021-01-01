import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';

import { makeStyles } from '@material-ui/styles';
import { format } from 'date-fns';

import { BottomRightFAB } from 'components';

import { SchedulingTable } from './components';

import { fetchSchedulingByIdFieldRequest, schedulingInitialValues,
  schedulingBack
} from '~/store/modules/scheduling/actions';

import { fetchFieldItemByIdFieldRequest
} from '~/store/modules/fieldItem/actions';

import { fetchPersonRequest
} from '~/store/modules/person/actions';

import { fetchHoraryFieldByTypeIdFieldItemRequest
} from '~/store/modules/horaryField/actions';

const useStyles = makeStyles(theme => ({
  root: {
    padding: theme.spacing(3)
  },
  content: {
    marginTop: theme.spacing(2)
  }
}));

const SchedulingList = () => {
  const classes = useStyles();
  const dispatch = useDispatch();

  useEffect(() => {
    const fetchData = async () => {
      let data = {
        type: 1,
        fieldItem: 0,
        date: format(new Date(),"yyyy-MM-dd"),
        horaryId: 0,
      }

      dispatch(fetchFieldItemByIdFieldRequest(field.id));
      dispatch(fetchSchedulingByIdFieldRequest(field.id));    
      dispatch(fetchPersonRequest()); 
      dispatch(fetchHoraryFieldByTypeIdFieldItemRequest(data));  
    }

    fetchData();
  });

  const field = useSelector(state => state.field.field);

  const handleClick = () => {
    dispatch(schedulingInitialValues());
  };

  const handleClickBack = () => {
    dispatch(schedulingBack());
  };

  return (
    <div className={classes.root}>
        <BottomRightFAB size='small' color='primary' back='false' onClick={() => handleClick()} />
        <BottomRightFAB size='small' color='secondary' back='true' onClick={() => handleClickBack()} />
       <div className={classes.content}>
        <SchedulingTable />
      </div>
    </div>
  );
};

export default SchedulingList;
