import axios from 'axios';

const api = axios.create({
  baseURL: 'http://localhost:51933/api/',
});

export default api;