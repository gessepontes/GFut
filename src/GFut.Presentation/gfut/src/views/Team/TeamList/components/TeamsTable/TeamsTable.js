import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import MaterialTable from 'material-table';

import PropTypes from 'prop-types';

import { Typography, Avatar } from '@material-ui/core';

import DialogComponent from '~/components/DialogComponent';

import { deleteTeamRequest, fetchTeamByIdRequest, updateStatusTeamRequest
} from '~/store/modules/team/actions';

const TeamsTable = props => {
  const dispatch = useDispatch();
  const [dialog , setDialog] = useState(false);
  const [team , setTeam] = useState();

  const handleClickOpen = (team) => {
    setDialog(true);
    setTeam(team);
  };

  const handleClose = () => {
    setDialog(false);
  };

  const handleCloseYes = () => {
    dispatch(deleteTeamRequest(team));
    handleClose();
  };

  const handleOnClickUpdate = (team) => {
    dispatch(fetchTeamByIdRequest(team));
  };

  const handleOnClickStatus = (team) => {
    dispatch(updateStatusTeamRequest(team));
  };  

  const listTeams = useSelector(state => state.team.teams.map(o => ({...o, tableData: {}})));

  var columns = [
    {title: "id", field: "id", hidden: true},
    {title: "Nome", field: "symbol", render: rowData =>
      <Avatar size={40} 
        round={"true"} name={rowData === undefined ? " " : rowData.name}
        src={`http://localhost:51933/picture/team/${rowData.symbol}`}  />  },
    {title: "Nome", field: "name", render: rowData =>
      <Typography variant="body1">{rowData.name}</Typography>}    
  ]

   var actions=[
    rowData => ({
      icon: rowData.active === true
      ?  'check_box' : 'check_box_outline_blank',
      tooltip: 'Ativo',
      onClick: (event, rowData) => handleOnClickStatus(rowData)
    }),    
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
          text= 'Você deseja excluir esse time?'
          onClose={() => handleClose()} 
          onClick={() => handleCloseYes()} />

    <MaterialTable
            title="Times"
            columns={columns}
            data={listTeams}
            actions={actions}
            options={{
              actionsColumnIndex: -1
            }}
          />      

    </>
  );
};

TeamsTable.propTypes = {
  className: PropTypes.string
};

export default TeamsTable;
