import React, { ChangeEvent, FormEvent, useState } from "react";
import { useHistory } from "react-router-dom";
import Sidebar from "../components/SideBar";
import api from "../services/api";
import '../styles/pages/create-orphanage.css';
import { SignInRequest } from "../Types/SignInRequest";


export default function SignIn() {
    const history = useHistory();

    const [signIn, setSignIn] = useState<SignInRequest>();
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    async function handleSubmit(event: FormEvent) {
        event.preventDefault();

        const data = new FormData();

        data.append('email', email);
        data.append('password', password);

        await api.post('/sign-in', data)
            .then(res => {
                setSignIn(res.data)
            });
        alert('Logado com sucesso!');
        history.push('/app');  //trocar
    }

    return (
        <div id="page-create-orphanage">
            <Sidebar />

            <main>
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
