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
const EditOrderForm = props => {
  const classes = useStyles();

  const [state, setState] = React.useState();
  const [id, setId] = React.useState();
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

  React.useEffect(() => {
    orderService.getOrder(props.match.params.id.substr(1)).then(data => {
        if (!data.id){
            return window.location.href="404"
        }
        setId(data.id);
        setDescription(data.description);
        setStatus(data.status);
        setPrice(data.price);
        setQuantity(data.quantity);
        setState("1")
    })
  }, []);

  const handleOnSubmit = () => {
      console.log("asd")
    const obj = { id, description, status, price, quantity };
    orderService.updateOrder(obj)
    .then(() => {
        console.log("pesho")
    })
    props.history.push(`orders/:${id}`);
  };

  if (state === "1"){
      return (
        <div className={classes.root}>
        <h1>Edit customer order</h1>
        <form onSubmit={handleOnSubmit}>
          <TextField
            id='description'
            label='Description'
            style={{ margin: 8 }}
            value={description}
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
            id='price'
            label='Price'
            style={{ margin: 8 }}
            value={price}
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
            id='quantity'
            label='Quantity'
            style={{ margin: 8 }}
            value={quantity}
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
      )
  } else {
      return <h1>Loading...</h1>
  }
};

export default withRouter(EditOrderForm);
