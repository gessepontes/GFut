import React, { useEffect } from 'react';
import { useDispatch } from 'react-redux';
import { makeStyles } from '@material-ui/styles';

import {  PersonTable } from './components';
import { BottomRightFAB } from 'components';

import { fetchPersonRequest, personInitialValues
} from '~/store/modules/person/actions';

const useStyles = makeStyles(theme => ({
  root: {
    padding: theme.spacing(3)
  },
  content: {
    marginTop: theme.spacing(2)
  }
}));

const PersonList = () => {
  const classes = useStyles();
  const dispatch = useDispatch();

  const handleClick = () => {
    dispatch(personInitialValues());
  };

  useEffect(() => {
    const fetchData = async () => {
      dispatch(fetchPersonRequest());
    }

    fetchData();

  });

  return (
<>
    <div className={classes.root}>
        <BottomRightFAB size='small' color='primary' onClick={() => handleClick()} />
      <div className={classes.content}>
           <PersonTable />
      </div>
    </div>
    </>
  );
};

export default PersonList;
