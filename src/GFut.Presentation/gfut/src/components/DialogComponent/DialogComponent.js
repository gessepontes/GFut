import React from 'react'
import PropTypes from 'prop-types';
import Button from '@material-ui/core/Button';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogTitle from '@material-ui/core/DialogTitle';

const DialogComponent = props => {
  const { open, 
          onClose, 
          onClick, 
          text 
        } = props;

		return (
      <Dialog
        open={open}
        onClose={onClose}
        aria-labelledby="alert-dialog-title"
        aria-describedby="alert-dialog-description"
      >
          <DialogTitle id="alert-dialog-title">{text ? text : "Você deseja excluir esse registro?"}</DialogTitle>
          <DialogActions>
              <Button onClick={onClose} color="primary">
                  Não
              </Button>
              <Button onClick={onClick} variant="contained" color="primary" autoFocus>
                  Sim
              </Button>
          </DialogActions>
       </Dialog>
		)
  };

  DialogComponent.propTypes = {
    open: PropTypes.bool.isRequired,
    text: PropTypes.string,
    onClick: PropTypes.any.isRequired,
    onClose: PropTypes.any.isRequired
  };
  

export default DialogComponent;