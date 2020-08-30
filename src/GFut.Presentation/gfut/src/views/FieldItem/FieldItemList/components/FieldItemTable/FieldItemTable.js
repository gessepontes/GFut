import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';

import MaterialTable from 'material-table';

import PropTypes from 'prop-types';
import { Typography, Avatar } from '@material-ui/core';

import CheckBoxIcon from '@material-ui/icons/CheckBox';
import CheckBoxOutlineBlankIcon from '@material-ui/icons/CheckBoxOutlineBlank';

import DialogComponent from '~/components/DialogComponent';

import { deleteFieldItemRequest, fetchFieldItemByIdRequest
} from '~/store/modules/fieldItem/actions';

const FieldItemTable = props => {
  const dispatch = useDispatch();
  const [dialog , setDialog] = useState(false);
  const [field , setField] = useState();

  const handleClickOpen = (fieldItem) => {
    setDialog(true);
    setField(fieldItem);
  };

  const handleClose = () => {
    setDialog(false);
  };

  const handleCloseYes = () => {
    dispatch(deleteFieldItemRequest(field));
    handleClose();
  };

  const handleOnClickUpdate = (field) => {
    dispatch(fetchFieldItemByIdRequest(field));
  };

  const listFieldItem = useSelector(state => state.fieldItem.fieldItens.map(o => ({...o, tableData: {}})));

  var columns = [
    {title: "id", field: "id", hidden: true},
    {title: "Avatar", render: rowData => <Avatar size={40} 
        round={"true"} name={rowData === undefined ? " " : rowData.name}
        src={`http://localhost:51933/picture/fieldItem/${rowData.picture}`}  />  },
    {title: "Nome", field: "name", render: rowData => 
      <Typography variant="body1">{rowData.name}</Typography>},
    {title: "Ativo", type:"boolean", render: rowData => rowData.active === true 
    ?  <CheckBoxIcon /> : <CheckBoxOutlineBlankIcon /> }
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
            text= 'Você deseja excluir esse campo item?'
            onClose={() => handleClose()} 
            onClick={() => handleCloseYes()} />

      <MaterialTable
        title="Campos Itens"
        columns={columns}
        data={listFieldItem}
        actions={actions}
        options={{
          actionsColumnIndex: -1
        }}
      />
    </>
  );
};

FieldItemTable.propTypes = {
  className: PropTypes.string
};

export default FieldItemTable;
