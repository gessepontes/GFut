import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import PropTypes from 'prop-types';
import clsx from 'clsx';
import { makeStyles } from '@material-ui/styles';

import { SearchInput, BottomRightFAB } from 'components';

import { teamInitialValues, fetchSearchTeamRequest } from '~/store/modules/team/actions';

const useStyles = makeStyles(theme => ({
  root: {},
  row: {
    height: '30px',
    display: 'flex',
    alignItems: 'center',
    marginTop: theme.spacing(1)
  },
  spacer: {
    flexGrow: 1
  },
  searchInput: {
    marginRight: theme.spacing(1)
  }
}));

const TeamsToolbar = props => {
  const { className, ...rest } = props;

  const classes = useStyles();
  const profile = useSelector(state => state.user.profile);
  const dispatch = useDispatch();

  const handleClick = () => {
    dispatch(teamInitialValues());
  };

  const handleSearchClick = event => {

    const t = {
      idPerson: profile.id,
      search: event.target.value
    }

    dispatch(fetchSearchTeamRequest(t));
  };

  return (
    <div
      {...rest}
      className={clsx(classes.root, className)}
    >
      <div className={classes.row}>
        <BottomRightFAB size='small' color='primary' onClick={() => handleClick()} />
      </div>
      <div className={classes.row}>
        <SearchInput
          onChange={handleSearchClick}
          className={classes.searchInput}
          placeholder="Search team"
        />
      </div>
    </div>
  );
};

TeamsToolbar.propTypes = {
  className: PropTypes.string
};

export default TeamsToolbar;
