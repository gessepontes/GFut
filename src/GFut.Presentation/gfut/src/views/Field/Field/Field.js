import React from 'react';

import { makeStyles } from '@material-ui/styles';
import { Grid } from '@material-ui/core';

import { FieldProfile, FieldDetails } from './components';

const useStyles = makeStyles(theme => ({
  root: {
    padding: theme.spacing(4)
  }
}));

const Field = () => {
  const classes = useStyles();

  return (
    <div className={classes.root}>
      <Grid
        container
        spacing={4}
      >
        <Grid
          item
          lg={4}
          md={6}
          xl={4}
          xs={12}
        >
          <FieldProfile />
        </Grid>
        <Grid
          item
          lg={8}
          md={6}
          xl={8}
          xs={12}
        >
          <FieldDetails />
        </Grid>
      </Grid>
    </div>
  );
};

export default Field;
