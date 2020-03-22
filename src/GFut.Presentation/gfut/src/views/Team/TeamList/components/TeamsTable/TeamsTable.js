import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';

import clsx from 'clsx';
import PropTypes from 'prop-types';
import PerfectScrollbar from 'react-perfect-scrollbar';
import { makeStyles } from '@material-ui/styles';
import {
  Card,
  CardActions,
  CardContent,
  Avatar,
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableRow,
  Typography,
  TablePagination
} from '@material-ui/core';

import IconButton from '@material-ui/core/IconButton';
import DeleteIcon from '@material-ui/icons/Delete';
import EditIcon from '@material-ui/icons/Edit';
import CheckBoxIcon from '@material-ui/icons/CheckBox';
import CheckBoxOutlineBlankIcon from '@material-ui/icons/CheckBoxOutlineBlank';

import DialogComponent from '~/components/DialogComponent';

import { deleteTeamRequest, fetchTeamByIdRequest, updateStatusTeamRequest
} from '~/store/modules/team/actions';

import { getInitials } from 'helpers';

const useStyles = makeStyles(theme => ({
  root: {},
  content: {
    padding: 0
  },
  inner: {
    minWidth: 1050
  },
  nameContainer: {
    display: 'flex',
    alignItems: 'center'
  },
  avatar: {
    marginRight: theme.spacing(2)
  },
  actions: {
    justifyContent: 'flex-end'
  }
}));

const TeamsTable = props => {
  const dispatch = useDispatch();
  const [dialog , setDialog] = useState(false);
  const [team , setTeam] = useState();
  
  const { className, ...rest } = props;

  const classes = useStyles();

  const [rowsPerPage, setRowsPerPage] = useState(5);
  const [page, setPage] = useState(0);

  const teams = useSelector(state => state.team.teams);

  const handlePageChange = (event, page) => {
    setPage(page);
  };

  const handleRowsPerPageChange = event => {
    setRowsPerPage(event.target.value);
  };

  const handleClickOpen = (team) => {
    setDialog(true);
    setTeam(team);
  };

  const handleClose = () => {
    setDialog(false);
  };

  const handleCloseYes = () => {
    dispatch(deleteTeamRequest(team));
    handleClose();
  };

  const handleOnClickUpdate = (team) => {
    dispatch(fetchTeamByIdRequest(team));
  };

  const handleOnClickStatus = (team) => {
    dispatch(updateStatusTeamRequest(team));
  };  

  return (
    <>

    <DialogComponent open={dialog} 
          text= 'Você deseja excluir esse time?'
          onClose={() => handleClose()} 
          onClick={() => handleCloseYes()} />

    <Card
      {...rest}
      className={clsx(classes.root, className)}
    >
      <CardContent className={classes.content}>
        <PerfectScrollbar>
          <div className={classes.inner}>
            <Table>
              <TableHead>
                <TableRow>                  
                  <TableCell>Nome</TableCell>
                  <TableCell>Status</TableCell>
                  <TableCell>Editar</TableCell>
                  <TableCell>Excluir</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {teams.slice(rowsPerPage * page,(rowsPerPage * page) + rowsPerPage).map(team => (
                  <TableRow
                    className={classes.tableRow}
                    hover
                    key={team.id}
                  >
                    <TableCell>
                      <div className={classes.nameContainer}>
                        <Avatar
                          className={classes.avatar}
                          src={`http://localhost:51933/picture/team/${team.symbol}`} 
                        >
                          {getInitials(team.name)}
                        </Avatar>
                        <Typography variant="body1">{team.name}</Typography>
                      </div>
                    </TableCell>
                    <TableCell padding="checkbox">
                      <IconButton onClick={() => handleOnClickStatus(team)}>
                        {team.active ? (
                          <CheckBoxIcon />
                        ) : (
                          <CheckBoxOutlineBlankIcon />
                        )}                                              
                      </IconButton>
                    </TableCell>
                    <TableCell padding="checkbox">
                      <IconButton onClick={() => handleOnClickUpdate(team)}>
                        <EditIcon />
                      </IconButton>
                    </TableCell>
                    <TableCell padding="checkbox">
                      <IconButton onClick={() => handleClickOpen(team)}> 
                        <DeleteIcon />
                      </IconButton>
                    </TableCell>                    
                  </TableRow>
                ))}
              </TableBody>
            </Table>
          </div>
        </PerfectScrollbar>
      </CardContent>
      <CardActions className={classes.actions}>
        <TablePagination
          component="div"
          count={teams.length}          
          onChangePage={handlePageChange}
          onChangeRowsPerPage={handleRowsPerPageChange}
          page={page}
          rowsPerPage={rowsPerPage}
          rowsPerPageOptions={[5, 10, 25]}
        />
      </CardActions>
    </Card>
        </>
  );
};

TeamsTable.propTypes = {
  className: PropTypes.string
};

export default TeamsTable;
