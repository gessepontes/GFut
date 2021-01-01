import React from 'react';
import clsx from 'clsx';

import PropTypes from 'prop-types';
import { makeStyles } from '@material-ui/styles';
import { Divider, Drawer, Hidden } from '@material-ui/core';

import List from '@material-ui/core/List'

import { Profile, SidebarNav } from './components';

import { useSelector } from 'react-redux';

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

  const pages = useSelector(state => state.user.profile.pageProfiles);
  const classes = useStyles();

  const pagesDefault = [
    {
      title: 'Dashboard',
      href: 'dashboard',
      icon: 'dashboard' 
    }
    // }, 
    // {
    //   title: 'Perfil',
    //   href: '/account',
    //   Icon: AccountBoxIcon 
    // },
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
          
              <List component="nav" className={classes.appMenu} disablePadding dense>
                {pages.map((item, index) => (
                  item.page.menu ? <SidebarNav title={item.page.title} 
                    href={item.page.href} 
                    IconBase={item.page.icon} key={index} />  : null
                ))}  
              </List>
        </Hidden>
        <Hidden mdDown>
              <List component="nav" className={classes.appMenu} disablePadding dense>
                <div>
                
                  {pagesDefault.map((item, index) => (
                      <SidebarNav title={item.title} 
                        href={item.href} 
                        IconBase={item.icon} key={index} />
                    ))}
                  {pages.map((item, index) => (
                    item.page.menu ? <SidebarNav title={item.page.title} 
                      href={item.page.href} 
                      IconBase={item.page.icon}
                      items={item.page.pages}
                      key={index} /> : null
                  ))} 

                </div>          
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
