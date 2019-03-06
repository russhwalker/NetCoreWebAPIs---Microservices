import React, { Component } from 'react';
import Login from './Login';
import Weather from './Weather';
import { Customers } from './Customers';

export class Home extends Component {
    displayName = Home.name

    constructor(props) {
        super(props);
        this.state = {
            authenticated: false,
            tokenContent: 'not-yet-set'
        };
        this.handleLogin = this.handleLogin.bind(this);
        this.handleLogout = this.handleLogout.bind(this);
    }

    handleLogin(tokenContent) {
        //var base64Url = tokenContent.split('.')[1];
        //var base64 = base64Url.replace('-', '+').replace('_', '/');
        this.setState({
            authenticated: true,
            tokenContent: tokenContent
        });
    }

    handleLogout() {
        this.setState({
            authenticated: false,
            tokenContent: ''
        });
    }

    render() {
        return (
            <div>
                <Weather />
                <Login onHandleLogin={this.handleLogin} onHandleLogout={this.handleLogout} />
                <Customers tokenContent={this.state.tokenContent} authenticated={this.state.authenticated} />
            </div>
        );
    }
}