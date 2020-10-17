import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import clsx from 'clsx';
import PropTypes from 'prop-types';

import { Form } from '@unform/web';
import { Input } from '~/components';

import { makeStyles } from '@material-ui/styles';

import { championshipGroup } from '~/data';

import {
  Card,
  CardHeader,
  CardContent,
  CardActions,
  Divider,
  Grid,
  Button
} from '@material-ui/core';

import { automaticGroupRequest
} from '~/store/modules/groupChampionship/actions';

const useStyles = makeStyles(() => ({
  root: {}
}));

const AutomaticMatchDetails = props => {
  const dispatch = useDispatch();

  const { className, ...rest } = props;

  const classes = useStyles();

  function handleSubmit(data) {
    dispatch(automaticGroupRequest(data));
  }

  const championships = useSelector(state => state.championship.championships.map(o => ({...o, tableData: {}})));

  return (
    <Card
      {...rest}
      className={clsx(classes.root, className)}
    >
      <Form onSubmit={handleSubmit}>
        <CardHeader
          subheader="Geração automática de partidas"
          title="Partida"
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
              <Input name="groupId" label="Grupo"
                required                              
                select
                SelectProps={{ native: true }}
              >
                {championshipGroup.map(option => (
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
            Gerar
          </Button>
        </CardActions>
        </Form>
    </Card>
  );
};

AutomaticMatchDetails.propTypes = {
  className: PropTypes.string
};

export default AutomaticMatchDetails;
