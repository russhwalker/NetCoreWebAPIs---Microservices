import React, { Component } from 'react';
import Customer from './Customer';

export class Customers extends Component {
    static renderTable(customers) {
        return (
            <table className='table'>
                <thead>
                    <tr>
                        <th>CustomerId</th>
                        <th>CustomerName</th>
                    </tr>
                </thead>
                <tbody>
                    {customers.map(cust =>
                        (<tr key={cust.customerId}>
                            <td>{cust.customerId}</td>
                            <td>{cust.customerName}</td>
                        </tr>)
                    )}
                </tbody>
            </table>
        );
    }

    displayName = Customers.name

    constructor(props) {
        super(props);
        this.state = {
            customers: [],
            loading: true
        };
        this.loadCustomers = this.loadCustomers.bind(this);
    }

    loadCustomers() {
        this.setState({
            customers: [],
            loading: true
        });

        fetch('https://localhost:44360/api/Customer/', {
            method: 'GET',
            mode: 'cors',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${this.props.tokenContent}`
            }
        })
            .then(response => response.json())
            .then(data => {
                this.setState({
                    customers: data,
                    loading: false
                });
            })
            .catch(err => {
                alert('fail');
            });
    }

    render() {
        let customerTableContents = this.state.loading
            ? <div></div>
            : Customers.renderTable(this.state.customers);

        if (this.props.authenticated) {
            return (
                <div className="col-md-12">
                    <div className="well well-sm">
                        <div className="row">
                            <div className="col-md-6">
                                <div className="row">
                                    <label className="control-label col-md-6">Customers</label>
                                    <div className="col-md-6">
                                        <button type="button" className="btn btn-sm btn-info" onClick={this.loadCustomers}>Load</button>
                                    </div>
                                </div>
                                <hr />
                                <Customer tokenContent={this.state.tokenContent} loadCustomers={this.loadCustomers} />
                            </div>
                            <div className="col-md-6">
                                {customerTableContents}
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
                        <label className="control-label col-md-2">Customers</label>
                        <div className="col-md-10">
                            Not Authenticated
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}