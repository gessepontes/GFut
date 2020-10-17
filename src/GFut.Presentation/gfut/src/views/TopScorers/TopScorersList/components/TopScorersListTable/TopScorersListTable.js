import React from 'react';
import { useSelector } from 'react-redux';
import MaterialTable from 'material-table';

import PropTypes from 'prop-types';

import { Typography } from '@material-ui/core';

const StandingsListsTable = props => {

  const topScorersList = useSelector(state => state.topScorers.topScorers);

  var columns = [
    {title: "id", field: "id", hidden: true},
    {title: "Posição", field: "position", render: rowData => 
        <Typography variant="body1">{rowData.position}</Typography>},
    {title: "Jogador", field: "played", render: rowData => 
        <Typography variant="body1">{rowData.player}</Typography>},
    {title: "Time", field: "team", render: rowData => 
        <Typography variant="body1">{rowData.team}</Typography>},
    {title: "Gol(s)", field: "goals", render: rowData => 
        <Typography variant="body1">{rowData.goals}</Typography>}          
  ]

  return (
    <>
          <MaterialTable
            title="Artilharia"
            columns={columns}
            data={topScorersList.map(o => ({ ...o }))}
          />        
    </>
  );
};

StandingsListsTable.propTypes = {
  className: PropTypes.string
};

export default StandingsListsTable;
