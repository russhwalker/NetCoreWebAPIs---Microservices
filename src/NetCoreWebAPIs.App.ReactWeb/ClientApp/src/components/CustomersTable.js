import React, { Component } from 'react';

export class CustomersTable extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        if (this.props.customers && this.props.customers.length > 0) {
            return (
                <table className='table'>
                    <thead>
                        <tr>
                            <th>CustomerId</th>
                            <th>CustomerName</th>
                            <th>Orders</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.props.customers.map(cust =>
                            (<tr key={cust.customerId}>
                                <td>{cust.customerId}</td>
                                <td>{cust.customerName}</td>
                                <td><button className="btn btn-sm btn-default">Show Orders</button></td>
                            </tr>)
                        )}
                    </tbody>
                </table>
            );
        }
        return (
            <table className='table'>
                <thead>
                    <tr>
                        <th>CustomerId</th>
                        <th>CustomerName</th>
                        <th>Orders</th>
                    </tr>
                </thead>
                <tbody>
                    <tr><td colSpan="3">No customers found.</td></tr>
                </tbody>
            </table>
        );
    }
}