import React, { useState } from 'react';
import './App.css';
import { Typography, TextField, Button } from '@mui/material';
import User from '../User/User';

function App() {

  //useState for the current Search Term. Used to find the results from the API later.
  const [searchTerm, setSearchTerm] = useState('');
  //Another useState for the users (results) from the API.
  const [users, setUsers] = useState([]);
  //Is true or false depending on the length of the current search. (This is used to enable/disable searching)
  const isDisabled = searchTerm.length <= 3;

  return (
    <>
      <Typography variant='h2'>Lookup App</Typography>

      <div className='search'>
        <TextField 
          id="input"
          label="Enter name"
          variant="outlined"
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
        />

        <Button
          variant='contained'
          disabled={isDisabled}
        >Search</Button>
      </div>

      {
        users?.length > 0 
        ? (
          <div>
            <Typography variant='p'>Results</Typography>
            {
              //If results is greater than 0, map through all the users and display them (This happens through the User component)
              users.map((user) => (
                <User user={user} key={user.id} />
              ))
            }
          </div>

        ) : (
          //Displays if there was no found users.
          <div>
            <Typography variant='p'>No users found..</Typography>
          </div>
        )
      }
    </>
  );
}

export default App;