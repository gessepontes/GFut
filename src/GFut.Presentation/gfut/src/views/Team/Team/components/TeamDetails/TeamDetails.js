import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import clsx from 'clsx';
import PropTypes from 'prop-types';
import { Form, Input } from '@rocketseat/unform';

import { makeStyles } from '@material-ui/styles';

import { MTextField } from '~/components';

import {
  Card,
  CardHeader,
  CardContent,
  CardActions,
  Divider,
  Grid,
  Button
} from '@material-ui/core';

import history from '~/services/history';

import { saveTeamRequest
} from '~/store/modules/team/actions';

const useStyles = makeStyles(() => ({
  root: {}
}));

const TeamDetails = props => {
  const dispatch = useDispatch();

  const { className, ...rest } = props;

  const classes = useStyles();

  const handleBack = () => {
    history.push('/teams');
  };

  function handleSubmit(data) {
    data.personId = profile.id; 
    dispatch(saveTeamRequest(data));
  }

  const profile = useSelector(state => state.user.profile);
  const team = useSelector(state => state.team.team);

  const states = [
    {
      value: '1',
      label: 'Society'
    },
    {
      value: '2',
      label: '11'
    }
  ];

  return (
    <Card
      {...rest}
      className={clsx(classes.root, className)}
    >
      <Form initialData={team} onSubmit={handleSubmit}>
        <CardHeader
          subheader="Informações sobre o time"
          title="Time"
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
              <Input name="id" type='hidden' />
              <Input name="registerDate" type='hidden' />
              <Input name="symbol" type='hidden' />
              <Input name="state" type='hidden' />
              <Input name="active" type='hidden' />
              <Input name="personId" type='hidden' />

              <MTextField required name="name" label="Nome"/>
            </Grid>
            <Grid
              item
              md={6}
              xs={12}
            >             
              <MTextField required name="observation" label="Observação"/>
            </Grid>
            <Grid
              item
              md={6}
              xs={12}
            >
              <MTextField name="type" label="Tipo"
                required                              
                select
                SelectProps={{ native: true }}
              >
                {states.map(option => (
                  <option
                    key={option.value}
                    value={option.value}
                  >
                    {option.label}
                  </option>
                ))}
              </MTextField>
            </Grid>
            <Grid
              item
              md={6}
              xs={12}
            >
              <MTextField name="fundationDate" type='date' label="Data de Fundação"
                required                              
                InputLabelProps={{
                  shrink: true,
                }}
              />
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
            Salvar
          </Button>

          <Button variant="contained"  onClick ={handleBack}>Voltar</Button>
        </CardActions>
        </Form>
    </Card>
  );
};

TeamDetails.propTypes = {
  className: PropTypes.string
};

export default TeamDetails;
