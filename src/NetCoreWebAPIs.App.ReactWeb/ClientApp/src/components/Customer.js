import React, { Component } from 'react';

export default class Customer extends Component {
    constructor(props) {
        super(props);
        this.state = {
            saving: false,
            customerId: 0,
            customerName: ''
        };
        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.baseUrl = document.getElementById('baseGatewayUrl').value;
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
            saving: true
        });

        var data = {
            customerId: this.state.customerId,
            customerName: this.state.customerName
        };

        const url = this.baseUrl
            + "/api/Customer/";

        fetch(url, {
            method: 'POST',
            mode: 'cors',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${this.props.tokenContent}`
            },
            body: JSON.stringify(data)
        })
            .then(response => response.json())
            .then(response => {
                this.setState({
                    saving: false,
                    customerId: 0,
                    customerName: ''
                });
                this.props.addCustomer(response);
            }).catch((err) => {
                alert('ERROR:' + err.message);
            });
        event.preventDefault();
    }

    render() {
        return (
            <div className="panel panel-default">
                <div className="panel-heading">
                    <strong>New Customer</strong>
                </div>
                <div className="panel-body">
                    <form onSubmit={this.handleSubmit}>
                        <div className="col-md-8">
                            <label className="control-label col-md-5">Customer Name:</label>
                            <div className="col-md-7">
                                <input className="form-control" type="text" name="customerName" value={this.state.customerName} onChange={this.handleInputChange} />
                            </div>
                        </div>
                        <div className="col-md-4">
                            <button className="btn btn-sm btn-primary" type="submit">Save</button>
                        </div>
                    </form>
                </div>
            </div>
        );
    }
}