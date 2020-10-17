import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import clsx from 'clsx';
import PropTypes from 'prop-types';

import { Form } from '@unform/web';
import { Input, InputMaskPhone } from '~/components';

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

import { updateProfileRequest
} from '~/store/modules/user/actions';

const useStyles = makeStyles(() => ({
  root: {}
}));

const AccountDetails = props => {
  const dispatch = useDispatch();

  const { className, ...rest } = props;

  const classes = useStyles();

  function handleSubmit(data) {

    data.id = profile.id; 
    data.picture = profile.picture; 

    dispatch(updateProfileRequest(data));
  }

  const profile = useSelector(state => state.user.profile);

  return (
    <Card
      {...rest}
      className={clsx(classes.root, className)}
    >
      <Form initialData={profile} onSubmit={handleSubmit}>
        <CardHeader
          subheader="Informações sobre o usuário"
          title="Usuário"
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
              <Input required name="name" label="Nome"/>
            </Grid>
            <Grid
              item
              md={6}
              xs={12}
            >             
              <Input required name="email" label="E-mail" disabled/>
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
              <Input name="birthDate" type='date' label="Data de nascimento"
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
              <Input name="password" label="Senha" type='password'/>
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
        </CardActions>
        </Form>
    </Card>
  );
};

AccountDetails.propTypes = {
  className: PropTypes.string
};

export default AccountDetails;
