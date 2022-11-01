import React, { ChangeEvent, FormEvent, useState } from "react";
import '../styles/pages/create-orphanage.css';
import { useForm } from "react-hook-form";
import Sidebar from "../components/SideBar";
import { requestBackendLogin, saveAuthData } from "../utils/requests";
import api from "../services/api";
import { useHistory } from "react-router-dom";
import swal from 'sweetalert';

const Auth = () => {
    const history = useHistory();
    const { register, handleSubmit, formState: {errors} } = useForm<LoginData>();

    type LoginData = {
        email: string;
        password: string;
    }

    const onSubmit = (loginData: LoginData) => {
        api
            .post("auth/sign-in", JSON.stringify(loginData))
            .then((res) => {
                saveAuthData(res.data);
                swal("Logado com sucesso!", "","success");
                history.push("/admin/toggle-orphanages")
            })
            .catch((error) => {
                console.log(error);
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
                                {...register("email", {
                                    required: 'Campo obrigatório',
                                    pattern: {
                                        value: /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$/i,
                                        message: 'Email inválido'
                                    }
                                })}
                                id="email"
                                name="email"
                            />
                            <div className="invalid-feedback d-block">{errors.email?.message}</div>
                        </div>
                        <div className="input-block">
                            <label htmlFor="password">Senha</label>
                            <input
                                {...register("password", {
                                    required: 'Campo obrigatório'
                                })}
                                id="password"
                                type="password"
                                name="password"
                            />
                            <div className="invalid-feedback d-block">{errors.password?.message}</div>
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