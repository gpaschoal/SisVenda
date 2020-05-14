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
                <div className="bg-dark ">
                    <h1> header </h1>
                </div>
            </>);
    }
}