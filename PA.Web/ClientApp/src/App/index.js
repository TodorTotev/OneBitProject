import React from "react";

// Main
import { Route, Switch } from "react-router";
import { Layout } from "../components/Layout";
import { Home } from "../components/Home";

// Customers
import Customers from "../components/Customers/";
import CreateCustomer from "../components/Customers/CreateForm";
import EditCustomer from "../components/Customers/EditForm";

// Orders
import Orders from "../components/Orders";
import CreateOrder from "../components/Orders/CreateForm"
import EditOrder from "../components/Orders/EditForm"

import NotFoundPage from "../components/NotFound";

const App = () => {
  return (
    <Layout>
      <Switch>
      <Route exact path='/' component={Home} />
      <Route exact path='/customers' component={Customers} />
      <Route exact path='/createCustomer' component={CreateCustomer} />
      <Route exact path='/editCustomer/:id' component={EditCustomer} />
      <Route exact path='/orders/:id' component={Orders} />
      <Route exact path='/createOrder/:id' component={CreateOrder}/>
      <Route exact path='/editOrder/:id' component={EditOrder}/>
      <Route component={NotFoundPage}/>
      </Switch>
    </Layout>
  );
};

export default App;
