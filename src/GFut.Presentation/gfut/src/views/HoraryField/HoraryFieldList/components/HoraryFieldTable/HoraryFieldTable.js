import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';

import MaterialTable from 'material-table';

import PropTypes from 'prop-types';
import { dayWeek } from '~/data';

import { Typography } from '@material-ui/core';
import CheckBoxIcon from '@material-ui/icons/CheckBox';
import CheckBoxOutlineBlankIcon from '@material-ui/icons/CheckBoxOutlineBlank';

import DialogComponent from '~/components/DialogComponent';

import { deleteHoraryFieldRequest, fetchHoraryFieldByIdRequest
} from '~/store/modules/horaryField/actions';

const HoraryFieldTable = props => {
  const dispatch = useDispatch();
  const [dialog , setDialog] = useState(false);
  const [horaryField , setHoraryField] = useState();
  
  const handleClickOpen = (horaryField) => {
    setDialog(true);
    setHoraryField(horaryField);
  };

  const handleClose = () => {
    setDialog(false);
  };

  const handleCloseYes = () => {
    dispatch(deleteHoraryFieldRequest(horaryField));
    handleClose();
  };

  const handleOnClickUpdate = (horaryField) => {
    dispatch(fetchHoraryFieldByIdRequest(horaryField));
  };

  const horaryFields = useSelector(state => state.horaryField.horaryFields.map(o => ({...o, tableData: {}})));

  var columns = [
    {title: "id", field: "id", hidden: true},
    {title: "Campo", field: "picture", render: rowData =>
        <Typography variant="body1">{rowData.fieldItem.name}</Typography> },
    {title: "Dia da semana", field: "dayWeek", render: rowData => 
        <Typography variant="body1">{Object.values(dayWeek[rowData.dayWeek - 1])[1]}</Typography>},
    {title: "Hora", field: "hour", render: rowData => 
        <Typography variant="body1">{rowData.hour}</Typography>},
    {title: "Status", field: "value", render: rowData =>
        rowData.state ? (
          <CheckBoxIcon />
        ) : (
          <CheckBoxOutlineBlankIcon />
        )}
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
          text= 'Você deseja excluir esse horário?'
          onClose={() => handleClose()} 
          onClick={() => handleCloseYes()} />

    <MaterialTable
                      title="Horários"
                      columns={columns}
                      data={horaryFields}
                      actions={actions}
                      options={{
                        actionsColumnIndex: -1
                      }}
                    />          

        </>
  );
};

HoraryFieldTable.propTypes = {
  className: PropTypes.string
};

export default HoraryFieldTable;
