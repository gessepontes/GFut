import React, { useEffect } from 'react';
import { useDispatch } from 'react-redux';

import { makeStyles } from '@material-ui/styles';

import { FieldItemTable } from './components';

import { BottomRightFAB } from 'components';

import { fetchFieldItemRequest, fieldItemInitialValues
} from '~/store/modules/fieldItem/actions';

import { fetchFieldRequest
} from '~/store/modules/field/actions';

const useStyles = makeStyles(theme => ({
  root: {
    padding: theme.spacing(3)
  },
  content: {
    marginTop: theme.spacing(2)
  }
}));

const FieldItemList = () => {
  const classes = useStyles();
  const dispatch = useDispatch();

  useEffect(() => {
    const fetchData = async () => {
      dispatch(fetchFieldItemRequest());
      dispatch(fetchFieldRequest());
    }

    fetchData();
  });

  const handleClick = () => {
    dispatch(fieldItemInitialValues());
  };

  return (
    <div className={classes.root}>
       <BottomRightFAB size='small' color='primary' onClick={() => handleClick()} />
      <div className={classes.content}>
        <FieldItemTable />
      </div>
    </div>
  );
};

export default FieldItemList;
