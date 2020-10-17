import React, { useEffect } from 'react';
import { useDispatch } from 'react-redux';

import { makeStyles } from '@material-ui/styles';
import { Grid } from '@material-ui/core';

import { AutomaticGroupDetails } from './components';


import { fetchGroupChampionshipRequest
} from '~/store/modules/championship/actions';

const useStyles = makeStyles(theme => ({
  root: {
    padding: theme.spacing(4)
  }
}));

const AutomaticGroup = () => {
  const classes = useStyles();

  const dispatch = useDispatch();

  useEffect(() => {
    const fetchData = async () => {
      dispatch(fetchGroupChampionshipRequest());
    }

    fetchData();
  });

  return (
    <div className={classes.root}>
      <Grid
        container
        spacing={4}
      >
        <Grid
          item
          lg={12}
          md={12}
          xl={12}
          xs={12}
        >
          <AutomaticGroupDetails />
        </Grid>
      </Grid>
    </div>
  );
};

export default AutomaticGroup;
