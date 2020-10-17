import React from 'react';
import { useSelector } from 'react-redux';
import MaterialTable from 'material-table';

import PropTypes from 'prop-types';

import { Typography } from '@material-ui/core';

const StandingsListsTable = props => {

  const standingsList = useSelector(state => state.standings.standings);

  var columns = [
    {title: "id", field: "id", hidden: true},
    {title: "Time", field: "name", render: rowData => 
        <Typography variant="body1">{rowData.name}</Typography>},
    {title: "Partidas", field: "played", render: rowData => 
        <Typography variant="body1">{rowData.played}</Typography>},
    {title: "Vitorias", field: "won", render: rowData => 
        <Typography variant="body1">{rowData.won}</Typography>},
    {title: "Empates", field: "drawn", render: rowData => 
        <Typography variant="body1">{rowData.drawn}</Typography>},
    {title: "Derrotas", field: "lost", render: rowData => 
        <Typography variant="body1">{rowData.lost}</Typography>},
    {title: "Gol P", field: "goalsFor", render: rowData => 
        <Typography variant="body1">{rowData.goalsFor}</Typography>},
    {title: "Gol C", field: "goalsAgainst", render: rowData => 
        <Typography variant="body1">{rowData.goalsAgainst}</Typography>},
    {title: "Saldo", field: "goalsDifference", render: rowData => 
        <Typography variant="body1">{rowData.goalsDifference}</Typography>},
    {title: "Pontos", field: "points", render: rowData => 
        <Typography variant="body1">{rowData.points}</Typography>}, 
    {title: "%", field: "percentage", render: rowData => 
        <Typography variant="body1">{rowData.percentage}</Typography>},                
  ]

  return (
    <>
     {standingsList.map((option, index) => (
          <MaterialTable
            title="Classificação"
            columns={columns}
            key={index}
            data={option.map(o => ({ ...o }))}
          />          
      ))}        
    </>
  );
};

StandingsListsTable.propTypes = {
  className: PropTypes.string
};

export default StandingsListsTable;
