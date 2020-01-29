import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import TextField from "@material-ui/core/TextField";
import MenuItem from "@material-ui/core/MenuItem";
import Button from "@material-ui/core/Button";
import userService from "../../../services/user-service";
import { withRouter } from "react-router-dom";

const useStyles = makeStyles(theme => ({
  root: {
    display: "flex",
    flexWrap: "wrap"
  },
  textField: {
    marginLeft: theme.spacing(1),
    marginRight: theme.spacing(1),
    width: 200
  }
}));

const genders = [
  {
    value: "Male",
    label: "Male"
  },
  {
    value: "Female",
    label: "Female"
  }
];
const statuses = [
  {
    value: "Active",
    label: "Active"
  },
  {
    value: "Inactive",
    label: "Inactive"
  }
];
const EditCustomerForm = (props) => {
  const classes = useStyles();

  const [id, setId] = React.useState();
  const [gender, setGender] = React.useState("Male");
  const [status, setStatus] = React.useState("Active");
  const [firstName, setFirstName] = React.useState("");
  const [lastName, setLastName] = React.useState("");
  const [phoneNumber, setPhoneNumber] = React.useState("");

  React.useEffect(() => {
    userService.getCustomer(props.match.params.id).then(data => {
      setId(data.id);
      setGender(data.gender);
      setStatus(data.status);
      setFirstName(data.firstName);
      setLastName(data.lastName);
      setPhoneNumber(data.phoneNumber);
    });
  }, []);

  function switchStatus() {
    if (status !== "Deleted") {
      return (
        <TextField
          id='outlined-full-width'
          select
          label='Select'
          style={{ margin: 8 }}
          fullWidth
          margin='normal'
          value={status}
          onChange={handleStatus}
          helperText='Please select status'>
          {statuses.map(option => (
            <MenuItem key={option.value} value={option.value}>
              {option.label}
            </MenuItem>
          ))}
        </TextField>
      );
    } else {
      return (
        <TextField
          disabled
          id='standard-disabled'
          label='Select'
          style={{ margin: 8 }}
          fullWidth
          margin='normal'
          value={"Deleted"}
          onChange={handleStatus}
          helperText='You cannot undelete this customer'></TextField>
      );
    }
  }

  const handlePhoneNumber = event => {
    setPhoneNumber(event.target.value);
  };

  const handleLastName = event => {
    setLastName(event.target.value);
  };

  const handleFirstName = event => {
    setFirstName(event.target.value);
  };

  const handleGender = event => {
    setGender(event.target.value);
  };

  const handleStatus = event => {
    setStatus(event.target.value);
  };

  const handleOnSubmit = () => {
    const obj = { id, firstName, lastName, phoneNumber, gender, status };
    userService.updateCustomer(obj);
    props.history.push("/customers")
  };

  return (
    <div className={classes.root}>
      <h1>Edit customer</h1>
      <form onSubmit={handleOnSubmit}>
        <TextField
          id='outlined-full-width'
          label='First Name'
          style={{ margin: 8 }}
          value={firstName}
          fullWidth
          onChange={handleFirstName}
          margin='normal'
          InputLabelProps={{
            shrink: true
          }}
          variant='outlined'
        />
        <TextField
          id='outlined-full-width'
          label='Last Name'
          style={{ margin: 8 }}
          value={lastName}
          fullWidth
          onChange={handleLastName}
          margin='normal'
          InputLabelProps={{
            shrink: true
          }}
          variant='outlined'
        />
        <TextField
          id='outlined-full-width'
          label='Phone Number'
          style={{ margin: 8 }}
          value={phoneNumber}
          fullWidth
          onChange={handlePhoneNumber}
          margin='normal'
          InputLabelProps={{
            shrink: true
          }}
          variant='outlined'
        />
        <TextField
          id='outlined-full-width'
          select
          label='Select'
          style={{ margin: 8 }}
          fullWidth
          margin='normal'
          value={gender}
          onChange={handleGender}
          helperText='Please select gender'>
          {genders.map(option => (
            <MenuItem key={option.value} value={option.value}>
              {option.label}
            </MenuItem>
          ))}
        </TextField>
        {switchStatus()}
        <Button type='submit' variant='contained'>
          Submit
        </Button>
      </form>
    </div>
  );
}

export default withRouter(EditCustomerForm)