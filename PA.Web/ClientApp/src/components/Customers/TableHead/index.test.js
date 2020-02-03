import React from "react";
import renderer from "react-test-renderer";
import TableHead from "../TableHead/";

it("renders correctly", () => {
  const component = renderer.create(<TableHead/>);
  let tree = component.toJSON();
  
  expect(tree).toMatchSnapshot()
});
