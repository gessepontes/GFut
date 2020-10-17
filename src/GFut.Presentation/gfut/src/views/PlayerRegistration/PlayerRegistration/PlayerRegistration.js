import React from 'react';

import { makeStyles } from '@material-ui/styles';
import { Grid } from '@material-ui/core';

import { PlayerRegistrationDetails } from './components';

const useStyles = makeStyles(theme => ({
  root: {
    padding: theme.spacing(4)
  }
}));

const PlayerRegistration = () => {
  const classes = useStyles();

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
          <PlayerRegistrationDetails />
        </Grid>
      </Grid>
    </div>
  );
};

export default PlayerRegistration;
