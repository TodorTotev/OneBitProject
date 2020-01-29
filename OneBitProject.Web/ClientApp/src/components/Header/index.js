import AppBar from "@material-ui/core/AppBar";
import Grid from "@material-ui/core/Grid";
import { makeStyles } from "@material-ui/core/styles";
import Toolbar from "@material-ui/core/Toolbar";
import React from "react";
import { Tabs } from "@material-ui/core";
import Tab from "@material-ui/core/Tab";

const useStyles = makeStyles({
  root: {
    flexGrow: 1
  },
  logo: {
    width: 135,
    height: 43.54
  }
});

const Header = () => {
  const classes = useStyles();
  const [value, setValue] = React.useState(0);

  return (
    <nav className={classes.root}>
      <AppBar position='static' color='default'>
        <Toolbar>
          <Grid justify={"space-between"} container>
            <Grid xs={1} item>
              <img
                className={classes.logo}
                src={
                  "https://upload.wikimedia.org/wikipedia/commons/d/d8/Billa-Logo.svg"
                }
                alt='Bosch Logo'
              />
            </Grid>
            <Grid xs={4} item>
              <Grid container justify={"center"}>
                  <Tab href='/' label={"Home"} />
                  <Tab href='/customers' label={"Customers"} />
              </Grid>
            </Grid>
            <Grid item xs={1} />
          </Grid>
        </Toolbar>
      </AppBar>
    </nav>
  );
};

export default Header;
