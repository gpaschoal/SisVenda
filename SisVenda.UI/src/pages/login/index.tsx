import React from 'react';

// import { Container } from './styles';

interface IProps { }
interface IState { }
export default class App extends React.Component<IProps, IState> {
    constructor(props: IProps) {
        super(props);
    }

    render(){
        return (<h1>Login</h1>);
    }
}