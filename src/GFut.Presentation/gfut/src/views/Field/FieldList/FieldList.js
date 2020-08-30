import React, { useEffect } from 'react';
import { useDispatch } from 'react-redux';

import { makeStyles } from '@material-ui/styles';

import { FieldTable } from './components';
import { BottomRightFAB } from 'components';

import { fetchFieldRequest, fieldInitialValues
} from '~/store/modules/field/actions';

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

const FieldList = () => {
  const classes = useStyles();
  const dispatch = useDispatch();

  useEffect(() => {
    const fetchData = async () => {
      dispatch(fetchFieldRequest());
      dispatch(fetchPersonRequest());
    }

    fetchData();
  });

  const handleClick = () => {
    dispatch(fieldInitialValues());
  };

  return (
    <div className={classes.root}>
      <BottomRightFAB size='small' color='primary' onClick={() => handleClick()} />
      <div className={classes.content}>
        <FieldTable />
      </div>
    </div>
  );
};

export default FieldList;
