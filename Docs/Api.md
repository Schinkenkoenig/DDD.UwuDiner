# UwU Diner API

- [Uwu Diner](#uwu-diner-api)
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

```js
{
  "firstName": "Arthur",
  "lastName": "Leywin",
  "email": "art@quad.moe",
  "password": "vrtradumb"
}
```

#### Register Response

```js
{
  "id": "",
  "firstName": "Arthur",
  "lastName": "Leywin",
  "email": "art@quad.moe",
  "token": "eyJhb..z9dqcnXoY"
}
```

### Login

#### Login Request

```js
{
  "email": "art@quad.moe",
  "password": "vrtradumb"
}
```

#### Login Response

```js
{
  "id": "",
  "firstName": "Arthur",
  "lastName": "Leywin",
  "email": "art@quad.moe",
  "token": "eyJhb..z9dqcnXoY"
}
```
