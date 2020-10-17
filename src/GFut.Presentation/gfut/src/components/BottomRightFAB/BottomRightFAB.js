import React from 'react';
import PropTypes from 'prop-types';
import Fab from '@material-ui/core/Fab';
import AddIcon from '@material-ui/icons/Add';
import ArrowBackIcon from '@material-ui/icons/ArrowBack';

const BottomRightFAB = props => {
  const { size, 
          color,
          back, 
          onClick 
        } = props;

		const style={
			position: 'fixed',
			zIndex:3,
			right: back === 'true' ? 80 : 30,
			bottom: 35,
    }

		return (
			<Fab
                onClick={onClick}
                color={color}
                style={style}
                size={size}
				>
				{back === 'true' ? < ArrowBackIcon /> : < AddIcon /> }
			</Fab>
		)
  };
  
  BottomRightFAB.propTypes = {
    size: PropTypes.string.isRequired,
    color: PropTypes.string.isRequired,
    back: PropTypes.string,
    onClick: PropTypes.any.isRequired
  };
  

export default BottomRightFAB;