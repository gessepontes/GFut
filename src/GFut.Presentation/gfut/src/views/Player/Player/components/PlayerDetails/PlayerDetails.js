import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import clsx from 'clsx';
import PropTypes from 'prop-types';
import { makeStyles } from '@material-ui/styles';

import { Input, MCheckbox, InputMaskPhone } from '~/components';
import { position } from '~/data';
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

import { savePlayerRequest
} from '~/store/modules/player/actions';

const useStyles = makeStyles(() => ({
  root: {}
}));

const PlayerDetails = props => {
  const dispatch = useDispatch();
  //const [dispenseDate, setDispenseDate] = useState(true);

  const { className, ...rest } = props;

  const classes = useStyles();

  const handleBack = () => {
    history.push('/players');
  };

 function handleSubmit(data) {
    data.teamId = team.id; 
    data.id = player.id; 
    data.picture = player.picture; 
    data.active = player.active; 
    data.registerDate = player.registerDate; 

    dispatch(savePlayerRequest(data));
  }

  // function enableDispenseDate(event) {
  //   setDispenseDate(!event.target.checked);
  // }

  const team = useSelector(state => state.user.profile.team);
  const player = useSelector(state => state.player.player);

  return (
    <Card
      {...rest}
      className={clsx(classes.root, className)}
    >
      <Form initialData={player} onSubmit={handleSubmit}>
        <CardHeader
          subheader="Informações sobre o jogador"
          title="Jogador"
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
              <Input name="TimeName" disabled defaultValue={team.name} label="Time"/>
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
              <InputMaskPhone name="phone" label="Celular"/>
            </Grid>
            <Grid
              item
              md={6}
              xs={12}
            >
              <Input name="position" label="Posição"
                required                              
                select
                SelectProps={{ native: true }}
              >
                {position.map(option => (
                  <option
                    key={option.value}
                    value={option.value}
                  >
                    {option.label}
                  </option>
                ))}
              </Input>
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
              md={6}
              xs={12}
            >
              <MCheckbox name="dispensed" label="Dispensado"/>
            </Grid>

            {/* <Grid
              item
              md={6}
              xs={12}
            >
              <Input disabled = {dispenseDate} name="dispenseDate" type='date' label="Data de Dispensa"                                              
                InputLabelProps={{
                  shrink: true,
                }}
              />
            </Grid> */}
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

PlayerDetails.propTypes = {
  className: PropTypes.string
};

export default PlayerDetails;
