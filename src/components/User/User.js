import React from "react";

const User = ( { user: { name, mail, gender } } ) => {
    return (
        <ul>
            <li>Name: {name}</li>
            <li>Mail: {mail}</li>
            <li>Gender: {gender}</li>
        </ul>
    );
}

export default User;