import axios from 'axios';

const api = axios.create({
    baseURL: "https://localhost:7123/api/Orphanages"
});

export default api;