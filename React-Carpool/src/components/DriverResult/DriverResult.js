import React from 'react';
import { Typography, Box } from '@mui/material';

const DriverResult = (props) => {
    return (
        <Box sx={{ border: '1px solid black', backgroundColor: 'gray', borderRadius: '5px', p: 2, m: 2, display: 'inline-block' }}>
            <Typography variant='h5'>Driver: {props.Result.Driver}</Typography>
            <Typography variant='h5'>Passengers:</Typography>
            <Box sx={{ pl: 2 }}>
                {props.Result.Passengers.map((Passenger, index) => (
                    <React.Fragment key={Passenger.Name}>
                        <Typography variant='p'>{Passenger.Name}</Typography>
                        {index < props.Result.Passengers.length - 1 && <Typography variant='p'>, </Typography>}
                    </React.Fragment>
                ))}
            </Box>
            <Typography variant='h5'>Timestamp: {props.Result.Timestamp.slice(6, 8)}-{props.Result.Timestamp.slice(4, 6)}/{props.Result.Timestamp.slice(0, 4)}</Typography>
        </Box>
    );
};

export default DriverResult;