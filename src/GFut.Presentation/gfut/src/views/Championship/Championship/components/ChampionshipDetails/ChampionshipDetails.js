import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import clsx from 'clsx';
import PropTypes from 'prop-types';

import { makeStyles } from '@material-ui/styles';

import { championshipType, championshipTypeTeam } from '~/data';

import { Input, MCheckbox } from '~/components';
import { Form } from '@unform/web';

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

import { saveChampionshipRequest
} from '~/store/modules/championship/actions';

const useStyles = makeStyles(() => ({
  root: {}
}));

const ChampionshipDetails = props => {
  const dispatch = useDispatch();

  const { className, ...rest } = props;

  const classes = useStyles();

  const handleBack = () => {
    history.push('/championships');
  };

  function handleSubmit(data) {
    data.id = championship.id; 
    data.picture = championship.picture; 
    data.championshipId = championship.championshipId;
    data.active = championship.active; 
    data.registerDate = championship.registerDate; 
    dispatch(saveChampionshipRequest(data));
  }

  const fields = useSelector(state => state.field.fields);
  const championship = useSelector(state => state.championship.championship);
  const people = useSelector(state => state.person.people);

  return (
    <Card
      {...rest}
      className={clsx(classes.root, className)}
    >
      <Form initialData={championship} onSubmit={handleSubmit}>
        <CardHeader
          subheader="Informações sobre o campeonato"
          title="Campeonato"
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
               <Input name="fieldId" label="Campo"
                required                              
                select
                SelectProps={{ native: true }}
              >
                <option>
                  </option>
                {fields.map(option => (
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
              md={12}
              xs={12}
            >
              <Input required name="name" label="Nome"/>
            </Grid>
            <Grid
              item
              md={6}
              xs={12}
            >             
              <Input name="championshipType" label="Tipo de campeonato"
                required                              
                select
                SelectProps={{ native: true }}
              >
                {championshipType.map(option => (
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
              <Input name="refereeType" label="Regra de arbitragem"
                required                              
                select
                SelectProps={{ native: true }}
              >
                {championshipTypeTeam.map(option => (
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
              md={4}
              xs={12}
            >
             <Input name="startDate" type='date' label="Data inicio"
                required                              
                InputLabelProps={{
                  shrink: true,
                }}
              />
            </Grid>  
            <Grid
              item
              md={4}
              xs={12}
            >
             <Input name="endDate" type='date' label="Data fim"
                required                              
                InputLabelProps={{
                  shrink: true,
                }}
              />
            </Grid> 
            <Grid
              item
              md={4}
              xs={12}
            >
              <Input type="number" required name="amountTeam" label="Quantidade de times"/>
            </Grid>
            <Grid
              item
              md={4}
              xs={12}
            >
              <MCheckbox name="releaseSubscription" label="Inscrição"/>
            </Grid> 
            <Grid
              item
              md={4}
              xs={12}
            >
              <MCheckbox name="goBack" label="Ida e volta"/>
            </Grid> 
            <Grid
              item
              md={4}
              xs={12}
            >
              <MCheckbox name="playerRegistration" label="Disponível para inscrição de jogadores"/>
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

ChampionshipDetails.propTypes = {
  className: PropTypes.string
};

export default ChampionshipDetails;
