import React, { Component } from 'react';
import Login from './Login';

export class Home extends Component {
    displayName = Home.name

    constructor(props) {
        super(props);
        this.state = {
            loggedIn: false
        };
    }

    render() {
        return (
            <div>
                <Login loggedIn={this.state.loggedIn} />
            </div>
        );
    }
}