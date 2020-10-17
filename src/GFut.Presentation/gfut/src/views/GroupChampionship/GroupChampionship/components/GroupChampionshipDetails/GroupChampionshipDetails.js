import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import clsx from 'clsx';
import PropTypes from 'prop-types';

import { makeStyles } from '@material-ui/styles';

import { Input } from '~/components';
import { Form } from '@unform/web';

import { championshipGroup } from '~/data';

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

import { saveGroupChampionshipRequest
} from '~/store/modules/groupChampionship/actions';

const useStyles = makeStyles(() => ({
  root: {}
}));

const GroupChampionshipDetails = props => {
  const dispatch = useDispatch();

  const { className, ...rest } = props;

  const classes = useStyles();

  const handleBack = () => {
    history.push('/groupChampionships');
  };

  function handleSubmit(data) {
    data.id = groupChampionship.id;
    data.active = groupChampionship.active; 
    data.registerDate = groupChampionship.registerDate; 
    dispatch(saveGroupChampionshipRequest(data));
  }

  const championship = useSelector(state => state.championship.championship);
  const groupChampionship = useSelector(state => state.groupChampionship.groupChampionship);
  const subscriptions = useSelector(state => state.subscription.subscriptions);

  return (
    <Card
      {...rest}
      className={clsx(classes.root, className)}
    >
      <Form initialData={groupChampionship} onSubmit={handleSubmit}>
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
               <Input name="subscriptionId" label="Time"
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
              <Input name="groupId" label="Grupo"
                required                              
                select
                SelectProps={{ native: true }}
              >
                {championshipGroup.map(option => (
                  <option
                    key={option.value}
                    value={option.value}
                  >
                    {option.label}
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

GroupChampionshipDetails.propTypes = {
  className: PropTypes.string
};

export default GroupChampionshipDetails;
