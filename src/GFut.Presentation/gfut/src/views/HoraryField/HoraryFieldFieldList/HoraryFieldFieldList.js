import React, { useEffect } from 'react';
import { useDispatch } from 'react-redux';

import { makeStyles } from '@material-ui/styles';

import { FieldComponents } from 'components';

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

const HoraryFieldFieldList = () => {
  const classes = useStyles();

  const dispatch = useDispatch();

  useEffect(() => {
    const fetchData = async () => {
      dispatch(fetchFieldRequest());
    }

    fetchData();
  });

  return (
    <div className={classes.root}>
      <FieldComponents titleField='Horários' 
        url='horaryFields' />
    </div>
  );
};

export default HoraryFieldFieldList;
