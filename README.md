# JwtPractice
Create a JWT (JSON Web Token) authentication system by following the steps below.
1. Creating a User Model

Create a User class. This class should have the following properties:

Id (int, key)

Email (string, unique)

Password (string)

2. Database Settings

Create a DbContext class using Entity Framework and add the User model you defined above to this class.

3. Creating a JWT

Perform the following operations:

Create an AuthController class.

Write a Login method to authenticate the user. This method should receive an Email and Password and create a JWT if the user is a valid user.

The generated JWT should be returned to the user.

4. Validating the JWT

Make the necessary settings so that the JWT can be validated for every request. Use an Authorize attribute to validate the JWT for requests.
