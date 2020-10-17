import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import clsx from 'clsx';
import PropTypes from 'prop-types';
import { makeStyles } from '@material-ui/styles';

import { Input, MCheckboxList, InputMaskPhone } from '~/components';
import { profileType } from '~/data';
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

import { savePersonRequest
} from '~/store/modules/person/actions';

const useStyles = makeStyles(() => ({
  root: {}
}));

const PersonDetails = props => {
  const dispatch = useDispatch();
  const { className, ...rest } = props;

  const classes = useStyles();

  const handleBack = () => {
    history.push('/people');
  };

 function handleSubmit(data) {
    data.id = person.id; 
    data.picture = person.picture; 
    data.active = person.active; 
    data.registerDate = person.registerDate; 

    dispatch(savePersonRequest(data));
  }

  const person = useSelector(state => state.person.person);

  return (
    <Card
      {...rest}
      className={clsx(classes.root, className)}
    >
      <Form initialData={person} onSubmit={handleSubmit}>
        <CardHeader
          subheader="Informações sobre a pessoa"
          title="Pessoa"
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
              <Input required name="name" label="Nome"/>
            </Grid>
            <Grid
              item
              md={6}
              xs={12}
            >             
              <InputMaskPhone required name="phone" label="Celular"/>
            </Grid>
            <Grid
              item
              md={6}
              xs={12}
            >
              <Input name="birthDate" type='date' label="Data de aniversário"
                required                              
                InputLabelProps={{
                  shrink: true,
                }}
              />
            </Grid>
            <Grid
              item
              md={12}
              xs={12}
            >
              <Input name="email" label="E-Mail" type='email' required/>
            </Grid>
            <Grid
              item
              md={12}
              xs={12}
            >
              <Input name="password" label="Senha" type='password'/>
            </Grid>
            <Grid
              item
              md={12}
              xs={12}
            >
              <MCheckboxList name="profileType"  options={profileType}/>
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

PersonDetails.propTypes = {
  className: PropTypes.string
};

export default PersonDetails;
