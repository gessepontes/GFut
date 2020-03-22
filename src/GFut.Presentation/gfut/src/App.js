import React from 'react';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

import { ThemeProvider } from '@material-ui/styles';
import { PersistGate } from 'redux-persist/integration/react';
import { Provider } from 'react-redux';
import { Router } from 'react-router-dom';

import '~/config/ReactotronConfig';
import '~/assets/css/index.css';

import Routes from './routes';
import history from './services/history';
import theme from './theme';
import validate from 'validate.js';
import validators from './common/validators';

import { store, persistor } from './store';

validate.validators = {
  ...validate.validators,
  ...validators
};

function App() {
  return (
    <Provider store={store}>
      <PersistGate persistor={persistor}>
      <ThemeProvider theme={theme}>
        <Router history={history}>
          <Routes />
          <ToastContainer autoClose={3000} />
        </Router>
        </ThemeProvider>
      </PersistGate>
    </Provider>
  );
}

export default App;