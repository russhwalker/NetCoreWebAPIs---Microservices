import React, { Component } from 'react';

export default class Login extends Component {

    static renderStatus(isLoggedIn) {
        return (
            <div className="panel-heading">
                <div className="row">
                    <label className="control-label col-md-3">Logged In:</label>
                    <div className="col-md-3">
                        {(isLoggedIn ? 'YES' : 'NO')}
                    </div>
                </div>
            </div>
        );
    }

    constructor(props) {
        super(props);
        this.state = {
            loggedIn: props.loggedIn,
            userName: '',
            password: ''
        };
        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleLogout = this.handleLogout.bind(this);
        //this.renderStatus = this.renderStatus.bind(this);
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

        //fetch('api/Home/Login', {
        //    method: 'POST',
        //    headers: {
        //        'Accept': 'application/json',
        //        'Content-Type': 'application/json'
        //    },
        //    body: JSON.stringify(data)
        //}).then(response => {
        //    this.setState({
        //        loggedIn: response.Authenticated
        //    });
        //    //this.props.history.push('/cars');
        //}).catch(() => {
        //    this.setState({
        //        editing: true
        //    });
        //    alert('ERROR');
        //});

        event.preventDefault();
    }

    handleLogout(event) {
        this.setState({
            loggedIn: false,
            userName: '',
            password: ''
        });
        event.preventDefault();
    }

    render() {
        let loggedInStatus = Login.renderStatus(this.state.loggedIn);

        if (this.state.loggedIn === true) {
            return (
                <div className="col-md-7">
                    <div className="panel panel-info">
                    {loggedInStatus}
                    <div className="panel-body">
                        <div className="row">
                            <div className="col-md-12">
                                <button className="btn btn-sm btn-danger" type="button" onClick={this.handleLogout}>Logout</button>
                            </div>
                        </div>
                    </div>
                </div>
                </div>
            );
        }
        return (
            <div className="col-md-7">
                <div className="panel panel-info">
                    {loggedInStatus}
                    <div className="panel-body">
                        <form onSubmit={this.handleSubmit}>
                            <div className="row">
                                <div className="col-md-6">
                                    <label className="control-label col-md-5">UserName:</label>
                                    <div className="col-md-7">
                                        <input className="form-control" name="userName" value={this.state.userName} onChange={this.handleInputChange} />
                                    </div>
                                </div>
                                <div className="col-md-6">
                                    <label className="control-label col-md-5">Password:</label>
                                    <div className="col-md-7">
                                        <input className="form-control" name="password" value={this.state.password} onChange={this.handleInputChange} />
                                    </div>
                                </div>
                            </div>
                            <div className="row">
                                <div className="col-md-12">
                                    <button className="btn btn-sm btn-primary" type="submit">Login</button>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        );
    }
}