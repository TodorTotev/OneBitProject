import React from "react";
import renderer from "react-test-renderer";
import EditCustomerForm from "."

it("renders correctly", () => {
  const component = renderer.create(<EditCustomerForm/>);
  let tree = component.toJSON();
  
  expect(tree).toMatchSnapshot()
});
