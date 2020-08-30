import React, { useEffect } from 'react';
import { useDispatch } from 'react-redux';

import { makeStyles } from '@material-ui/styles';

import { BottomRightFAB } from 'components';

import { SchedulingTable } from './components';

import { fetchSchedulingRequest, schedulingInitialValues
} from '~/store/modules/scheduling/actions';

import { fetchFieldItemRequest
} from '~/store/modules/fieldItem/actions';

import { fetchPersonRequest
} from '~/store/modules/person/actions';

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
      dispatch(fetchFieldItemRequest());
      dispatch(fetchPersonRequest());  
      dispatch(fetchSchedulingRequest());    
    }

    fetchData();
  });

  const handleClick = () => {
    dispatch(schedulingInitialValues());
  };

  return (
    <div className={classes.root}>
         <BottomRightFAB size='small' color='primary' onClick={() => handleClick()} />
       <div className={classes.content}>
        <SchedulingTable />
      </div>
    </div>
  );
};

export default SchedulingList;
