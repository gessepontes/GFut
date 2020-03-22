import { createStore, compose, applyMiddleware } from 'redux';

export default (reducers, middlewares) => {
  // const enhancer =
  //   process.env.NODE_ENV === 'development'
  //     ? compose(
  //         console.tron.createEnhancer(),
  //         applyMiddleware(...middlewares)
  //       )
  //     : applyMiddleware(...middlewares);

      const composeEnhancers =
        typeof window === 'object' &&
        window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ ?   
          window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__({
            // Specify extension’s options like name, actionsBlacklist, actionsCreators, serialize...
          }) : compose;

      const enhancer = composeEnhancers(
        applyMiddleware(...middlewares),
        // other store enhancers if any
      );  

  return createStore(reducers, enhancer);
};