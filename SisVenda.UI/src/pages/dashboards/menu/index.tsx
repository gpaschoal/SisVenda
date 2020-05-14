import React from 'react';

interface IProps { }
interface IState { }
export default class App extends React.Component<IProps, IState> {
    constructor(props: IProps) {
        super(props);
    }

    render() {
        return (
            <>
                <div className="bg-dark h-100 d-inline-block">
                    <h1> menu </h1>
                </div>
            </>);
    }
}