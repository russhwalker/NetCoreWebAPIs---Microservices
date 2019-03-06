import React, { Component } from 'react';

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
                        (<tr key={cust.CustomerId}>
                            <td>{cust.CustomerId}</td>
                            <td>{cust.CustomerName}</td>
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
                            <label className="control-label col-md-2">Customers</label>
                            <div className="col-md-2">
                                <button type="button" className="btn btn-info" onClick={this.loadCustomers}>Load</button>
                            </div>
                            <div className="col-md-8">
                                {customerTableContents}
                            </div>
                        </div>
                    </div>
                </div>
            );
        }
        else {
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
}