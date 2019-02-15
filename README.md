# Overview

The instructions to install and run the Client and Service applications are within the respective 'client' and 'services' folders. The application can be used by running the services in the Visual Studio debugger and the Angular Dev server.

## Technologies

1. ASP.NET Core 2.2
2. EF Core
3. OpenID using IdentityServer4. This is a configured template [https://www.nuget.org/packages/IdentityServer4.Templates/] adapted to include additional Claims and IProfile service. On client side oicd-client is used for implicit flow in Angular.
4. Angular 7
5. Boostrap. To avoid dependency on jQuery ng-bootstrap widgets have been used.

## Disclaimer
Being a demo, a number of aspects of the implementation are obviously neither complete or production ready. Only example validation has been added to the Angular Client and API (FluentValidation) and image upload has not been added. Furthermore, the approach taken is not the most optimal in terms of speed for the excercise e.g. I could have scaffolded an MVC App but I wanted to demonstrate an understanding of modern web applications.

## Unit tests
Token coverage has been added for the controllers to provide an idea of test approach using xUnit, Moq, and AutoFixture.

## Unit tests
Token coverage has been added for the controllers to provide an idea of test approach using xUnit, Moq, and AutoFixture.

## Usage

Two users have been set up:

1. Bob (username: bob, password: Pass123$). Bob is in admin and can publish, edit and delete articles
2. Alice (alice, password: Pass123$). Alice is an employee and can rate and comment on articles.

