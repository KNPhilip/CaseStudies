import React, { useState } from 'react';
import './App.css';
import { Typography, TextField, Button } from '@mui/material';
import User from '../User/User';

function App() {
  return (
    <>
      <Typography variant='h2'>Lookup App</Typography>

      <div className='search'>
        <TextField 
          id="input"
          label="Enter name"
          variant="outlined"
        />

        <Button
          variant='contained'
        >Search</Button>
      </div>

      {
        
      }
    </>
  );
}

export default App;