import React, { useState } from 'react';
import MemberButton from "../MemberButton/MemberButton";
import DriverResult from '../DriverResult/DriverResult';
import { Typography } from '@mui/material';
import Data from '../../carpools.json';
import './css/App.css';

const App = () => {

    const carpoolMembers = [ { initials: 'MR' }, { initials: 'JL' }, { initials: 'AC' }, { initials: 'CJ' } ];
    const [results, setResults] = useState([]);
    const [tripsAsPassenger, setTripsAsPassenger] = useState([]);
    const [newestDriverTimestamp, setNewestDriverTimestamp] = useState(null);
    const [newestPassengerTimestamp, setNewestPassengerTimestamp] = useState(null);

    const setResultsToName = (nameOnButton) => {
        const newResults = [];
        const newResultsAsPassenger = [];
        let newestDriverDate = null;
        let newestPassengerDate = null;

        Data.CarPoolEvents.map((Member) => {
            if (Member.Driver === nameOnButton) {
                newResults.push(Member);
            }
            Member.Passengers.forEach((Passenger) => {
                if (Passenger.Name === nameOnButton) {
                    newResultsAsPassenger.push(Member);
                }
            });
        });

        setResults(newResults);
        setTripsAsPassenger(newResultsAsPassenger);
        setNewestDriverTimestamp(newestDriverDate);
        setNewestPassengerTimestamp(newestPassengerDate);
    };

    const convertTimestamp = (timestamp) => {
        const year = timestamp.slice(0, 4);
        const month = timestamp.slice(4, 6);
        const day = timestamp.slice(6, 8);
        return `${day}-${month}/${year}`;
    };

    return (
        <main>
            { 
                carpoolMembers.length === 0 ? (
                    <Typography variant='h4'>This carpool doesn't exist.</Typography>
                ) : (
                    <>
                        <Typography variant='h2' sx={{ fontWeight: 600 }}>Carpool Overview</Typography>
                        <Typography variant='h4'>Welcome to the carpool overview app!<br />Please select a member to view the history:</Typography>
                        {
                            carpoolMembers.map((member) => (
                                <MemberButton key={member.initials} variant='outlined' Text={member.initials} setResultsToName={setResultsToName}/>
                            ))
                        }
                        { results.length > 0 ? (
                            <>
                                <Typography variant='h4'>Results:</Typography>
                                <Typography variant='h3'>As driver:</Typography>
                                {
                                    results.map((result, index) => {
                                        return (
                                            <>
                                                {result.Timestamp > newestDriverTimestamp ? setNewestDriverTimestamp(result.Timestamp) : null }
                                                <DriverResult key={index} Result={result} />
                                            </>
                                        )
                                    })
                                }
                                {newestDriverTimestamp && (
                                    <>
                                        <Typography variant='h4'>Last time as the driver: {convertTimestamp(newestDriverTimestamp)}</Typography>
                                        <Typography variant='h4' sx={{ marginBottom: 6 }}>Number of trips: {results.length}</Typography>
                                    </>
                                )}
                                <Typography variant='h3'>As passenger:</Typography>
                                {
                                    tripsAsPassenger.map((result, index) => {
                                        return (
                                            <>
                                                {result.Timestamp > newestPassengerTimestamp ? setNewestPassengerTimestamp(result.Timestamp) : null }
                                                <DriverResult key={index} Result={result} />
                                            </>
                                        )
                                    })
                                }
                                {newestPassengerTimestamp && (
                                    <>
                                        <Typography variant='h4'>Last time as a passenger: {convertTimestamp(newestPassengerTimestamp)}</Typography>
                                        <Typography variant='h4' sx={{ marginBottom: 6 }}>Number of trips: {tripsAsPassenger.length}</Typography>
                                    </>
                                )}
                            </>
                        ) : (
                            <div></div>
                        )}
                    </>
                )
            }
        </main>
    );
}

export default App;