import React, { Component } from "react";

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <h1>Welcome!</h1>
        <p>This is Todor Totev's OneBit project assignment built with:</p>
        <ul>
          <li>
            <a href='https://get.asp.net/'>ASP.NET Core</a> and{" "}
            <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>
              C#
            </a>{" "}
            for cross-platform server-side code
          </li>
          <li>
            <a href='https://facebook.github.io/react/'>React</a> for
            client-side code
          </li>
          <li>
            <a href='http://https://material-ui.com/.com/'>Material UI</a> for
            layout and styling
          </li>
        </ul>
        <p>Used technologies for back-end:</p>
        <ul>
          <li>
            <strong>Entity Framework Core</strong>
          </li>
          <li>
            <strong>Following the CQRS pattern using MediatR</strong>
          </li>
          <li>
            <strong>Object to model mapping using AutoMapper</strong>
          </li>
          <li>
            <strong>Moq, Shouldly and xUnit for TDD Development</strong>
          </li>
        </ul>
        <p>Used technologies for front-end:</p>
        <ul>
          <li>
            <strong>ReactJS</strong>
          </li>
          <li>
            <strong>React Router for routing</strong>
          </li>
          <li>
            <strong>Material UI/Icons for styling</strong>
          </li>
          <li>
            <strong>Jest, React test renderer for TDD Development</strong>
          </li>
        </ul>
        <p>Database creation method:</p>
        <ul>
          <li>
            <strong>Code first:</strong> I have used the code-first method
            because it's easier for me to write the models and edit them when
            needed rather than configuring the database first. The relationships
            between the Customer and Order entities were created using the
            fluent API.
          </li>
        </ul>
        <p>There are five base layers in the project</p>
        <ul>
          <li>
            <strong>Domain Layer</strong>
            <ul>
              <li>
                Contains all entities, enums, exceptions, types and logic
                specific to the domain. The Entity Framework related classes are
                abstract, and should be considered in the same light as .NET
                Core. For testing, im using an InMemory provider.
              </li>
            </ul>
          </li>
          <li>
            <strong>Application Layer</strong>
            <ul>
              <li>
                Contains all application logic. It is dependent on the domain
                layer, but has no dependencies on any other layer or project.
                This layer defines interfaces that are implemented by outside
                layers.
              </li>
            </ul>
          </li>
          <li>
            <strong>Persistence layer</strong>
            <ul>
              <li>
                Contains database context, all configurations, migrations and
                data seed. It depends only on the application layer
              </li>
            </ul>
          </li>
          <li>
            <strong>Presentation Layer</strong>
            <ul>
              <li>
                Contains all presentation logic. There is client application
                based on React. Presentation layer depends only on application
                layer.
              </li>
            </ul>
          </li>
          <li>
            <strong>Common Layer</strong>
            <ul>
              <li>Contains all cross-cutting concerns.</li>
            </ul>
          </li>
        </ul>
      </div>
    );
  }
}
