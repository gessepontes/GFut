import React, { forwardRef } from 'react';
import { NavLink as RouterLink } from 'react-router-dom';

import PropTypes from 'prop-types'
import { makeStyles, createStyles } from '@material-ui/core/styles'

import List from '@material-ui/core/List'
import ListItem from '@material-ui/core/ListItem'
import ListItemIcon from '@material-ui/core/ListItemIcon'
import ListItemText from '@material-ui/core/ListItemText'
import Divider from '@material-ui/core/Divider'
import Collapse from '@material-ui/core/Collapse'

import IconExpandLess from '@material-ui/icons/ExpandLess'
import IconExpandMore from '@material-ui/icons/ExpandMore'

const CustomRouterLink = forwardRef((props, ref) => (
  <div
    ref={ref}
    style={{ flexGrow: 1 }}
  >
    <RouterLink {...props} />
  </div>
));

// React runtime PropTypes
export const AppMenuItemPropTypes = {
  title: PropTypes.string.isRequired,
  href: PropTypes.string,
  Icon: PropTypes.elementType,
  items: PropTypes.array,
}

const SidebarNav = props => {
  const { title, href, Icon, items = [] } = props
  const classes = useStyles()
  const isExpandable = items && items.length > 0
  const [open, setOpen] = React.useState(false)

  function handleClick() {
    setOpen(!open)
  }

  const MenuItemRoot = (
    <ListItem button component={CustomRouterLink} to={href} className={classes.menuItem} onClick={handleClick}>
      {/* Display an icon if any */}
      {!!Icon && (
        <ListItemIcon className={classes.menuItemIcon}>
          <Icon />
        </ListItemIcon>
      )}
      <ListItemText primary={title} inset={!Icon} />
    </ListItem>
  )

  const MenuItemRootWithChildren = (
    <ListItem button className={classes.menuItem} onClick={handleClick}>
      {/* Display an icon if any */}
      {!!Icon && (
        <ListItemIcon className={classes.menuItemIcon}>
          <Icon />
        </ListItemIcon>
      )}
      <ListItemText primary={title} inset={!Icon} />

      {/* Display the expand menu if the item has children */}
      {isExpandable && !open && <IconExpandMore />}
      {isExpandable && open && <IconExpandLess />}
    </ListItem>
  )

  const MenuItemChildren = isExpandable ? (
    <Collapse in={open} timeout="auto" unmountOnExit>
      <Divider />
      <List component="div" disablePadding>
        {items.map((item, index) => (
          <SidebarNav {...item} key={index} />
        ))}
      </List>
    </Collapse>
  ) : null

  return (
    <>
      {!isExpandable && MenuItemRoot}
      {isExpandable && MenuItemRootWithChildren}
      {MenuItemChildren}
    </>
  )
}

SidebarNav.propTypes = AppMenuItemPropTypes

const useStyles = makeStyles(theme =>
  createStyles({
    menuItem: {},
    menuItemIcon: {
      //color: '#97c05c',
    },
  }),
)

export default SidebarNav
