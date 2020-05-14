import React from 'react';

interface IProps { }
interface IState { }
export default class App extends React.Component<IProps, IState> {
    constructor(props: IProps) {
        super(props);
    }

    render() {
        return (
            <div className="container-fluid full">
                <form className="col-12 col-sm-4 card bg-light mx-auto my-auto" >
                    <h3 className="mt-3">Bem vindo de volta!</h3>
                    <div className="form-group">
                        <label>Usuário</label>
                        <input type="email" className="form-control" placeholder="Digite o usuário" />
                    </div>
                    <div className="form-group">
                        <label>Senha</label>
                        <input type="password" className="form-control" placeholder="Digite a senha" />
                    </div>
                    <button type="submit" className="btn btn-primary btn-block mb-3">Submit</button>
                </form>
            </div>
        )
    }
}