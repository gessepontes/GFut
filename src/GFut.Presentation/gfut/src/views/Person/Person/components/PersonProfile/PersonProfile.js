import React, {useState} from 'react';
import PropTypes from 'prop-types';
import clsx from 'clsx';
import { makeStyles } from '@material-ui/styles';
import {
  Card,
  CardActions,
  CardContent,
  Avatar,
  Divider,
  Button
} from '@material-ui/core';

import { useDispatch, useSelector } from 'react-redux';

import { updatePicturePersonSuccess
} from '~/store/modules/person/actions';

const useStyles = makeStyles(theme => ({
  root: {
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
  },
  details: {
  },
  avatar: {
    //marginLeft: 'auto',
    height: 100,
    width: 100,
    flexShrink: 0,
    flexGrow: 0,
  },
  uploadButton: {
    marginRight: theme.spacing(2)
  }
}));

const PersonProfile = props => {
  const { className, ...rest } = props;

  const classes = useStyles();
  const dispatch = useDispatch();

  const person = useSelector(state => state.person.person);

  const [preview, setPreview] = useState(person.picture);

  async function handleChange(e) {
    e.preventDefault();
    let file = e.target.files[0];

    if(file !== undefined){
      let reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onloadend = () => {
        setPreview(reader.result);
        dispatch(updatePicturePersonSuccess(reader.result));
      };  
    }
  }

  return (
    <Card
      {...rest}
      className={clsx(classes.root, className)}
    >
      <CardContent>
        <div className={classes.details}>
          <Avatar
            className={classes.avatar}
            src={preview}
          />
        </div>
      </CardContent>
      <Divider />
      <CardActions>
        <Button
          variant="contained"
          component="label"
          color="primary"
          className={classes.uploadButton}
        >
          Atualizar foto
          <input
            type="file"
            style={{ display: "none" }}
            data-file={preview}
            onChange={handleChange}
          />
        </Button>               
      </CardActions>
    </Card>
  );
};

PersonProfile.propTypes = {
  className: PropTypes.string
};

export default PersonProfile;
