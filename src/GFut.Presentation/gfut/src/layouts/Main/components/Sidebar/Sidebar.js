import React from 'react';
import clsx from 'clsx';

import PropTypes from 'prop-types';
import { makeStyles } from '@material-ui/styles';
import { Divider, Drawer, Hidden } from '@material-ui/core';
import DashboardIcon from '@material-ui/icons/Dashboard';
import PeopleIcon from '@material-ui/icons/People';
import PersonIcon from '@material-ui/icons/Person';
import TextFieldsIcon from '@material-ui/icons/TextFields';
import AccountBoxIcon from '@material-ui/icons/AccountBox';
import SettingsIcon from '@material-ui/icons/Settings';
import LocationOnIcon from '@material-ui/icons/LocationOn';

import List from '@material-ui/core/List'

import { Profile, SidebarNav } from './components';

const useStyles = makeStyles(theme => ({
  drawer: {
    width: 240,
    [theme.breakpoints.up('lg')]: {
      marginTop: 64,
      height: 'calc(100% - 64px)'
    }
  },
  root: {
    backgroundColor: theme.palette.white,
    display: 'flex',
    flexDirection: 'column',
    height: '100%',
    padding: theme.spacing(2)
  },
  divider: {
    margin: theme.spacing(2, 0)
  },
  nav: {
    marginBottom: theme.spacing(2)
  }
}));

const Sidebar = props => {
  const { open, variant, onClose, className, ...rest } = props;

  const classes = useStyles();
  const pages = [
    {
      title: 'Dashboard',
      href: '/dashboard',
      Icon: DashboardIcon 
    },
    {
      title: 'Users',
      href: '/users',
      Icon: PeopleIcon 
    },
    {
      title: 'Time',
      href: '/teams',
      Icon: PeopleIcon 
    },    
    {
      title: 'Atleta',
      href: '/players',
      Icon: PersonIcon 
    },    
    {
      title: 'Campos',
      href: '',
      Icon: LocationOnIcon ,
      items: [
        {
          title: 'Campo',
          href: '/fields',
        },
        {
          title: 'Campo Item',
          href: '/fieldItens',
        },
        {
          title: 'Valor',
          href: '/horaryPrices',
        },   
        {
          title: 'Horários',
          href: '/horaryFields',
        }, 
        {
          title: 'Horário Extra',
          href: '/horaryExtraFields',
        }, 
        {
          title: 'Agendar Horário',
          href: '/schedulings',
        },     
      ],
    },  
    {
      title: 'Typography',
      href: '/typography',
      Icon: TextFieldsIcon 
    },
    {
      title: 'Account',
      href: '/account',
      Icon: AccountBoxIcon 
    },
    {
      title: 'Settings',
      href: '/settings',
      Icon: SettingsIcon 
    }
  ];

  return (
    <Drawer
      anchor="left"
      classes={{ paper: classes.drawer }}
      onClose={onClose}
      open={open}
      variant={variant}
    >
      <div
        {...rest}
        className={clsx(classes.root, className)}
      >
        <Profile />
        <Divider className={classes.divider} />
        <Hidden lgUp>
              <List component="nav" className={classes.appMenu} disablePadding>
                {pages.map((item, index) => (
                  <SidebarNav {...item} key={index} />
                ))}
              </List>
        </Hidden>
        <Hidden mdDown>
              <List component="nav" className={classes.appMenu} disablePadding>
                {pages.map((item, index) => (
                  <SidebarNav {...item} key={index} />
                ))}
              </List>
        </Hidden>
      </div>
    </Drawer>
  );
};

Sidebar.propTypes = {
  className: PropTypes.string,
  onClose: PropTypes.func,
  open: PropTypes.bool.isRequired,
  variant: PropTypes.string.isRequired
};

export default Sidebar;
