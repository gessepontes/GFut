import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import MaterialTable from 'material-table';
import { Typography } from '@material-ui/core';

import DialogComponent from '~/components/DialogComponent';

import { fetchPersonByIdRequest, deletePersonRequest
} from '~/store/modules/person/actions';

const PersonTable = () => {
  const dispatch = useDispatch();
  const [dialog , setDialog] = useState(false);
  const [person , setPerson] = useState();

  const handleClickOpen = (person) => {
    setDialog(true);
    setPerson(person);
  };

  const handleClose = () => {
    setDialog(false);
  };

  const handleCloseYes = () => {
    dispatch(deletePersonRequest(person));
    handleClose();
  };

  const handleOnClickUpdate = (person) => {
    dispatch(fetchPersonByIdRequest(person));
  }; 

  const people = useSelector(state => state.person.people.map(o => ({...o, tableData: {}})));

  var columns = [
    {title: "id", field: "id", hidden: true},
    {title: "Nome", field: "name", render: rowData =>
        <Typography variant="body1">{rowData.name}</Typography>},
    {title: "Celular", field: "phone", render: rowData => 
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
                  text= 'Você deseja excluir essa pessoa?'
                  onClose={() => handleClose()} 
                  onClick={() => handleCloseYes()} />

        <MaterialTable
            title="Atletas"
            columns={columns}
            data={people}
            actions={actions}
            options={{
              actionsColumnIndex: -1
            }}
          /> 
    </>
  );
};

export default PersonTable;
