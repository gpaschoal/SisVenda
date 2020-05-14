import React from 'react';
import Header from './header';
import Menu from './menu';
import Footer from './footer';

interface IProps { }
interface IState { }
export default class App extends React.Component<IProps, IState> {
    constructor(props: IProps) {
        super(props);
    }

    render() {
        return (
            <>
                <div className="h-100 bg-dark text-light">
                    <Header />
                    <Menu />
                    {this.props.children}
                    <Footer />
                </div>
            </>);
    }
}