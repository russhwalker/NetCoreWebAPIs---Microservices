import React, { Component } from 'react';

export default class Weather extends Component {

    constructor(props) {
        super(props);
        this.state = {
            zipCode: '',
            forecasts: []
        };

        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
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

        fetch('https://localhost:44360/api/Weather' + this.state.zipCode, {
            method: 'GET',
            mode: 'cors'
        })
            .then(response => response.json())
            .then(response => {
                this.setState({
                    forecasts: response.forecasts
                });
            }).catch((err) => {
                alert('ERROR:' + err.message);
            });
        event.preventDefault();
    }

    render() {
        return (
            <div className="col-md-12">
                <div className="well well-sm">
                    <form onSubmit={this.handleSubmit}>
                        <div className="row">
                            <label className="control-label col-md-2">Weather</label>
                            <div className="col-md-2">
                                <input className="form-control" name="zipCode" placeholder="Zip" value={this.state.zipCode} onChange={this.handleInputChange} />
                            </div>
                            <div className="col-md-1">
                                <button className="btn btn-sm btn-primary" type="submit">Go</button>
                            </div>
                            <div className="col-md-6">
                                asdsad
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        );
    }
}