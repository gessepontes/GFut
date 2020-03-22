import React from 'react';
import PropTypes from 'prop-types';
import clsx from 'clsx';
import { makeStyles } from '@material-ui/styles';
import {
  Card,
  CardContent,
  CardActions,
  Typography,
  Grid,
  Divider
} from '@material-ui/core';

import TodayIcon from '@material-ui/icons/Today';
import PhoneIcon from '@material-ui/icons/Phone';

const useStyles = makeStyles(theme => ({
  root: {},
  imageContainer: {
    height: 64,
    width: 64,
    margin: '0 auto',
    border: `1px solid ${theme.palette.divider}`,
    borderRadius: '50px',
    overflow: 'hidden',
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'center'
  },
  image: {
    width: '100%',
    height: '100%'
  },
  statsItem: {
    display: 'flex',
    alignItems: 'center'
  },
  statsIcon: {
    color: theme.palette.icon,
    marginRight: theme.spacing(1)
  }
}));

const PlayerCard = props => {
  const { className, player, ...rest } = props;

  const classes = useStyles();

  return (
    <Card
      {...rest}
      className={clsx(classes.root, className)}
    >
      <CardContent>
        <div className={classes.imageContainer}>
          <img
            alt="player"
            className={classes.image}
            src={`http://localhost:51933/picture/player/${player.picture}`}  
          />
        </div>
        <Typography
          align="center"
          gutterBottom
          variant="h4"
        >
          {player.name}
        </Typography>
        <Typography
          align="center"
          variant="body1"
        >
          {player.position}
        </Typography>
      </CardContent>
      <Divider />
      <CardActions>
        <Grid
          container
          justify="space-between"
        >
          <Grid
            className={classes.statsItem}
            item
          >
            <TodayIcon className={classes.statsIcon} />
            <Typography
              display="inline"
              variant="body2"
            >
              {player.birthDate}
            </Typography>
          </Grid>
          <Grid
            className={classes.statsItem}
            item
          >
            <PhoneIcon className={classes.statsIcon} />
            <Typography
              display="inline"
              variant="body2"
            >
              {player.phone}
            </Typography>
          </Grid>
        </Grid>
      </CardActions>
    </Card>
  );
};

PlayerCard.propTypes = {
  className: PropTypes.string,
  player: PropTypes.object.isRequired
};

export default PlayerCard;
