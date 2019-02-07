import React, { Component } from 'react';
import './Login.css';

export default class Login extends Component {

    static renderStatus(isLoggedIn, jwtToken) {
        if (isLoggedIn) {
            return (
                <div className="col-md-12">
                    <label className="control-label col-md-2">Logged In:</label>
                    <div className="col-md-2">
                        YES
                    </div>
                    <label className="control-label col-md-2">Token:</label>
                    <div className="col-md-5 jwt-view">
                        {JSON.stringify(jwtToken)}
                    </div>
                </div>
            );
        }
        else {
            return (
                <div className="col-md-12">
                    <label className="control-label col-md-2">Logged In:</label>
                    <div className="col-md-2">
                        NO
                     </div>
                </div>
            );
        }
    }

    constructor(props) {
        super(props);
        this.state = {
            loggedIn: props.loggedIn,
            userName: '',
            password: '',
            jwtToken: {}
        };
        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleLogout = this.handleLogout.bind(this);
    }

    handleInputChange(event) {
        const target = event.target;
        const value = target.type === 'checkbox' ? target.checked : target.value;
        const name = target.name;
        this.setState({
            [name]: value
        });
    }

    handleSubmit(event) {
        this.setState({
            loggedIn: true
        });

        var data = {
            userName: this.state.userName,
            password: this.state.password
        };

        fetch('https://localhost:44360/api/Auth', {
            method: 'POST',
            mode: 'cors',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })
            .then(response => response.json())
            .then(response => {
                var base64Url = response.tokenContent.split('.')[1];
                var base64 = base64Url.replace('-', '+').replace('_', '/');
                this.setState({
                    loggedIn: response.authenticated,
                    jwtToken: JSON.parse(window.atob(base64))
                });
            }).catch((err) => {
                this.setState({
                    loggedIn: false
                });
                alert('ERROR:' + err.message);
            });

        event.preventDefault();
    }

    handleLogout(event) {
        this.setState({
            loggedIn: false,
            userName: '',
            password: '',
            jwtToken: {}
        });
        event.preventDefault();
    }

    render() {

        if (this.state.loggedIn === true) {
            return (
                <div className="col-md-12">
                    <div className="well well-sm">
                        <div className="col-md-12">
                            <label className="control-label col-md-2">Token:</label>
                            <div className="col-md-10 jwt-view">
                                {JSON.stringify(this.state.jwtToken)}
                            </div>
                        </div>
                        <div className="row">
                            <div className="col-md-12">
                                <button className="btn btn-sm btn-danger" type="button" onClick={this.handleLogout}>Logout</button>
                            </div>
                        </div>
                    </div>
                </div>
            );
        }
        return (
            <div className="col-md-12">
                <div className="well well-sm">
                    <div className="row">
                        <form onSubmit={this.handleSubmit}>
                            <div className="col-md-5">
                                <label className="control-label col-md-5">UserName:</label>
                                <div className="col-md-7">
                                    <input className="form-control" name="userName" value={this.state.userName} onChange={this.handleInputChange} />
                                </div>
                            </div>
                            <div className="col-md-5">
                                <label className="control-label col-md-5">Password:</label>
                                <div className="col-md-7">
                                    <input className="form-control" type="password" name="password" value={this.state.password} onChange={this.handleInputChange} />
                                </div>
                            </div>
                            <div className="col-md-2">
                                <button className="btn btn-sm btn-primary" type="submit">Login</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        );
    }
}