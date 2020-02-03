import React from "react";
import renderer from "react-test-renderer";
import EditForm from ".";
import { BrowserRouter as Router } from "react-router-dom";

it("renders correctly", () => {
  const component = renderer.create(
    <Router>
      <EditForm />
    </Router>
  );
  let tree = component.toJSON();

  expect(tree).toMatchSnapshot();
});
