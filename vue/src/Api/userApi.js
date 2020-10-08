import { getJson, postJson } from './baseApi.js'

export function getAllusers () {
  return getJson({
    url: 'https://localhost:44331/api/Users'
  })
}

export function getUser ({ userId }) {
  return getJson({
    url: 'https://localhost:44331/api/Users/' + userId,
    data: {
      id: userId
    }
  })
}

export function createUser ({ userName, password, email }) {
  return postJson({
    url: 'https://localhost:44331/api/Users',
    data: {
      userName: userName,
      password: password,
      email: email
    }
  })
}

