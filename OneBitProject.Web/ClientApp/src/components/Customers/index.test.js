import React from "react";
import renderer from "react-test-renderer";
import Customers from ".";

it("renders correctly", () => {
  const component = renderer.create(<Customers/>);
  let tree = component.toJSON();
  
  expect(tree).toMatchSnapshot()
});
