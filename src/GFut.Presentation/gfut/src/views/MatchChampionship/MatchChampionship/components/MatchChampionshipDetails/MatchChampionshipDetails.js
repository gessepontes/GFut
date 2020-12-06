import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import clsx from 'clsx';
import PropTypes from 'prop-types';

import { makeStyles } from '@material-ui/styles';

import { Input, MCheckbox } from '~/components';
import { Form } from '@unform/web';

import { round } from '~/data';

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

import { saveMatchChampionshipRequest
} from '~/store/modules/matchChampionship/actions';

import { fetchFieldItemByIdFieldRequest
} from '~/store/modules/fieldItem/actions';

const useStyles = makeStyles(() => ({
  root: {}
}));

const MatchChampionshipDetails = props => {
  const dispatch = useDispatch();

  const { className, ...rest } = props;

  const classes = useStyles();

  const handleBack = () => {
    history.push('/matchChampionships');
  };

  function handleSubmit(data) {
    data.id = matchChampionship.id;
    data.active = matchChampionship.active; 
    data.registerDate = matchChampionship.registerDate; 
    dispatch(saveMatchChampionshipRequest(data));
  }

  const championship = useSelector(state => state.championship.championship);
  const matchChampionship = useSelector(state => state.matchChampionship.matchChampionship);
  const subscriptions = useSelector(state => state.subscription.subscriptions); 
  const fields = useSelector(state => state.field.fields);
  const fieldItens = useSelector(state => state.fieldItem.fieldItens);

  const handleChange = (e) => {
    dispatch(fetchFieldItemByIdFieldRequest(e.target.value));
  }

  return (
    <Card
      {...rest}
      className={clsx(classes.root, className)}
    >
      <Form initialData={matchChampionship} onSubmit={handleSubmit}>
        <CardHeader
          subheader="Informações sobre a partida"
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
              md={12}
              xs={12}
            >
              <Input name="ChampionshipName" disabled defaultValue={championship.name} label="Campeonato"/>
            </Grid>

            <Grid
              item
              md={3}
              xs={12}
            >
               <Input name="homeSubscriptionId" label="Time 1" 
                required                              
                select
                SelectProps={{ native: true }}
              >
                <option>
                  </option>
                {subscriptions.map(option => (
                  <option
                    key={option.id}
                    value={option.id}
                  >
                    {option.team.name}
                  </option>
                ))}
              </Input>
            </Grid>  
            <Grid
              item
              md={3}
              xs={12}
            >
              <Input name="homePoints" type='number' label="Gol 1"
                required/>
            </Grid>
            <Grid
              item
              md={3}
              xs={12}
            >
               <Input name="guestSubscriptionId" label="Time2" 
                required                              
                select
                SelectProps={{ native: true }}
              >
                <option>
                  </option>
                {subscriptions.map(option => (
                  <option
                    key={option.id}
                    value={option.id}
                  >
                    {option.team.name}
                  </option>
                ))}
              </Input>
            </Grid>  
            <Grid
              item
              md={3}
              xs={12}
            >
              <Input name="guestPoints" type='number' label="Gol 2"
                required/>
            </Grid>
            <Grid
              item
              md={3}
              xs={12}
            >
               <Input name="fieldId" label="Local" 
                onChange={e => handleChange(e)}
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
              md={3}
              xs={12}
            >
               <Input name="fieldItemId" label="Campo" 
                required                              
                select
                SelectProps={{ native: true }}
              >
                <option>
                  </option>
                {fieldItens.map(option => (
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
              md={3}
              xs={12}
            >
              <Input name="matchDate" type='date' label="Data da Partida"
                required                              
                InputLabelProps={{
                  shrink: true,
                }}
              />
            </Grid>

            <Grid
              item
              md={3}
              xs={12}
            >
              <Input name="startTime" type='time' label="Hora da Partida"
                required                              
                InputLabelProps={{
                  shrink: true,
                }}
              />
            </Grid>
            <Grid
              item
              md={3}
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
            <Grid
              item
              md={4}
              xs={12}
            >
              <MCheckbox name="calculate" label="Liberar para classificação"/>
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

MatchChampionshipDetails.propTypes = {
  className: PropTypes.string
};

export default MatchChampionshipDetails;
