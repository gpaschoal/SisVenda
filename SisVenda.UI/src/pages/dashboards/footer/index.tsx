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
                <div className="fixed-bottom bg-dark">
                    <h1> footer </h1>
                </div>
            </>);
    }
}