import React from 'react';
import { Route, Redirect } from 'react-router-dom';
import PropTypes from 'prop-types';

import { useSelector } from 'react-redux';

const RouteWithLayout = props => {
  const { layout: Layout, 
          component: Component, 
          isPrivate, 
          ...rest 
        } = props;

  const  signed  = useSelector(state => state.auth.signed);
  const pages = useSelector(state => state.user.profile);

  //console.log(pages?.pageProfiles)

  if (!signed && isPrivate) {
    return <Redirect to="/sign-in" />;
  }

  if (signed && !isPrivate) {
    return <Redirect to="/dashboard" />;
  }

  function isAuthorization(matchProps){   
    var authorization = false;
    var page = matchProps.match.url.substring(1);
    
    if(page === "dashboard" || page === "account" || page === "sign-in" || page === "sign-up"){
      authorization = true;
    }else{
      if(pages !== null){
        pages.pageProfiles.forEach(menu => {

          if (page === menu.page.href) {
            authorization = true;         
          } 

          if(menu.page.href === null){
            menu.page.pages.forEach(subMenu => {              
              if (page === subMenu.href) {
                authorization = true;         
              } 
            });
          }
        });
      }
    }
    return authorization;   
  }

  return (
    <Route
      {...rest}
      render={matchProps =>         
        isAuthorization(matchProps) ? (
        <Layout>
          <Component {...matchProps} />
        </Layout>
      ) : null}
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
