import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import MaterialTable from 'material-table';
import PropTypes from 'prop-types';
import { Typography } from '@material-ui/core';
import { schedulingState } from '~/data';
import { format } from 'date-fns';

import DialogComponent from '~/components/DialogComponent';

import { deleteSchedulingRequest, fetchSchedulingByIdRequest
} from '~/store/modules/scheduling/actions';

import { fetchHoraryFieldByTypeIdFieldItemRequest
} from '~/store/modules/horaryField/actions';

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
    let data = {
      type: scheduling.horaryType,
      fieldItem: scheduling.horaryType === 1 ? scheduling.horary.fieldItemId : scheduling.horaryExtra.fieldItemId,
      date: format(new Date(scheduling.date),"yyyy-MM-dd"),
      horaryId: scheduling.horaryType === 1 ? scheduling.horaryId : scheduling.horaryExtraId,
    }

    dispatch(fetchHoraryFieldByTypeIdFieldItemRequest(data));
    dispatch(fetchSchedulingByIdRequest(scheduling.id));

    // setTimeout(() => {
    //   dispatch(fetchSchedulingByIdRequest(scheduling.id));  
    // }, 2000);
  };

  const schedulings = useSelector(state => state.scheduling.schedulings.map(o => ({...o, tableData: {}})));

  var columns = [
    {title: "id", field: "id", hidden: true},
    {title: "Campo", field: "horary.fieldItem.name", render: rowData =>
        <Typography variant="body1">{rowData.horaryType === 1 ? rowData.horary.fieldItem.name : rowData.horaryExtra.fieldItem.name}</Typography> },
    {title: "Data", field: "date", render: rowData => 
        <Typography variant="body1">{moment(rowData.date).format('DD/MM/YYYY')}</Typography>},
    {title: "Hora", field: "horary.hour", render: rowData => 
        <Typography variant="body1">{rowData.horaryType === 1 ? rowData.horary.hour : rowData.horaryExtra.hour}</Typography>},
    {title: "Cliente", field: "person.name", render: rowData => 
    <Typography variant="body1">{rowData.person ? rowData.person.name : rowData.customerNotRegistered}</Typography>}, 
    {title: "Status", field: "state", render: rowData => 
        <Typography variant="body1">{Object.values(schedulingState[rowData.state - 1])[1]}</Typography>},                
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
                      data={schedulings}
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
