# Payment Gateway

This application provides the basic functionality of a payment gateway through API calls that a merchant can utilise to process payments with banks.

Notable features include:

- .NET Core 2.2 Web API
- EF Core's InMemory Provider for storage
- Swagger to test APIs
- Bank simulator app
- Health Check
- Lazy Caching

## Assumptions/Comments
- For the purposes of this challenge, a simple inmemory storage solution is used with EF Core instead of a full Microsoft SQL Server database, but on a production solution the latter would be the appropriate choice
- The bank simulator only provides a meaningful response to the gateway and does not include any business logic within the app to validate the request data
- Ideally, the credit card information should be encrypted and there should be proper authentication
- Masking of card number can also be done at database level using dynamic data masking.
- Versioning could have been implemented in production

## Requirements
- .NET Core 2.2

## Usage
Clone the repository to your local computer

Restore all packages by using the package manager console. Type the below cmd

-dotnet restore

Configure the solution to start multiple project in visual studio:
- PaymentGateWay
- PaymentGateWay.BankSimulator

## Launch

- Go to "https://localhost:44382/swagger/index.html" to open the Swagger UI, or use Postman to test APIs
- Two API calls available:
  - Create a new payment
  - View a previous payment
  
## Create New Payment  

> POST api/paymentdetail

JSON body:
{
  "cvv": 1114,
  "cardnumber": 1234544491234567,
  "currency": "EUR",
  "expiryMonth": "2008-12-25T00:00:00"
}

## View Previous Payment

> GET api/paymentdetail/{id}

e.g https://localhost:44382/api/paymentdetail/d3091fa1-5d06-44ef-a11e-e4316a57d0cc


## HealthCheck

- Go to "https://localhost:44382/health" to have status of database health
