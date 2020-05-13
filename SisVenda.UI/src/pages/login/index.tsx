import React from 'react';
import './index.scss'

interface IProps { }
interface IState { }
export default class App extends React.Component<IProps, IState> {
    constructor(props: IProps) {
        super(props);
    }

    render() {
        return (
            <div className="login-container">
                <form>
                    <label className="title" >Acesso ao sistema</label>
                    <label className="label"> Usuário: </label>
                    <input placeholder="Digite o usuário..." />
                    <label className="label"> Senha: </label>
                    <input placeholder="Digite a senha..." type="password" />
                    <button type="submit">Enviar</button>
                </form>
            </div>
        )
    }
}