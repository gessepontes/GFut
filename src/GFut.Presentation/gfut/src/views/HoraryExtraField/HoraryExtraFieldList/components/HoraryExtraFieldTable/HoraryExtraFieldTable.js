import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';

import MaterialTable from 'material-table';
import PropTypes from 'prop-types';
import { Typography } from '@material-ui/core';

import DialogComponent from '~/components/DialogComponent';

import { deleteHoraryExtraFieldRequest, fetchHoraryExtraFieldByIdRequest
} from '~/store/modules/horaryExtraField/actions';

import moment from 'moment';

const HoraryExtraFieldTable = props => {
  const dispatch = useDispatch();
  const [dialog , setDialog] = useState(false);
  const [horaryExtraField , setHoraryExtraField] = useState();

  const handleClickOpen = (horaryExtraField) => {
    setDialog(true);
    setHoraryExtraField(horaryExtraField);
  };

  const handleClose = () => {
    setDialog(false);
  };

  const handleCloseYes = () => {
    dispatch(deleteHoraryExtraFieldRequest(horaryExtraField));
    handleClose();
  };

  const handleOnClickUpdate = (horaryExtraField) => {
    dispatch(fetchHoraryExtraFieldByIdRequest(horaryExtraField));
  };

  const horaryExtraFields = useSelector(state => state.horaryExtraField.horaryExtraFields.map(o => ({...o, tableData: {}})));


  var columns = [
    {title: "id", field: "id", hidden: true},
    {title: "Campo", field: "name", render: rowData =>
        <Typography variant="body1">{rowData.fieldItem.name}</Typography> },
    {title: "Data", field: "date", render: rowData => 
        <Typography variant="body1">{moment(rowData.date).format('DD/MM/YYYY')}</Typography>},
    {title: "Hora", field: "hour", render: rowData => 
        <Typography variant="body1">{rowData.hour}</Typography>}
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
          text= 'Você deseja excluir esse horário extra?'
          onClose={() => handleClose()} 
          onClick={() => handleCloseYes()} />

    <MaterialTable
                      title="Horários extra"
                      columns={columns}
                      data={horaryExtraFields}
                      actions={actions}
                      options={{
                        actionsColumnIndex: -1
                      }}
                    />           
        </>
  );
};

HoraryExtraFieldTable.propTypes = {
  className: PropTypes.string
};

export default HoraryExtraFieldTable;
