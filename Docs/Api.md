# Buber Dinner API

- [Buber Dinner API](#buber-dinner-api)
  - [Auth](#auth)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Response](#login-response)

## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
  "firstName": "Fidan",
  "lastName": "Imanova",
  "email": "fidan.imanova.87@gmail.com",
  "password": "Fidan123"
}
```

#### Register Response

```js
200 OK
```

```json
{
  "id": "d89c2d9a-eb3e-4075-95ff-b920b55aa104",
  "firstName": "Fidan",
  "lastName": "Imanova",
  "email": "fidan.imanova.87@gmail.com",
  "token": "token"
}
```

### Login

```js
POST {{host}}/auth/login
```

#### Login Request

```json
{
  "email": "fidan.imanova.87@gmail.com",
  "password": "Fidan123"
}
```

```js
200 OK
```

#### Login Response

```json
{
  "id": "d89c2d9a-eb3e-4075-95ff-b920b55aa104",
  "firstName": "Fidan",
  "lastName": "Imanova",
  "email": "fidan.imanova.87@gmail.com",
  "token": "token"
}
```
