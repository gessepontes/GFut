import React from 'react';
import { useDispatch, useSelector } from 'react-redux';

import history from '~/services/history';

import MaterialTable from 'material-table';

import PropTypes from 'prop-types';

import { Typography } from '@material-ui/core';

import { fetchChampionshipByIdRequest
} from '~/store/modules/championship/actions';

const ChampionshipComponents = props => {
  
    const { titleChampionship, 
            url
          } = props;

    const dispatch = useDispatch();

    const handleClick = (championship) => {
      dispatch(fetchChampionshipByIdRequest(championship));
      history.push('/' + url);
    };  
 
    const championships = useSelector(state => state.championship.championships.map(o => ({...o, tableData: {}})));

    var columns = [
      {title: "id", field: "id", hidden: true},
      {title: "Nome", field: "name", render: rowData => 
          <Typography variant="body1">{rowData.name}</Typography>},
      // {title: "Responsável", field: "person.name", render: rowData => 
      //     <Typography variant="body1">{rowData.person.name}</Typography>},
    ]
    
    var actions=[
      {
        icon: 'search',
        tooltip: 'Detalhe',
        onClick: (event, rowData) => handleClick(rowData)
      }]
    
    return (
      <> 
      <MaterialTable
                  title={titleChampionship}
                  columns={columns}
                  data={championships}
                  actions={actions}
                  options={{
                    actionsColumnIndex: -1
                  }}
                />           
  
          </>
    );
  };
  
  ChampionshipComponents.propTypes = {
    titleChampionship: PropTypes.string.isRequired,
    url: PropTypes.string.isRequired
  };
  

export default ChampionshipComponents;