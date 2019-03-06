import React, { Component } from 'react';
import './Weather.css';

export default class Weather extends Component {

    static renderTable(forecasts) {
        return (
            <table className='table table-condensed table-striped'>
                <thead>
                    <tr>
                        <th>Zip Code</th>
                        <th>Day</th>
                        <th>Low Temparature</th>
                        <th>High Temparature</th>
                    </tr>
                </thead>
                <tbody>
                    {forecasts.map((f, i) =>
                        (<tr key={i}>
                            <td>{f.zipCode}</td>
                            <td>{f.day}</td>
                            <td>{f.lowTemparature}</td>
                            <td>{f.highTemparature}</td>
                        </tr>)
                    )}
                </tbody>
            </table>
        );
    }

    constructor(props) {
        super(props);
        this.state = {
            loaded: false,
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

        fetch('https://localhost:44360/api/Weather/' + this.state.zipCode, {
            method: 'GET',
            mode: 'cors'
        })
            .then(response => response.json())
            .then(response => {
                this.setState({
                    forecasts: response,
                    loaded: true
                });
            }).catch((err) => {
                alert('ERROR:' + err.message);
            });
        event.preventDefault();
    }

    render() {
        let forecastContent = this.state.loaded
            ? Weather.renderTable(this.state.forecasts)
            : <div></div>;

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
                                <button className="btn btn-sm btn-primary" type="submit">Load</button>
                            </div>
                            <div className="col-md-6">
                                {forecastContent}
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        );
    }
}