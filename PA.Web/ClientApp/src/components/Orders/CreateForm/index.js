import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import TextField from "@material-ui/core/TextField";
import MenuItem from "@material-ui/core/MenuItem";
import Button from "@material-ui/core/Button";
import orderService from "../../../services/order-service";
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
const CreateOrderForm = props => {
  const classes = useStyles();

  const [description, setDescription] = React.useState("");
  const [status, setStatus] = React.useState("Active");
  const [price, setPrice] = React.useState("");
  const [quantity, setQuantity] = React.useState("");

  const handleQuantity = event => {
    setQuantity(event.target.value);
  };

  const handlePrice = event => {
    setPrice(event.target.value);
  };

  const handleDescription = event => {
    setDescription(event.target.value);
  };

  const handleStatus = event => {
    setStatus(event.target.value);
  };

  const handleOnSubmit = e => {
      e.preventDefault();
      const obj = { description, quantity, price, status, customerId: props.match.params.id.substr(1) };
      console.log(obj)
      orderService.addOrder(obj)
      .then(() => {
          window.location.href=`orders/${props.match.params.id}`
      })

  };

  return (
    <div className={classes.root}>
      <h1>Create an order</h1>
      <form onSubmit={handleOnSubmit}>
        <TextField
          id='outlined-full-width'
          label='Description'
          style={{ margin: 8 }}
          placeholder='Please describe the order here'
          fullWidth
          onChange={handleDescription}
          margin='normal'
          InputLabelProps={{
            shrink: true
          }}
          variant='outlined'
        />
        <TextField
          id='outlined-full-width'
          label='Price'
          style={{ margin: 8 }}
          placeholder='Please set the order price here'
          fullWidth
          onChange={handlePrice}
          margin='normal'
          InputLabelProps={{
            shrink: true
          }}
          variant='outlined'
        />
        <TextField
          id='outlined-full-width'
          label='Quantity'
          style={{ margin: 8 }}
          placeholder='Please set order quantity here'
          fullWidth
          onChange={handleQuantity}
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
          value={status}
          onChange={handleStatus}
          helperText='Please select status'>
          {statuses.map(option => (
            <MenuItem key={option.value} value={option.value}>
              {option.label}
            </MenuItem>
          ))}
        </TextField>
        <Button type='submit' variant='contained'>
          Submit
        </Button>
      </form>
    </div>
  );
};

export default withRouter(CreateOrderForm);
