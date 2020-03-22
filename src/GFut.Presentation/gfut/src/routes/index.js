import React from 'react';
import { Switch, Redirect } from 'react-router-dom';

import { RouteWithLayout } from '~/components';
import { Main as MainLayout, Minimal as MinimalLayout } from '~/layouts';

import {
  Dashboard as DashboardView,
  PlayerList as PlayerListView,
  Player as PlayerView,
  UserList as UserListView,
  TeamList as TeamListView,
  Team as TeamView,
  Account as AccountView,
  Settings as SettingsView,
  SignUp as SignUpView,
  SignIn as SignInView,
  NotFound as NotFoundView
} from '~/views';

const Routes = () => {
  return (
    <Switch>
      <Redirect
        exact
        from="/"
        to="/dashboard"
      />
      <RouteWithLayout
        component={DashboardView}
        exact
        layout={MainLayout}
        path="/dashboard"   
        isPrivate     
      />
      <RouteWithLayout
        component={UserListView}
        exact
        layout={MainLayout}
        path="/users"
        isPrivate
      />
      <RouteWithLayout
        component={TeamListView}
        exact
        layout={MainLayout}
        path="/teams"
        isPrivate
      />
      <RouteWithLayout
        component={TeamView}
        exact
        layout={MainLayout}
        path="/team"
        isPrivate
      />      
      <RouteWithLayout
        component={PlayerListView}
        exact
        layout={MainLayout}
        path="/players"
        isPrivate
      />
      <RouteWithLayout
        component={PlayerView}
        exact
        layout={MainLayout}
        path="/player"
        isPrivate
      />        
      <RouteWithLayout
        component={AccountView}
        exact
        layout={MainLayout}
        path="/account"
        isPrivate
      />
      <RouteWithLayout
        component={SettingsView}
        exact
        layout={MainLayout}
        path="/settings"
        isPrivate
      />
      <RouteWithLayout
        component={SignUpView}
        exact
        layout={MinimalLayout}
        path="/sign-up"
      />
      <RouteWithLayout
        component={SignInView}
        exact
        layout={MinimalLayout}
        path="/sign-in"
      />
      <RouteWithLayout
        component={NotFoundView}
        exact
        layout={MinimalLayout}
        path="/not-found"
      />
      <Redirect to="/not-found" />
    </Switch>
  );
};

export default Routes;
