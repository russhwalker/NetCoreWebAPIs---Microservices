import React, { Component } from 'react';

export class Orders extends Component {
    static renderTable(orders) {
        if (orders) {
            return (
                <table className='table'>
                    <thead>
                        <tr>
                            <th>Order Date</th>
                            <th>Total Price</th>
                        </tr>
                    </thead>
                    <tbody>
                        {orders.map(ord =>
                            (<tr key={ord.orderId}>
                                <td>{ord.orderDate}</td>
                                <td>{ord.totalPrice}</td>
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
                        <th>Order Date</th>
                        <th>Total Price</th>
                    </tr>
                </thead>
                <tbody>
                    <tr><td colSpan="2">No Orders Found</td></tr>
                </tbody>
            </table>
        );
    }

    displayName = Orders.name

    constructor(props) {
        super(props);
    }

    render() {
        if (this.props.loading) {
            return <span />;
        }

        if (this.props.customer && this.props.customer.customerId && this.props.customer.customerId > 0) {
            return (
                <div className="col-md-12">
                    <div className="well well-sm">
                        <div className="row">
                            <div className="col-md-6">
                                {Orders.renderTable(this.props.customer.orders)}
                            </div>
                        </div>
                    </div>
                </div>
            );
        }

        return (<div className="col-md-12"><div className="well well-sm">no customer yet selected</div></div>);
    }
}