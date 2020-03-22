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
              <Input name="id" type='hidden' />
              <Input name="picture" type='hidden' />

              <MTextField required name="name" label="Nome"/>
            </Grid>
            <Grid
              item
              md={6}
              xs={12}
            >             
              <MTextField required name="email" label="E-mail" disabled/>
            </Grid>            
            <Grid
              item
              md={6}
              xs={12}
            >
              <MTextField name="phone" label="Celular"/>
            </Grid>
            <Grid
              item
              md={6}
              xs={12}
            >
              <MTextField name="birthDate" type='date' label="Data de nascimento"
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
              <MTextField name="password" label="Senha" type='password'/>
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
