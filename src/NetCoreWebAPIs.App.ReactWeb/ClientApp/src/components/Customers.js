import React, { Component } from 'react';
import Customer from './Customer';
import { Orders } from './Orders';
import { CustomersTable } from './CustomersTable';

export class Customers extends Component {

    displayName = Customers.name

    constructor(props) {
        super(props);
        this.state = {
            customers: [],
            selectedCustomer: {},
            loading: true
        };
        this.loadCustomers = this.loadCustomers.bind(this);
        this.addCustomer = this.addCustomer.bind(this);
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

    addCustomer(customer) {
        let customers = this.state.customers;
        customers.push(customer);
        this.setState({
            customers: customers
        });
    }

    addCustomer(customer) {
        let customers = this.state.customers;
        customers.push(customer);
        this.setState({
            customers: customers
        });
    }

    render() {
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
                                <Customer tokenContent={this.props.tokenContent} loadCustomers={this.loadCustomers} addCustomer={this.addCustomer} />
                            </div>
                            <div className="col-md-6">
                                <CustomersTable loading={this.state.loading} customers={this.state.customers} />
                            </div>
                        </div>
                        <div className="row">
                            <Orders customer={this.state.selectedCustomer} />
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