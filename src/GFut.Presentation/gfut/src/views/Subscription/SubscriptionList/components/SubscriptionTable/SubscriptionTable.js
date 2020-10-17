import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import MaterialTable from 'material-table';

import PropTypes from 'prop-types';

import { Typography } from '@material-ui/core';

import DialogComponent from '~/components/DialogComponent';

import { deleteSubscriptionRequest, fetchSubscriptionByIdRequest
} from '~/store/modules/subscription/actions';

const SubscriptionsTable = props => {
  const dispatch = useDispatch();
  const [dialog , setDialog] = useState(false);
  const [subscription , setSubscription] = useState();
  
  const handleClickOpen = (subscription) => {
    setDialog(true);
    setSubscription(subscription);
  };

  const handleClose = () => {
    setDialog(false);
  };

  const handleCloseYes = () => {
    dispatch(deleteSubscriptionRequest(subscription));
    handleClose();
  };

  const handleOnClickUpdate = (subscription) => {
    dispatch(fetchSubscriptionByIdRequest(subscription));
  };

  const subscriptions = useSelector(state => state.subscription.subscriptions.map(o => ({...o, tableData: {}})));

  var columns = [
    {title: "id", field: "id", hidden: true},
    {title: "Campeonato", field: "championship.name", render: rowData => 
        <Typography variant="body1">{rowData.championship.name}</Typography>},
    {title: "Time", field: "team.name", render: rowData => 
        <Typography variant="body1">{rowData.team.name}</Typography>},
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
                data={subscriptions}
                actions={actions}
                options={{
                  actionsColumnIndex: -1
                }}
              />           

        </>
  );
};

SubscriptionsTable.propTypes = {
  className: PropTypes.string
};

export default SubscriptionsTable;
