import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import clsx from 'clsx';
import PropTypes from 'prop-types';

import { makeStyles } from '@material-ui/styles';

import { Input, NumberFormatCustom } from '~/components';

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

import { saveHoraryPriceRequest
} from '~/store/modules/horaryPrice/actions';

const useStyles = makeStyles(() => ({
  root: {}
}));

const HoraryPriceDetails = props => {
  const dispatch = useDispatch();

  const { className, ...rest } = props;

  const classes = useStyles();

  const handleBack = () => {
    history.push('/horaryPrices');
  };

  function handleSubmit(data) {
    data.personId = profile.id;
    data.id = horaryPrice.id; 
    data.active = horaryPrice.active; 
    data.registerDate = horaryPrice.registerDate;

    dispatch(saveHoraryPriceRequest(data));
  }

  const fieldItens = useSelector(state => state.fieldItem.fieldItens);
  const profile = useSelector(state => state.user.profile);
  const horaryPrice = useSelector(state => state.horaryPrice.horaryPrice);

  return (
    <Card
      {...rest}
      className={clsx(classes.root, className)}
    >
      <Form initialData={horaryPrice} onSubmit={handleSubmit}>
        <CardHeader
          subheader="Informações sobre o preço do horário"
          title="Preço do horário"
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
              md={12}
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
              <Input name="startDate" type='date' label="Data inicio"
                required                              
                InputLabelProps={{
                  shrink: true,
                }}
              />
            </Grid>            
            <Grid
              item
              md={6}
              xs={12}
            >
              <Input name="endDate" type='date' label="Data fim"
               InputLabelProps={{
                  shrink: true,
                }}
              />
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

HoraryPriceDetails.propTypes = {
  className: PropTypes.string
};

export default HoraryPriceDetails;
