import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import MaterialTable from 'material-table';

import PropTypes from 'prop-types';

import { Typography } from '@material-ui/core';

import { championshipGroup } from '~/data';

import DialogComponent from '~/components/DialogComponent';

import { deleteGroupChampionshipRequest, fetchGroupChampionshipByIdRequest
} from '~/store/modules/groupChampionship/actions';

const GroupChampionshipTable = props => {
  const dispatch = useDispatch();
  const [dialog , setDialog] = useState(false);
  const [groupChampionship , setGroupChampionship] = useState();
  
  const handleClickOpen = (groupChampionship) => {
    setDialog(true);
    setGroupChampionship(groupChampionship);
  };

  const handleClose = () => {
    setDialog(false);
  };

  const handleCloseYes = () => {
    dispatch(deleteGroupChampionshipRequest(groupChampionship));
    handleClose();
  };

  const handleOnClickUpdate = (groupChampionship) => {
    dispatch(fetchGroupChampionshipByIdRequest(groupChampionship));
  };

  const groupChampionships = useSelector(state => state.groupChampionship.groupChampionships.map(o => ({...o, tableData: {}})));

  var columns = [
    {title: "id", field: "id", hidden: true},
    {title: "Time", field: "subscription.team.name", render: rowData => 
        <Typography variant="body1">{rowData.subscription.team.name}</Typography>},
    {title: "Grupo", field: "groupId", render: rowData => 
        <Typography variant="body1">{Object.values(championshipGroup[rowData.groupId - 1])[1]}</Typography>},        
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
          text= 'Você deseja excluir essa relação?'
          onClose={() => handleClose()} 
          onClick={() => handleCloseYes()} />

    <MaterialTable
                title="Grupos"
                columns={columns}
                data={groupChampionships}
                actions={actions}
                options={{
                  actionsColumnIndex: -1
                }}
              />           

        </>
  );
};

GroupChampionshipTable.propTypes = {
  className: PropTypes.string
};

export default GroupChampionshipTable;
