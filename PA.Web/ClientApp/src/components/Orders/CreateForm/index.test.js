import React from "react";
import renderer from "react-test-renderer";
import CreateForm from ".";
import { BrowserRouter as Router } from "react-router-dom";

it("renders correctly", () => {
  const component = renderer.create(
    <Router>
      <CreateForm />
    </Router>
  );
  let tree = component.toJSON();

  expect(tree).toMatchSnapshot();
});
