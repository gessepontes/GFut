import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import clsx from 'clsx';
import PropTypes from 'prop-types';

import { makeStyles } from '@material-ui/styles';

import { Input, InputMaskPhone } from '~/components';

import { Form } from '@unform/web';

import { horaryType, schedulingType } from '~/data';

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

import { saveSchedulingRequest
} from '~/store/modules/scheduling/actions';

const useStyles = makeStyles(() => ({
  root: {}
}));

const SchedulingDetails = props => {
  const dispatch = useDispatch();

  const { className, ...rest } = props;

  const classes = useStyles();

  const handleBack = () => {
    history.push('/schedulings');
  };

  function handleSubmit(data) {
    data.id = scheduling.id; 
    data.horary = scheduling.horary; 
    data.active = scheduling.active; 
    data.registerDate = scheduling.registerDate;
    dispatch(saveSchedulingRequest(data));
  }

  const fieldItens = useSelector(state => state.fieldItem.fieldItens);
  const people = useSelector(state => state.person.people);
  const scheduling = useSelector(state => state.scheduling.scheduling);

  return (
    <Card
      {...rest}
      className={clsx(classes.root, className)}
    >
      <Form initialData={scheduling} onSubmit={handleSubmit}>
        <CardHeader
          subheader="Informações sobre o agendamento"
          title="Agendamento"
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
            </Grid>
            <Grid
              item
              md={6}
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
              md={6}
              xs={12}
            >
              <Input name="personId" label="Cliente"                             
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
              md={3}
              xs={12}
            >
              <Input name="date" type='date' label="Data de partida"
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
              <Input name="horaryType" label="Tipo do horário"
                required                              
                select
                SelectProps={{ native: true }}
              >
                {horaryType.map(option => (
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
              md={3}
              xs={12}
            >
              <Input name="schedulingType" label="Tipo Agendamento"
                required                              
                select
                SelectProps={{ native: true }}
              >
                {schedulingType.map(option => (
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
              md={3}
              xs={12}
            >
              <Input name="horaryId" label="Horário"
                required                              
                select
                SelectProps={{ native: true }}
              >
                {schedulingType.map(option => (
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
              <Input name="customerNotRegistered" label="Cliente não cadastrado"/>
            </Grid>
            <Grid
              item
              md={6}
              xs={12}
            >             
              <InputMaskPhone name="phone" label="Celular"/>
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

SchedulingDetails.propTypes = {
  className: PropTypes.string
};

export default SchedulingDetails;
