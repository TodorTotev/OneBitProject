import React from "react";
import renderer from "react-test-renderer";
import createCustomerForm from "../CreateForm";
import { BrowserRouter as Router } from "react-router-dom";

it("renders correctly", () => {
  const component = renderer.create(
    <Router>
      <createCustomerForm />
    </Router>
  );
  let tree = component.toJSON();

  expect(tree).toMatchSnapshot();
});
