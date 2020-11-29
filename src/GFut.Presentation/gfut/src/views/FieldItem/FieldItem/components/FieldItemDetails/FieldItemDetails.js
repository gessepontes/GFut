import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import clsx from 'clsx';
import PropTypes from 'prop-types';

import { makeStyles } from '@material-ui/styles';

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

import { saveFieldItemRequest
} from '~/store/modules/fieldItem/actions';

const useStyles = makeStyles(() => ({
  root: {}
}));

const FieldItemDetails = props => {
  const dispatch = useDispatch();

  const { className, ...rest } = props;

  const classes = useStyles();

  const handleBack = () => {
    history.push('/fieldItens');
  };

  function handleSubmit(data) {
    data.personId = profile.id; 
    data.id = fieldItem.id; 
    data.fieldId = field.id;
    data.picture = fieldItem.picture; 
    data.registerDate = fieldItem.registerDate; 
    dispatch(saveFieldItemRequest(data));
  }

  const field = useSelector(state => state.field.field);
  const profile = useSelector(state => state.user.profile);
  const fieldItem = useSelector(state => state.fieldItem.fieldItem);

  return (
    <Card
      {...rest}
      className={clsx(classes.root, className)}
    >
      <Form initialData={fieldItem} onSubmit={handleSubmit}>
        <CardHeader
          subheader="Informações sobre o campo"
          title="Campo Item"
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
               <Input name="fieldName" disabled defaultValue={field.name} label="Campo"/>
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
              <MCheckbox name="active" label="Ativo"/>
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

FieldItemDetails.propTypes = {
  className: PropTypes.string
};

export default FieldItemDetails;
