import React from 'react';
import { useDispatch, useSelector } from 'react-redux';

import history from '~/services/history';

import MaterialTable from 'material-table';

import PropTypes from 'prop-types';

import { Typography } from '@material-ui/core';

import { fetchFieldByIdRequest
} from '~/store/modules/field/actions';

const FieldComponents = props => {
  
    const { titleField, 
            url
          } = props;

    const dispatch = useDispatch();

    const handleClick = (field) => {
      dispatch(fetchFieldByIdRequest(field));
      history.push('/' + url);
    };  
 
    const fields = useSelector(state => state.field.fields.map(o => ({...o, tableData: {}})));

    var columns = [
      {title: "id", field: "id", hidden: true},
      {title: "Nome", field: "name", render: rowData => 
          <Typography variant="body1">{rowData.name}</Typography>},
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
                  title={titleField}
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
  
  FieldComponents.propTypes = {
    titleField: PropTypes.string.isRequired,
    url: PropTypes.string.isRequired
  };
  

export default FieldComponents;