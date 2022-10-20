import React, { ChangeEvent, FormEvent, useState } from "react";
import { useHistory } from "react-router-dom";
import '../styles/pages/create-orphanage.css';
import { useForm } from "react-hook-form";
import Sidebar from "../components/SideBar";
import { requestBackendLogin } from "../utils/requests";

const Auth = () => {

    const { register, handleSubmit } = useForm<LoginData>();

    type LoginData = {
        email: string;
        password: string;
    }

    // async function handleSubmit(event: FormEvent) {
    //     event.preventDefault();

    //     console.log(credentials)
    //     await api.post('auth/sign-in', credentials)
    //         .then(res => {
    //             setEmail(res.data)
    //         })
    //     alert('Logado com sucesso!');
    //     history.push('auth/toggle-orphanages');
    // }

    const onSubmit = (loginData: LoginData) => {
        requestBackendLogin(loginData)
        .then(res => {
            console.log('SUCESSO', res)
        })
        .catch(erro => {
            console.log('erro', erro)
        });
    };

    return (
        <div id="page-create-orphanage">
            <main>
                <Sidebar />
                <form onSubmit={handleSubmit(onSubmit)} className="create-orphanage-form">
                    <fieldset>
                        <div className="input-block">
                            <label htmlFor="email">Email</label>
                            <input
                                {...register("email")}
                                id="email"
                                name="email"
                            />
                        </div>
                        <div className="input-block">
                            <label htmlFor="password">Senha</label>
                            <input
                                {...register("password")}
                                id="password"
                                type="password"
                                name="password"
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