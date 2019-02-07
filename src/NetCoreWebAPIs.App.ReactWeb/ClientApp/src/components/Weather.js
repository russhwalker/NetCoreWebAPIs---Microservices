import React, { Component } from 'react';

export default class Weather extends Component {

    constructor(props) {
        super(props);
        this.state = {
            zipCode: ''
        };

        this.handleInputChange = this.handleInputChange.bind(this);
    }

    handleInputChange(event) {
        const target = event.target;
        const value = target.type === 'checkbox' ? target.checked : target.value;
        const name = target.name;
        this.setState({
            [name]: value
        });
    }

    render() {
        return (
            <div className="col-md-12">
                <div className="well well-sm">
                    <div className="row">
                        <label className="control-label col-md-2">Weather</label>
                        <div className="col-md-2">
                            <input className="form-control" name="zipCode" placeholder="Zip" value={this.state.zipCode} onChange={this.handleInputChange} />
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}