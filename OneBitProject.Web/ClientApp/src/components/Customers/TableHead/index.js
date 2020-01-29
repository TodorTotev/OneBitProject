import React from "react";

import AddBoxIcon from "@material-ui/icons/AddBox";
import IconButton from "@material-ui/core/IconButton";
import TableHead from "@material-ui/core/TableHead";
import TableSortLabel from "@material-ui/core/TableSortLabel";
import TableRow from "@material-ui/core/TableRow";
import PropTypes from "prop-types";
import TableCell from "@material-ui/core/TableCell";

const headCells = [
    {
      id: "name",
      numeric: false,
      disablePadding: true,
      label: "Full Name"
    },
    { id: "gender", numeric: true, disablePadding: false, label: "Gender" },
    {
      id: "phoneNumber",
      numeric: true,
      disablePadding: false,
      label: "Phone Number"
    },
    { id: "status", numeric: true, disablePadding: false, label: "Status" },
    {
      id: "createdOn",
      numeric: true,
      disablePadding: false,
      label: "Created On"
    },
    { id: "actions", numeric: true, disablePadding: false, label: " Actions" }
  ];

const CustomTableHead = props => {
  const { classes, order, orderBy, onRequestSort } = props;
  const createSortHandler = property => event => {
    onRequestSort(event, property);
  };

  return (
    <TableHead>
      <TableRow>
        <TableCell padding='checkbox'>
          <IconButton onClick={() => console.log(row.id)} aria-label='delete'>
            <AddBoxIcon />
          </IconButton>
        </TableCell>
        {headCells.map(headCell => (
          <TableCell
            key={headCell.id}
            align={headCell.numeric ? "right" : "left"}
            padding={headCell.disablePadding ? "none" : "default"}
            sortDirection={orderBy === headCell.id ? order : false}>
            <TableSortLabel
              active={orderBy === headCell.id}
              direction={orderBy === headCell.id ? order : "asc"}
              onClick={createSortHandler(headCell.id)}>
              {headCell.label}
              {orderBy === headCell.id ? (
                <span className={classes.visuallyHidden}>
                  {order === "desc" ? "sorted descending" : "sorted ascending"}
                </span>
              ) : null}
            </TableSortLabel>
          </TableCell>
        ))}
      </TableRow>
    </TableHead>
  );
};

CustomTableHead.propTypes = {
  classes: PropTypes.object.isRequired,
  onRequestSort: PropTypes.func.isRequired,
  order: PropTypes.oneOf(["asc", "desc"]).isRequired,
  orderBy: PropTypes.string.isRequired,
  rowCount: PropTypes.number.isRequired
};

export default CustomTableHead;
