import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { makeStyles } from '@material-ui/styles';
import { Grid } from '@material-ui/core';

import {
  CardActions,
  TablePagination
} from '@material-ui/core';

import { PlayerCard } from '../index';

import { fetchPlayerByIdRequest
} from '~/store/modules/player/actions';

const useStyles = makeStyles(theme => ({
  content: {
    marginTop: theme.spacing(2)
  },
  pagination: {
    marginTop: theme.spacing(3),
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'flex-end'
  }
}));

const PlayersCard = () => {
  const classes = useStyles();

  const dispatch = useDispatch();

  const [rowsPerPage, setRowsPerPage] = useState(5);
  const [page, setPage] = useState(0);

  const handlePageChange = (event, page) => {
    setPage(page);
  };

  const handleRowsPerPageChange = event => {
    setRowsPerPage(event.target.value);
  };

  const handleOnClickUpdate = (player) => {
    dispatch(fetchPlayerByIdRequest(player));
  }; 

  const players = useSelector(state => state.player.players);

  return (
<>
    <div>
      <div className={classes.content}>
        <Grid
          container
          spacing={3}
        >
          {players.slice(rowsPerPage * page,(rowsPerPage * page) + rowsPerPage).map(player => (
            <Grid
              item
              key={player.id}
              lg={4}
              md={6}
              xs={12}
            >
              <PlayerCard player={player} onClick={() => handleOnClickUpdate(player)} />
            </Grid>
          ))}
        </Grid>
      </div>
      <div className={classes.pagination}>
      <CardActions className={classes.actions}>
        <TablePagination
          component="div"
          count={players.length}          
          onChangePage={handlePageChange}
          onChangeRowsPerPage={handleRowsPerPageChange}
          page={page}
          rowsPerPage={rowsPerPage}
          rowsPerPageOptions={[5, 10, 25]}
        />
      </CardActions>
      </div>
    </div>
    </>
  );
};

export default PlayersCard;
