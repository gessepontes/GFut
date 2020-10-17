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

import { fetchPlayerByIdSubscriptionsRequest
} from '~/store/modules/player/actions';

import { savePlayerRegistrationRequest
} from '~/store/modules/playerRegistration/actions';

const useStyles = makeStyles(() => ({
  root: {}
}));

const PlayerRegistrationDetails = props => {
  const dispatch = useDispatch();

  const { className, ...rest } = props;

  const classes = useStyles();

  const handleBack = () => {
    history.push('/playerRegistrations');
  };

  function handleSubmit(data) {
    data.id = playerRegistration.id;
    data.approvedDate = playerRegistration.approvedDate; 
    data.active = playerRegistration.active; 
    data.state = playerRegistration.state; 
    data.registerDate = playerRegistration.registerDate; 
    dispatch(savePlayerRegistrationRequest(data));
  }

  const championship = useSelector(state => state.championship.championship);
  const playerRegistration = useSelector(state => state.playerRegistration.playerRegistration);
  const subscriptions = useSelector(state => state.subscription.subscriptions);
  const players = useSelector(state => state.player.players);

  const handleChange = (e) => {
    dispatch(fetchPlayerByIdSubscriptionsRequest(e.target.value));
  }

  return (
    <Card
      {...rest}
      className={clsx(classes.root, className)}
    >
      <Form initialData={playerRegistration} onSubmit={handleSubmit}>
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
              md={12}
              xs={12}
            >
              <Input name="ChampionshipName" disabled defaultValue={championship.name} label="Campeonato"/>
            </Grid>

            <Grid
              item
              md={6}
              xs={12}
            >
               <Input name="subscriptionId" label="Time" onChange={e => handleChange(e)}
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
              md={6}
              xs={12}
            >
               <Input name="playerId" label="Atleta"
                required                              
                select
                SelectProps={{ native: true }}
              >
                <option>
                  </option>
                {players.map(option => (
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

PlayerRegistrationDetails.propTypes = {
  className: PropTypes.string
};

export default PlayerRegistrationDetails;
