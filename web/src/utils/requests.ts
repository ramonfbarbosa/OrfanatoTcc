import Axios from "axios";
import qs from "qs";

export const BASE_URL = process.env.REACT_APP_BACKEND_URL ?? 'https://localhost:7123/api';
export const TOKEN = process.env.REACT_APP_CLIENTE_ID ?? 'YXNkYXNmcWVncTN5MmUyN3kyNmV3eXdleXczdWk0cmV1aXJv';

type FormLoginData = {
    email: string;
    password: string;
}

type CreateData = {
    email: string;
    password: string;
}

export const requestBackendLogin = (loginData: FormLoginData) => {
    const headers = {
        'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8',
        Authorization: `Bearer ${TOKEN}`
    }

    const data = qs.stringify({
        ...loginData,
        grant_type: 'password'
    })
    return Axios({method: 'POST', baseURL: BASE_URL, url: '/auth/sign-in', data, headers})
}

export const requestBackendCreateOrphanage = (createData: CreateData) => {

    const data = qs.stringify({
        ...createData
    })
    return Axios({method: 'POST', baseURL: BASE_URL, url: '/orphanages/insert', data})
}