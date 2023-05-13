import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './components/App/App';
//Imports the prerequisites to make custom themes.
import { ThemeProvider, createTheme } from '@mui/material';

const root = ReactDOM.createRoot(document.querySelector('#root'));

//Creates a new theme called lookupapp and removing border radius on it.
const lookupapp = createTheme({
  shape: {
    borderRadius: "0px"
  }
});

root.render(
  <React.StrictMode>
    <ThemeProvider theme={lookupapp}>
      <App />
    </ThemeProvider>
  </React.StrictMode>
);