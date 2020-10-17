import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import MaterialTable from 'material-table';

import PropTypes from 'prop-types';

import { Typography } from '@material-ui/core';

import DialogComponent from '~/components/DialogComponent';

import { deletePlayerRegistrationRequest
} from '~/store/modules/playerRegistration/actions';

const PlayerRegistrationsTable = props => {
  const dispatch = useDispatch();
  const [dialog , setDialog] = useState(false);
  const [playerRegistration , setPlayerRegistration] = useState();
  
  const handleClickOpen = (playerRegistration) => {
    setDialog(true);
    setPlayerRegistration(playerRegistration);
  };

  const handleClose = () => {
    setDialog(false);
  };

  const handleCloseYes = () => {
    dispatch(deletePlayerRegistrationRequest(playerRegistration));
    handleClose();
  };

  const playerRegistrations = useSelector(state => state.playerRegistration.playerRegistrations.map(o => ({...o, tableData: {}})));

  var columns = [
    {title: "id", field: "id", hidden: true},
    {title: "Time", field: "subscription.team.name", render: rowData => 
        <Typography variant="body1">{rowData.subscription.team.name}</Typography>},
    {title: "Atleta", field: "player.name", render: rowData => 
        <Typography variant="body1">{rowData.player.name}</Typography>},        
  ] 

  var actions=[    
    {
      icon: 'delete',
      tooltip: 'Excluir',
      onClick: (event, rowData) => handleClickOpen(rowData)
    }
  ]  

  return (
    <>

    <DialogComponent open={dialog} 
          text= 'Você deseja excluir essa inscrição?'
          onClose={() => handleClose()} 
          onClick={() => handleCloseYes()} />

    <MaterialTable
                title="Inscrição"
                columns={columns}
                data={playerRegistrations}
                actions={actions}
                options={{
                  actionsColumnIndex: -1
                }}
              />           

        </>
  );
};

PlayerRegistrationsTable.propTypes = {
  className: PropTypes.string
};

export default PlayerRegistrationsTable;
