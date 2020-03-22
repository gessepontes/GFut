import React from 'react';
import { Route, Redirect } from 'react-router-dom';
import PropTypes from 'prop-types';
import { store } from '~/store';

const RouteWithLayout = props => {
  const { layout: Layout, 
          component: Component, 
          isPrivate, 
          ...rest 
        } = props;

  const { signed } = store.getState().auth;

  if (!signed && isPrivate) {
    return <Redirect to="/sign-in" />;
  }

  if (signed && !isPrivate) {
    return <Redirect to="/dashboard" />;
  }

  return (
    <Route
      {...rest}
      render={matchProps => (
        <Layout>
          <Component {...matchProps} />
        </Layout>
      )}
    />
  );
};

RouteWithLayout.propTypes = {
  isPrivate: PropTypes.bool,
  component: PropTypes.any.isRequired,
  layout: PropTypes.any.isRequired,
  path: PropTypes.string
};

export default RouteWithLayout;
