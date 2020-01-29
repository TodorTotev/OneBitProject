import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import Table from "@material-ui/core/Table";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableContainer from "@material-ui/core/TableContainer";
import TablePagination from "@material-ui/core/TablePagination";
import TableRow from "@material-ui/core/TableRow";
import Paper from "@material-ui/core/Paper";
import IconButton from "@material-ui/core/IconButton";
import DeleteIcon from "@material-ui/icons/Delete";
import EditIcon from "@material-ui/icons/Edit";
import CustomTableHead from "./TableHead";
import { useHistory } from "react-router-dom";
import orderService from "../../services/order-service";
import userService from "../../services/user-service";

function desc(a, b, orderBy) {
  if (b[orderBy] < a[orderBy]) {
    return -1;
  }
  if (b[orderBy] > a[orderBy]) {
    return 1;
  }
  return 0;
}

function stableSort(array, cmp) {
  const stabilizedThis = array.map((el, index) => [el, index]);
  stabilizedThis.sort((a, b) => {
    const order = cmp(a[0], b[0]);
    if (order !== 0) return order;
    return a[1] - b[1];
  });
  return stabilizedThis.map(el => el[0]);
}

function getSorting(order, orderBy) {
  return order === "desc"
    ? (a, b) => desc(a, b, orderBy)
    : (a, b) => -desc(a, b, orderBy);
}

const useStyles = makeStyles(theme => ({
  root: {
    width: "100%"
  },
  paper: {
    width: "100%",
    marginBottom: theme.spacing(2)
  },
  table: {
    minWidth: 750
  },
  visuallyHidden: {
    border: 0,
    clip: "rect(0 0 0 0)",
    height: 1,
    margin: -1,
    overflow: "hidden",
    padding: 0,
    position: "absolute",
    top: 20,
    width: 1
  }
}));

const Orders = props => {
  const classes = useStyles();
  const [state, setState] = React.useState();
  const [order, setOrder] = React.useState("asc");
  const [orderBy, setOrderBy] = React.useState("description");
  const [page, setPage] = React.useState(0);
  const [rowsPerPage, setRowsPerPage] = React.useState(5);
  const [rows, setRows] = React.useState([]);
  const [customer, setCustomer] = React.useState("");

  React.useEffect(() => {
    orderService.getOrders(props.match.params.id.substr(1)).then(data => {
      if (!data.orders) {
        window.location.href = "/404";
      }
      setRows(data.orders);
      setState("1")
    });

    userService.getCustomer(props.match.params.id.substr(1)).then(data => {
      setCustomer(`${data.firstName} ${data.lastName}`);
    });
  }, []);

  const handleRequestSort = (event, property) => {
    const isAsc = orderBy === property && order === "asc";
    setOrder(isAsc ? "desc" : "asc");
    setOrderBy(property);
  };

  const handleChangePage = (event, newPage) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = event => {
    setRowsPerPage(parseInt(event.target.value, 10));
    setPage(0);
  };

  const handleDelete = id => {
    if (window.confirm("Are you sure you want to delete this item?")) {
      orderService.deleteOrder(id);
    }
    window.location.reload();
  };

  const handleEdit = id => {
    console.log(id);
    props.history.push(`/editOrder/:${id}`);
  };

  const emptyRows =
    rowsPerPage - Math.min(rowsPerPage, rows.length - page * rowsPerPage);

    if (state === "1"){
        <div className={classes.root}>
      <Paper className={classes.paper}>
        <h1>Purchase orders for {customer}</h1>
        <TableContainer>
          <Table
            className={classes.table}
            aria-labelledby='tableTitle'
            aria-label='enhanced table'>
            <CustomTableHead
              classes={classes}
              order={order}
              orderBy={orderBy}
              onRequestSort={handleRequestSort}
              rowCount={rows.length}
              id={props.match.params.id}
            />
            <TableBody>
              {stableSort(rows, getSorting(order, orderBy))
                .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
                .map((row, index) => {
                  return (
                    <TableRow hover tabIndex={-1} key={row.createdOn}>
                      <TableCell></TableCell>
                      <TableCell
                        component='th'
                        id={row.createdOn}
                        scope='row'
                        padding='none'>
                        {row.description}
                      </TableCell>
                      <TableCell align='right'>{row.price}</TableCell>
                      <TableCell align='right'>{row.quantity}</TableCell>
                      <TableCell align='right'>{row.totalAmount}</TableCell>
                      <TableCell align='right'>{row.status}</TableCell>
                      <TableCell align='right'>
                        {row.createdOn.substr(0, 10)}
                      </TableCell>
                      <TableCell align='right'>
                        <IconButton
                          onClick={() => handleEdit(row.id)}
                          aria-label='delete'>
                          <EditIcon />
                        </IconButton>
                        <IconButton
                          onClick={() => handleDelete(row.id)}
                          aria-label='delete'>
                          <DeleteIcon />
                        </IconButton>
                      </TableCell>
                    </TableRow>
                  );
                })}
              {emptyRows > 0 && (
                <TableRow style={{ height: 53 * emptyRows }}>
                  <TableCell colSpan={6} />
                </TableRow>
              )}
            </TableBody>
          </Table>
        </TableContainer>
        <TablePagination
          rowsPerPageOptions={[5, 10, 25]}
          component='div'
          count={rows.length}
          rowsPerPage={rowsPerPage}
          page={page}
          onChangePage={handleChangePage}
          onChangeRowsPerPage={handleChangeRowsPerPage}
        />
      </Paper>
    </div>
    } else
    {
        return <h1>Loading...</h1>
    }
};

export default Orders;
