import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import MaterialTable from 'material-table';
import PropTypes from 'prop-types';
import { Typography } from '@material-ui/core';

import DialogComponent from '~/components/DialogComponent';

import { deleteSchedulingRequest, fetchSchedulingByIdRequest
} from '~/store/modules/scheduling/actions';

import moment from 'moment';

const SchedulingTable = props => {
  const dispatch = useDispatch();
  const [dialog , setDialog] = useState(false);
  const [scheduling , setScheduling] = useState();
  
  const handleClickOpen = (scheduling) => {
    setDialog(true);
    setScheduling(scheduling);
  };

  const handleClose = () => {
    setDialog(false);
  };

  const handleCloseYes = () => {
    dispatch(deleteSchedulingRequest(scheduling));
    handleClose();
  };

  const handleOnClickUpdate = (scheduling) => {
    dispatch(fetchSchedulingByIdRequest(scheduling));
  };

  const Schedulings = useSelector(state => state.scheduling.schedulings.map(o => ({...o, tableData: {}})));

  var columns = [
    {title: "id", field: "id", hidden: true},
    {title: "Campo", field: "name", render: rowData =>
        <Typography variant="body1">{rowData.horary.fieldItem.name}</Typography> },
    {title: "Data", field: "date", render: rowData => 
        <Typography variant="body1">{moment(rowData.date).format('DD/MM/YYYY')}</Typography>},
    {title: "Hora", field: "hour", render: rowData => 
        <Typography variant="body1">{rowData.horary.hour}</Typography>},
    {title: "Cliente", field: "client", render: rowData => 
    <Typography variant="body1">{rowData.person.name}</Typography>}, 
    {title: "Status", field: "state", render: rowData => 
        <Typography variant="body1">{rowData.state}</Typography>},                
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
          text= 'Você deseja excluir esse agendamento?'
          onClose={() => handleClose()} 
          onClick={() => handleCloseYes()} />

    <MaterialTable
                      title="Agendamentos"
                      columns={columns}
                      data={Schedulings}
                      actions={actions}
                      options={{
                        actionsColumnIndex: -1
                      }}
                    />           
        </>
  );
};

SchedulingTable.propTypes = {
  className: PropTypes.string
};

export default SchedulingTable;
