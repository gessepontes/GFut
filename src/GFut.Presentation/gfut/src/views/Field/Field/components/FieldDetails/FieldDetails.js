import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import clsx from 'clsx';
import PropTypes from 'prop-types';

import { makeStyles } from '@material-ui/styles';

import { Input, MCheckbox, InputMaskPhone, NumberFormatCustom } from '~/components';
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

import { saveFieldRequest
} from '~/store/modules/field/actions';

const useStyles = makeStyles(() => ({
  root: {}
}));

const FieldDetails = props => {
  const dispatch = useDispatch();

  const { className, ...rest } = props;

  const classes = useStyles();

  const handleBack = () => {
    history.push('/fields');
  };

  function handleSubmit(data) {
    data.id = field.id; 
    data.picture = field.picture; 
    data.fieldId = field.fieldId;
    data.active = field.active; 
    data.registerDate = field.registerDate; 
    dispatch(saveFieldRequest(data));
  }

  const field = useSelector(state => state.field.field);
  const people = useSelector(state => state.person.people);

  return (
    <Card
      {...rest}
      className={clsx(classes.root, className)}
    >
      <Form initialData={field} onSubmit={handleSubmit}>
        <CardHeader
          subheader="Informações sobre o campo"
          title="Campo"
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
              <InputMaskPhone required name="phone" label="Telefone"/>
            </Grid>
            <Grid
              item
              md={12}
              xs={12}
            >             
              <Input required name="address" label="Endereço"/>
            </Grid>

            <Grid
              item
              md={6}
              xs={12}
            >
              <NumberFormatCustom required name="value" label="Valor R$"/>
            </Grid>
            <Grid
              item
              md={6}
              xs={12}
            >
              <NumberFormatCustom required name="monthlyValue" label="Valor mensal R$"/>
            </Grid>
            <Grid
              item
              md={6}
              xs={12}
            >
              <MCheckbox name="scheduled" label="Disponível para agendamento"/>
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

FieldDetails.propTypes = {
  className: PropTypes.string
};

export default FieldDetails;
