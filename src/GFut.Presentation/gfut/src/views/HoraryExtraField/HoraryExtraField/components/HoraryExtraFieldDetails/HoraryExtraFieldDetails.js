import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import clsx from 'clsx';
import PropTypes from 'prop-types';

import { makeStyles } from '@material-ui/styles';

import { Input } from '~/components';

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

import { saveHoraryExtraFieldRequest
} from '~/store/modules/horaryExtraField/actions';

const useStyles = makeStyles(() => ({
  root: {}
}));

const HoraryExtraFieldDetails = props => {
  const dispatch = useDispatch();

  const { className, ...rest } = props;

  const classes = useStyles();

  const handleBack = () => {
    history.push('/horaryExtraFields');
  };

  function handleSubmit(data) {
    data.id = horaryExtraField.id; 
    data.active = horaryExtraField.active; 
    data.registerDate = horaryExtraField.registerDate;
    dispatch(saveHoraryExtraFieldRequest(data));
  }

  const fieldItens = useSelector(state => state.fieldItem.fieldItens);
  const horaryExtraField = useSelector(state => state.horaryExtraField.horaryExtraField);

  return (
    <Card
      {...rest}
      className={clsx(classes.root, className)}
    >
      <Form initialData={horaryExtraField} onSubmit={handleSubmit}>
        <CardHeader
          subheader="Informações sobre o horário do campo"
          title="Horário do campo"
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
              <Input name="date" type='date' label="Data Extra"
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
              <Input name="hour" type="time" required label="Hora"                 
                InputLabelProps={{
                  shrink: true,
                }}/>
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

HoraryExtraFieldDetails.propTypes = {
  className: PropTypes.string
};

export default HoraryExtraFieldDetails;
