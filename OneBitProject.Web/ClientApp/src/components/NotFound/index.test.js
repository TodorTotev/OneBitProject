import React from "react";
import renderer from "react-test-renderer";
import NotFoundPage from ".";
import { BrowserRouter as Router } from "react-router-dom";

it("renders correctly", () => {
  const component = renderer.create(
    <Router>
      <NotFoundPage />
    </Router>
  );
  let tree = component.toJSON();

  expect(tree).toMatchSnapshot();
});
