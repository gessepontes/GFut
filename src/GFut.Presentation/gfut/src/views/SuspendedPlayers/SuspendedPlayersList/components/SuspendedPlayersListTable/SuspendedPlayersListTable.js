import React from 'react';
import { useSelector } from 'react-redux';
import MaterialTable from 'material-table';

import PropTypes from 'prop-types';

import { Typography } from '@material-ui/core';

const SuspendedPlayersListTable = props => {

  const suspendedPlayersList = useSelector(state => state.suspendedPlayers.suspendedPlayers);

  var columns = [
    {title: "id", field: "id", hidden: true},
    {title: "Jogador", field: "played", render: rowData => 
        <Typography variant="body1">{rowData.player}</Typography>},
    {title: "Time", field: "team", render: rowData => 
        <Typography variant="body1">{rowData.team}</Typography>},         
  ]

  return (
    <>
          <MaterialTable
            title="Artilharia"
            columns={columns}
            data={suspendedPlayersList.map(o => ({ ...o }))}
          />        
    </>
  );
};

SuspendedPlayersListTable.propTypes = {
  className: PropTypes.string
};

export default SuspendedPlayersListTable;
