import React from "react";

const User = ( { user: { name, mail, gender } } ) => {
    return (
        <ul>
            <li>Name: {name}</li>
            <li>Mail: {mail}</li>
            <li>Gender: 
                {
                    //Sets the first letter to uppercase in the gender attribute, since it's all lowercase by default.
                    " " + gender.charAt(0).toUpperCase() + gender.slice(1)
                }
            </li>
        </ul>
    );
}

export default User;