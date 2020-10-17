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

import { saveSubscriptionRequest
} from '~/store/modules/subscription/actions';

const useStyles = makeStyles(() => ({
  root: {}
}));

const SubscriptionDetails = props => {
  const dispatch = useDispatch();

  const { className, ...rest } = props;

  const classes = useStyles();

  const handleBack = () => {
    history.push('/subscriptions');
  };

  function handleSubmit(data) {
    data.id = subscription.id;
    data.approvedDate = subscription.approvedDate; 
    data.active = subscription.active; 
    data.registerDate = subscription.registerDate; 
    data.championshipId = championship.id;
    dispatch(saveSubscriptionRequest(data));
  }

  const championship = useSelector(state => state.championship.championship);
  const subscription = useSelector(state => state.subscription.subscription);
  const teams = useSelector(state => state.team.teams);

  return (
    <Card
      {...rest}
      className={clsx(classes.root, className)}
    >
      <Form initialData={subscription} onSubmit={handleSubmit}>
        <CardHeader
          subheader="Informações sobre a inscrição"
          title="Inscrição"
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
              <Input name="ChampionshipName" disabled defaultValue={championship.name} label="Campeonato"/>
            </Grid> 
            <Grid
              item
              md={6}
              xs={12}
            >
               <Input name="teamId" label="Time"
                required                              
                select
                SelectProps={{ native: true }}
              >
                <option>
                  </option>
                {teams.map(option => (
                  <option
                    key={option.id}
                    value={option.id}
                  >
                    {option.name}
                  </option>
                ))}
              </Input>
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

SubscriptionDetails.propTypes = {
  className: PropTypes.string
};

export default SubscriptionDetails;
