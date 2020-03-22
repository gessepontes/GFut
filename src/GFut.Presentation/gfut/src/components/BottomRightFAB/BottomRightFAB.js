import React from 'react';
import PropTypes from 'prop-types';
import Fab from '@material-ui/core/Fab';
import AddIcon from '@material-ui/icons/Add';

const BottomRightFAB = props => {
  const { size, 
          color, 
          onClick 
        } = props;

		const style={
			position: 'fixed',
			zIndex:3,
			right:30,
			bottom: 35,
		}

		return (
			<Fab
                onClick={onClick}
                color={color}
                style={style}
                size={size}
				>
				< AddIcon />
			</Fab>
		)
  };
  
  BottomRightFAB.propTypes = {
    size: PropTypes.string.isRequired,
    color: PropTypes.string.isRequired,
    onClick: PropTypes.any.isRequired
  };
  

export default BottomRightFAB;