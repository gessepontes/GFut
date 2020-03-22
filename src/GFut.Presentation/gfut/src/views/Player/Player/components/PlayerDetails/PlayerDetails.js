import React, {useState} from 'react';
import { useDispatch, useSelector } from 'react-redux';
import clsx from 'clsx';
import PropTypes from 'prop-types';
import { Form, Input } from '@rocketseat/unform';
import { makeStyles, withStyles } from '@material-ui/styles';

import { MTextField, MCheckbox } from '~/components';

import {
  Card,
  CardHeader,
  CardContent,
  CardActions,
  Divider,
  Grid,
  Button
} from '@material-ui/core';

import { red } from '@material-ui/core/colors';

import history from '~/services/history';

import { savePlayerRequest, deletePlayerRequest
} from '~/store/modules/player/actions';

const useStyles = makeStyles(() => ({
  root: {}
}));

const PlayerDetails = props => {
  const dispatch = useDispatch();
  const [dispenseDate, setDispenseDate] = useState(true);

  const { className, ...rest } = props;

  const classes = useStyles();

  const handleBack = () => {
    history.push('/players');
  };

  const handleDelete = () => {
    dispatch(deletePlayerRequest(player));
  };

  function handleSubmit(data) {
    data.teamId = team.id; 
    dispatch(savePlayerRequest(data));
  }

  function enableDispenseDate(event) {
    setDispenseDate(!event.target.checked);
  }

  const team = useSelector(state => state.user.profile.team);
  const player = useSelector(state => state.player.player);

  const ColorButton = withStyles(theme => ({
    root: {
      color: theme.palette.getContrastText(red[500]),
      backgroundColor: red[500]
    },
  }))(Button);

  const position = [
    {
      value: '1',
      label: 'Goleiro'
    },
    {
      value: '2',
      label: 'Zagueiro'
    },
    {
      value: '3',
      label: 'Volante'
    },        
    {
      value: '4',
      label: 'Meio-Campo'
    },
    {
      value: '5',
      label: 'Atacante'
    },
    {
      value: '6',
      label: 'Lateral'
    }
  ];

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
              md={6}
              xs={12}
            >
              <Input name="id" type='hidden' />
              <Input name="teamId" type='hidden' />
              <Input name="picture" type='hidden' />   
              <Input name="active" type='hidden' />        
              <Input name="registerDate" type='hidden' />   

              <MTextField required name="name" label="Nome"/>
            </Grid>
            <Grid
              item
              md={6}
              xs={12}
            >             
              <MTextField required name="phone" label="Celular"/>
            </Grid>
            <Grid
              item
              md={6}
              xs={12}
            >
              <MTextField name="position" label="Posição"
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
              </MTextField>
            </Grid>
            <Grid
              item
              md={6}
              xs={12}
            >
              <MTextField name="birthDate" type='date' label="Data de aniversário"
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
              <MCheckbox name="dispensed" onChange={enableDispenseDate} label="Dispensado"/>
            </Grid>

            <Grid
              item
              md={6}
              xs={12}
            >
              <MTextField disabled = {dispenseDate} name="dispenseDate" type='date' label="Data de Dispensa"                                              
                InputLabelProps={{
                  shrink: true,
                }}
              />
            </Grid>
          </Grid>
        </CardContent>
        <Divider />
        <CardActions>
          { player.id !== 0 ? 
                    <ColorButton onClick ={handleDelete}
                    variant="contained" color="secondary"
                  >
                    Excluir
                  </ColorButton>
          : null }


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
