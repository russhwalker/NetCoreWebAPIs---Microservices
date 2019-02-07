import React, { Component } from 'react';
import Login from './Login';
import Weather from './Weather';

export class Home extends Component {
    displayName = Home.name

    constructor(props) {
        super(props);
        this.state = {
            loggedIn: false,
            jwtToken: ''
        };
    }

    render() {
        return (
            <div>
                <Login loggedIn={this.state.loggedIn} />
                <Weather />
            </div>
        );
    }
}