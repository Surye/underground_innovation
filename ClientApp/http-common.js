import axios from 'axios';

export const HTTP = axios.create({
  baseURL: 'http://localhost:61722',
  headers: {
    Authorization: 'Bearer {token}'
  }
})
