import React from "react";
import renderer from "react-test-renderer";
import Orders from ".";

it("renders correctly", () => {
  const component = renderer.create(
      <Orders />
  );
  let tree = component.toJSON();

  expect(tree).toMatchSnapshot();
});
