import React, { ChangeEvent, FormEvent, useState } from "react";
import { useHistory } from "react-router-dom";
import Sidebar from "../components/SideBar";
import api from "../services/api";
import '../styles/pages/create-orphanage.css';

type SignInRequest = {
    email: string;
    password: string;
} 

const Auth = (signInRequest: SignInRequest) => {
    const history = useHistory();

    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const credentials = {
        email: email,
        password: password
    }

    async function handleSubmit(event: FormEvent) {
        event.preventDefault();

        console.log(credentials)
        await api.post('/sign-in', credentials)
            .then(res => {
                // setSignIn(res.data)
            });
        alert('Logado com sucesso!');
        history.push('auth/toggle-orphanages');
    }

    return (
        <div id="page-create-orphanage">
            <main>
                <Sidebar />
                <form onSubmit={handleSubmit} className="create-orphanage-form">
                    <fieldset>
                        <div className="input-block">
                            <label htmlFor="name">Email</label>
                            <input
                                id="email"
                                value={email}
                                onChange={event => setEmail(event.target.value)}
                            />
                        </div>
                        <div className="input-block">
                            <label htmlFor="password">Senha</label>
                            <input
                                id="password"
                                value={password}
                                onChange={event => setPassword(event.target.value)}
                            />
                        </div>

                        <button className="confirm-button" type="submit">
                            Confirmar
                        </button>
                    </fieldset>
                </form>
            </main >
        </div >

        
    );
}

export default Auth;