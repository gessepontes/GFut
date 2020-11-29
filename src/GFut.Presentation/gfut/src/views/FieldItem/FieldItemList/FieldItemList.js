import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';

import { makeStyles } from '@material-ui/styles';

import { FieldItemTable } from './components';

import { BottomRightFAB } from 'components';

import { fetchFieldItemByIdFieldRequest, fieldItemInitialValues,fieldItemBack
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
      dispatch(fetchFieldItemByIdFieldRequest(field.id));
      dispatch(fetchFieldRequest(field.id));
    }

    fetchData();
  });

  const field = useSelector(state => state.field.field);

  const handleClick = () => {
    dispatch(fieldItemInitialValues());
  };

  const handleClickBack = () => {
    dispatch(fieldItemBack());
  };
  return (
    <div className={classes.root}>
        <BottomRightFAB size='small' color='primary' back='false' onClick={() => handleClick()} />
        <BottomRightFAB size='small' color='secondary' back='true' onClick={() => handleClickBack()} />
      <div className={classes.content}>
        <FieldItemTable />
      </div>
    </div>
  );
};

export default FieldItemList;
