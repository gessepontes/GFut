import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import clsx from 'clsx';
import PropTypes from 'prop-types';

import { Form } from '@unform/web';
import { Input } from '~/components';

import { tipoCampo } from '~/data';

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
    data.id = team.id; 
    data.symbol = team.symbol; 
    data.active = team.active; 
    data.state = team.state; 
    data.registerDate = team.registerDate; 

    dispatch(saveTeamRequest(data));
  }

  const team = useSelector(state => state.team.team);
  const people = useSelector(state => state.person.people);
  
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
              md={12}
              xs={12}
            >
              <Input name="personId" label="Responsável"
                required                              
                select
                SelectProps={{ native: true }}
              >
                <option>
                  </option>
                {people.map(option => (
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
              <Input required name="name" label="Nome"/>
            </Grid>
            <Grid
              item
              md={6}
              xs={12}
            >             
              <Input required name="observation" label="Observação"/>
            </Grid>
            <Grid
              item
              md={6}
              xs={12}
            >
              <Input name="type" label="Tipo"
                required                              
                select
                SelectProps={{ native: true }}
              >
                {tipoCampo.map(option => (
                  <option
                    key={option.value}
                    value={option.value}
                  >
                    {option.label}
                  </option>
                ))}
              </Input>
            </Grid>
            <Grid
              item
              md={6}
              xs={12}
            >
              <Input name="fundationDate" type='date' label="Data de Fundação"
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
