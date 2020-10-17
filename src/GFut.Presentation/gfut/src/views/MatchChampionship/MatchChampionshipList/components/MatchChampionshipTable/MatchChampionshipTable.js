import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import MaterialTable from 'material-table';

import PropTypes from 'prop-types';

import { Typography } from '@material-ui/core';

import moment from 'moment';

import DialogComponent from '~/components/DialogComponent';

import { deleteMatchChampionshipRequest, fetchMatchChampionshipByIdRequest
} from '~/store/modules/matchChampionship/actions';

import { fetchFieldItemByIdFieldRequest
} from '~/store/modules/fieldItem/actions';

const MatchChampionshipsTable = props => {
  const dispatch = useDispatch();
  const [dialog , setDialog] = useState(false);
  const [matchChampionship , setMatchChampionship] = useState();

  const handleOnClickUpdate = (matchChampionship) => {
    dispatch(fetchFieldItemByIdFieldRequest(matchChampionship.fieldItem.fieldId))

    setTimeout(() => {
      dispatch(fetchMatchChampionshipByIdRequest(matchChampionship));
    }, 500);
  };
  
  const handleClickOpen = (matchChampionship) => {
    setDialog(true);
    setMatchChampionship(matchChampionship);
  };

  const handleClose = () => {
    setDialog(false);
  };

  const handleCloseYes = () => {
    dispatch(deleteMatchChampionshipRequest(matchChampionship));
    handleClose();
  };

  const matchChampionships = useSelector(state => state.matchChampionship.matchChampionships.map(o => ({...o, tableData: {}})));

  var columns = [
    {title: "id", field: "id", hidden: true},
    {title: "Time1", field: "homeSubscription.team.name", render: rowData => 
        <Typography variant="body1">{rowData.homeSubscription.team.name}</Typography>},
    {title: "Gol1", field: "homePoints", render: rowData => 
        <Typography variant="body1">{rowData.homePoints}</Typography>},
    {title: "Gol2", field: "guestPoints", render: rowData => 
        <Typography variant="body1">{rowData.guestPoints}</Typography>},                
    {title: "Time2", field: "guestSubscription.team.name", render: rowData => 
        <Typography variant="body1">{rowData.guestSubscription.team.name}</Typography>},
    {title: "Data/Hora", field: "matchDate", render: rowData => 
        <Typography variant="body1">{moment(rowData.matchDate).format('DD/MM/YYYY') +" / "+ rowData.startTime}</Typography>}, 
    {title: "Rodada", field: "round", render: rowData => 
        <Typography variant="body1">{rowData.round}</Typography>},               
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
          text= 'Você deseja excluir essa inscrição?'
          onClose={() => handleClose()} 
          onClick={() => handleCloseYes()} />

    <MaterialTable
                title="Inscrição"
                columns={columns}
                data={matchChampionships}
                actions={actions}
                options={{
                  actionsColumnIndex: -1
                }}
              />           

        </>
  );
};

MatchChampionshipsTable.propTypes = {
  className: PropTypes.string
};

export default MatchChampionshipsTable;
