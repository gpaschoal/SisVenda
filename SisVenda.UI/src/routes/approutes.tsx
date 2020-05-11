import { BrowserRouter, Route, Switch, Redirect, RouteComponentProps } from 'react-router-dom';
import React from 'react';
import isAuthenticated from '../auth/auth'
import login from '../pages/login';
import main from '../pages/main';
import people from '../pages/people'
import products from '../pages/products'
import Dashboards from '../pages/dashboards'

export default function Routes() {

    const PrivateRoute = ({ component, /*isAuthenticated,*/ ...rest }: any) => {
        const routeComponent = (props: RouteComponentProps<{}>) => (
            isAuthenticated()
                ? React.createElement(component, props)
                : <Redirect to={{ pathname: '/login' }} />
        );
        return <Route {...rest} render={routeComponent} />;
    };

    return (
        <BrowserRouter>
            <Switch>
                <Route path="/login" exact component={login} />
                <Dashboards>
                    <PrivateRoute path="/" exact component={main} />
                    <PrivateRoute path="/products" exact component={products} />
                    <PrivateRoute path="/customer" exact component={people} />
                </Dashboards>
            </Switch>
        </BrowserRouter>
    )
}