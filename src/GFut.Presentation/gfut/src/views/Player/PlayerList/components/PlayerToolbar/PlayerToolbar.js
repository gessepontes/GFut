import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import PropTypes from 'prop-types';
import clsx from 'clsx';
import { makeStyles } from '@material-ui/styles';

import { SearchInput, BottomRightFAB } from 'components';

import { playerInitialValues, 
  fetchSearchPlayerRequest } from '~/store/modules/player/actions';

const useStyles = makeStyles(theme => ({
  root: {},
  row: {
    height: '42px',
    display: 'flex',
    alignItems: 'center'
  },
  spacer: {
    flexGrow: 1
  },
  searchInput: {
    marginRight: theme.spacing(1)
  }
}));

const PlayerToolbar = props => {
  const { className, ...rest } = props;

  const classes = useStyles();
  const teamId = useSelector(state => state.user.profile.team.id);
  const dispatch = useDispatch();

  const handleClick = () => {
    dispatch(playerInitialValues());
  };

  const handleSearchClick = event => {

    const t = {
      idTeam: teamId,
      search: event.target.value
    }

    dispatch(fetchSearchPlayerRequest(t));
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
          placeholder="Search player"
        />
      </div>
    </div>
  );
};

PlayerToolbar.propTypes = {
  className: PropTypes.string
};

export default PlayerToolbar;
