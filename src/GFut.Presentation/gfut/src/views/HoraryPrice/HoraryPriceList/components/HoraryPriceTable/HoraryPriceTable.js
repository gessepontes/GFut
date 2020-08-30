import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';

import NumberFormat from 'react-number-format';

import MaterialTable from 'material-table';

import PropTypes from 'prop-types';

import moment from 'moment';

import { Typography } from '@material-ui/core';

import DialogComponent from '~/components/DialogComponent';

import { deleteHoraryPriceRequest, fetchHoraryPriceByIdRequest
} from '~/store/modules/horaryPrice/actions';

const HoraryPriceTable = props => {
  const dispatch = useDispatch();
  const [dialog , setDialog] = useState(false);
  const [horaryPrice , setHoraryPrice] = useState();
  
  const handleClickOpen = (horaryPrice) => {
    setDialog(true);
    setHoraryPrice(horaryPrice);
  };

  const handleClose = () => {
    setDialog(false);
  };

  const handleCloseYes = () => {
    dispatch(deleteHoraryPriceRequest(horaryPrice));
    handleClose();
  };

  const handleOnClickUpdate = (horaryPrice) => {
    dispatch(fetchHoraryPriceByIdRequest(horaryPrice));
  };

  const horaryPrices = useSelector(state => state.horaryPrice.horaryPrices.map(o => ({...o, tableData: {}})));

  var columns = [
    {title: "id", field: "id", hidden: true},
    {title: "Campo", field: "picture", render: rowData =>
        <Typography variant="body1">{rowData.fieldItem.name}</Typography> },
    {title: "Data inicio", field: "startDate", render: rowData => 
        <Typography variant="body1">{rowData.startDate !== null ? 
          moment(rowData.startDate).format('DD/MM/YYYY') : ""}</Typography>},
    {title: "Data fim", field: "endDate", render: rowData => 
      <Typography variant="body1">{rowData.endDate !== null ? 
        moment(rowData.endDate).format('DD/MM/YYYY') : ""}</Typography>},
    {title: "Valor", field: "value", render: rowData =>
      <Typography variant="body1">{<NumberFormat value={rowData.value} displayType={'text'} 
      thousandSeparator={true} prefix={'R$ '} />}</Typography>},
    {title: "Valor mensal", field: "monthlyValue", render: rowData =>
      <Typography variant="body1">{<NumberFormat value={rowData.monthlyValue} displayType={'text'} 
      thousandSeparator={true} prefix={'R$ '} />}</Typography>},
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
            text= 'Você deseja excluir esse valor?'
            onClose={() => handleClose()} 
            onClick={() => handleCloseYes()} />

      <MaterialTable
                  title="Valor do horário"
                  columns={columns}
                  data={horaryPrices}
                  actions={actions}
                  options={{
                    actionsColumnIndex: -1
                  }}
                />           
          </>
  );
};

HoraryPriceTable.propTypes = {
  className: PropTypes.string
};

export default HoraryPriceTable;
