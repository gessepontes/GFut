import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import clsx from 'clsx';
import PropTypes from 'prop-types';

import { Form } from '@unform/web';
import { Input } from '~/components';

import { round } from '~/data';

import { makeStyles } from '@material-ui/styles';

import {
  Card,
  CardHeader,
  CardContent,
  CardActions,
  Divider,
  Grid,
  Button
} from '@material-ui/core';

import { fetchSuspendedPlayersRequest
} from '~/store/modules/suspendedPlayers/actions';

const useStyles = makeStyles(() => ({
  root: {}
}));

const SuspendedPlayersChampionshipDetails = props => {
  const dispatch = useDispatch();

  const { className, ...rest } = props;

  const classes = useStyles();

  function handleSubmit(data) {
    dispatch(fetchSuspendedPlayersRequest(data));
  }

  const championships = useSelector(state => state.championship.championships.map(o => ({...o, tableData: {}})));

  return (
    <Card
      {...rest}
      className={clsx(classes.root, className)}
    >
      <Form onSubmit={handleSubmit}>
        <CardHeader
          subheader="Suspensos do campeonato"
          title="Suspensos"
        />
        <Divider />
        <CardContent>
          <Grid
            container
            spacing={3}
          >
            <Grid
              item
              md={6}
              xs={12}
            >
              <Input name="championshipId" label="Campeonato"
                required                              
                select
                SelectProps={{ native: true }}
              >
                {championships.map(option => (
                  <option
                    key={option.id}
                    value={option.id}
                  >
                    {option.name}
                  </option>
                ))}
              </Input>
            </Grid> 
            <Grid
              item
              md={6}
              xs={12}
            >
              <Input name="round" label="Rodada"
                required                              
                select
                SelectProps={{ native: true }}
              >
                {round.map(option => (
                  <option
                    key={option.value}
                    value={option.value}
                  >
                    {option.label}
                  </option>
                ))}
              </Input>
            </Grid>             
          </Grid>
        </CardContent>
        <Divider />
        <CardActions>
          <Button
            color="primary"
            variant="contained"
            type="submit"
          >
            Visualizar Suspensos
          </Button>
        </CardActions>
        </Form>
    </Card>
  );
};

SuspendedPlayersChampionshipDetails.propTypes = {
  className: PropTypes.string
};

export default SuspendedPlayersChampionshipDetails;
