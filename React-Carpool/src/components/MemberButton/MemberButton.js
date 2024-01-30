import { Button } from '@mui/material';
import './css/MemberButton.css';

const MemberButton = (props) => {

    const handleClick = (text) => {
    
        // Call the parent component's method with the button text
        props.setResultsToName(text);
      }

    return (
        <Button sx={{ margin: 2 }} variant='outlined' size='large' onClick={() => handleClick(props.Text)} >{props.Text}</Button>
    );
}

export default MemberButton;