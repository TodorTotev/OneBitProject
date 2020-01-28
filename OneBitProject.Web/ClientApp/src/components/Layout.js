import React, { Component } from "react";
import { Container } from "reactstrap";
import Header from "./Header";

export class Layout extends Component {
  static displayName = Layout.name;

  render() {
    return (
      <div>
        <head>
          <link
            rel='stylesheet'
            href='https://fonts.googleapis.com/icon?family=Material+Icons'
          />
        </head>
        <Header />
        <Container>{this.props.children}</Container>
      </div>
    );
  }
}
