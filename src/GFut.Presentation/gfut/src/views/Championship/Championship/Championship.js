import React from 'react';

import { makeStyles } from '@material-ui/styles';
import { Grid } from '@material-ui/core';

import { ChampionshipProfile, ChampionshipDetails } from './components';

const useStyles = makeStyles(theme => ({
  root: {
    padding: theme.spacing(4)
  }
}));

const Championship = () => {
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
          <ChampionshipProfile />
        </Grid>
        <Grid
          item
          lg={8}
          md={6}
          xl={8}
          xs={12}
        >
          <ChampionshipDetails />
        </Grid>
      </Grid>
    </div>
  );
};

export default Championship;
