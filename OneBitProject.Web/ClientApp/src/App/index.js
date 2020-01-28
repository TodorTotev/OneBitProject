import React from "react";
import { Route } from "react-router";
import { Layout } from "../components/Layout";
import { Home } from "../components/Home";
import Customers from "../components/Customers";

const App = () => {
  return (
    <Layout>
      <Route exact path='/' component={Home} />
      <Route exact path='/customers' component={Customers} />
    </Layout>
  );
};

export default App;
