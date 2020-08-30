import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import MaterialTable from 'material-table';
import moment from 'moment';
import { position } from '~/data';
import { Typography, Avatar } from '@material-ui/core';

import DialogComponent from '~/components/DialogComponent';

import { fetchPlayerByIdRequest, deletePlayerRequest
} from '~/store/modules/player/actions';

const PlayersTable = () => {
  const dispatch = useDispatch();
  const [dialog , setDialog] = useState(false);
  const [player , setPlayer] = useState();

  const handleClickOpen = (player) => {
    setDialog(true);
    setPlayer(player);
  };

  const handleClose = () => {
    setDialog(false);
  };

  const handleCloseYes = () => {
    dispatch(deletePlayerRequest(player));
    handleClose();
  };

  const handleOnClickUpdate = (player) => {
    dispatch(fetchPlayerByIdRequest(player));
  }; 

  const players = useSelector(state => state.player.players.map(o => ({...o, tableData: {}})));

  var columns = [
    {title: "id", field: "id", hidden: true},
    {title: "Foto", field: "picture", render: rowData => <Avatar size={40} 
        round={"true"} name={rowData === undefined ? " " : rowData.name}
        src={`http://localhost:51933/picture/player/${rowData.picture}`}  />  },
    {title: "Nome", field: "name", render: rowData =>
        <Typography variant="body1">{rowData.name}</Typography>},
    {title: "Data de aniversário", field: "birthDate", render: rowData => 
      <Typography variant="body1">{moment(rowData.birthDate).format('DD/MM/YYYY')}
      </Typography>},
    {title: "Celular", field: "phone", render: rowData => 
      <Typography variant="body1">{rowData.phone}</Typography>},
    {title: "Posição", field: "position", render: rowData => 
      <Typography variant="body1">{Object.values(position[rowData.position - 1])[1]}</Typography>},
  ] 

  var actions=[    
    {
      icon: 'edit',
      tooltip: 'Editar',
      onClick: (event, rowData) => handleOnClickUpdate(rowData)
    },
    {
      icon: 'delete',
      tooltip: 'Excluir',
      onClick: (event, rowData) => handleClickOpen(rowData)
    }
  ]  

  return (
    <>
        <DialogComponent open={dialog} 
                  text= 'Você deseja excluir esse atleta?'
                  onClose={() => handleClose()} 
                  onClick={() => handleCloseYes()} />

        <MaterialTable
            title="Atletas"
            columns={columns}
            data={players}
            actions={actions}
            options={{
              actionsColumnIndex: -1
            }}
          /> 
    </>
  );
};

export default PlayersTable;
