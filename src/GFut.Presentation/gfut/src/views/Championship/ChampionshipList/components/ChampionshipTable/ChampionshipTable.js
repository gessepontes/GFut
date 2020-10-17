import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import MaterialTable from 'material-table';

import PropTypes from 'prop-types';

import { Typography } from '@material-ui/core';

import DialogComponent from '~/components/DialogComponent';

import { deleteChampionshipRequest, fetchChampionshipByIdRequest
} from '~/store/modules/championship/actions';

const ChampionshipsTable = props => {
  const dispatch = useDispatch();
  const [dialog , setDialog] = useState(false);
  const [championship , setChampionship] = useState();
  
  const handleClickOpen = (championship) => {
    setDialog(true);
    setChampionship(championship);
  };

  const handleClose = () => {
    setDialog(false);
  };

  const handleCloseYes = () => {
    dispatch(deleteChampionshipRequest(championship));
    handleClose();
  };

  const handleOnClickUpdate = (championship) => {
    dispatch(fetchChampionshipByIdRequest(championship));
  };

  const championships = useSelector(state => state.championship.championships.map(o => ({...o, tableData: {}})));

  var columns = [
    {title: "id", field: "id", hidden: true},
    {title: "Nome", field: "name", render: rowData => 
        <Typography variant="body1">{rowData.name}</Typography>},
    // {title: "Responsável", field: "person.name", render: rowData => 
    //     <Typography variant="body1">{rowData.person.name}</Typography>},
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
          text= 'Você deseja excluir esse campeonato?'
          onClose={() => handleClose()} 
          onClick={() => handleCloseYes()} />

    <MaterialTable
                title="Campeonatos"
                columns={columns}
                data={championships}
                actions={actions}
                options={{
                  actionsColumnIndex: -1
                }}
              />           

        </>
  );
};

ChampionshipsTable.propTypes = {
  className: PropTypes.string
};

export default ChampionshipsTable;
