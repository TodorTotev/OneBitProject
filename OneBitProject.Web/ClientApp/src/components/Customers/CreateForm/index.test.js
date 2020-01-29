import React from "react";
import renderer from "react-test-renderer";
import createCustomerForm from "../CreateForm";

it("renders correctly", () => {
  const component = renderer.create(<createCustomerForm/>);
  let tree = component.toJSON();
  
  expect(tree).toMatchSnapshot()
});
