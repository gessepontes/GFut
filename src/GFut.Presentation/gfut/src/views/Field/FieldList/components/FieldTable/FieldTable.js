import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import MaterialTable from 'material-table';

import PropTypes from 'prop-types';

import { Typography, Avatar } from '@material-ui/core';

import DialogComponent from '~/components/DialogComponent';

import { deleteFieldRequest, fetchFieldByIdRequest
} from '~/store/modules/field/actions';

const FieldsTable = props => {
  const dispatch = useDispatch();
  const [dialog , setDialog] = useState(false);
  const [field , setField] = useState();
  
  const handleClickOpen = (field) => {
    setDialog(true);
    setField(field);
  };

  const handleClose = () => {
    setDialog(false);
  };

  const handleCloseYes = () => {
    dispatch(deleteFieldRequest(field));
    handleClose();
  };

  const handleOnClickUpdate = (field) => {
    dispatch(fetchFieldByIdRequest(field));
  };

  const fields = useSelector(state => state.field.fields.map(o => ({...o, tableData: {}})));

  var columns = [
    {title: "id", field: "id", hidden: true},
    {title: "Foto", field: "picture", render: rowData => <Avatar size={40} 
        round={"true"} name={rowData === undefined ? " " : rowData.name}
        src={`http://localhost:51933/picture/field/${rowData.picture}`}   />  },
    {title: "Nome", field: "name", render: rowData => 
        <Typography variant="body1">{rowData.name}</Typography>},
    {title: "Telefone", field: "phone", render: rowData => 
        <Typography variant="body1">{rowData.phone}</Typography>},
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
          text= 'Você deseja excluir esse campo?'
          onClose={() => handleClose()} 
          onClick={() => handleCloseYes()} />

    <MaterialTable
                title="Campos"
                columns={columns}
                data={fields}
                actions={actions}
                options={{
                  actionsColumnIndex: -1
                }}
              />           

        </>
  );
};

FieldsTable.propTypes = {
  className: PropTypes.string
};

export default FieldsTable;
