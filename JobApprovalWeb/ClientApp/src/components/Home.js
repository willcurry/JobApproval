import React, { Component } from 'react';

const initialstate = {
    TotalPrice: 0,
    TotalHours: 0,
    RequestedItems: {}
}

export class Home extends Component {
  static displayName = Home.name;

    constructor(props) {
        super(props)
        this.state = initialstate;
        this.onChange = this.onChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleResponse = this.handleResponse.bind(this);
    }

    onChange(e) {
        if (e.target.id === 'total_price') {
            this.setState({ TotalPrice: e.target.value });
        } else if (e.target.id === 'total_hours') {
            this.setState({ TotalHours: e.target.value });
        } else {
            var currentItems = this.state.RequestedItems;
            currentItems[e.target.id] = e.target.value;
            this.setState({ RequestedItems: currentItems });
        }
    }

    handleResponse(responseText) {
        alert(responseText);
    }

    handleSubmit(event) {
        event.preventDefault();
        fetch('JobApproval/submit', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                TotalHours: parseInt(this.state.TotalHours),
                TotalPrice: parseInt(this.state.TotalPrice),
                RequestedItems: JSON.stringify(this.state.RequestedItems)
            })
        }).then((response) => response.text())
            .then((responseText) => {
                this.handleResponse(responseText);
            })
    }

    getRandomInt(max) {
        return Math.floor(Math.random() * Math.floor(max));
    }

    render () {
      return (
          <form onSubmit={this.handleSubmit}>
            <div class="form-group">
                  <label for="tyre">Tyres</label>
                  <input type="number" onChange={this.onChange} class="form-control" id="tyre" value={this.getRandomInt(10)}/>
            </div>
            <div class="form-group">
                <label for="brake_disc">Brake Discs</label>
                <input type="number" onChange={this.onChange} class="form-control" id="brake_disc" value={this.getRandomInt(10)}/>
            </div>
            <div class="form-group">
                <label for="brake_pad">Brake Pads</label>
                <input type="number" onChange={this.onChange} class="form-control" id="brake_pad" value={this.getRandomInt(10)}/>
            </div>
            <div class="form-group">
                <label for="oil">Oil</label>
                <input type="number" onChange={this.onChange} class="form-control" id="oil" value={this.getRandomInt(10)}/>
            </div>
            <div class="form-group">
                <label for="exhaust">Exhaust</label>
                <input type="number" onChange={this.onChange} class="form-control" id="exhaust" value={this.getRandomInt(10)}/>
            </div>
            <div class="form-group">
                <label for="total_hours">Total Hours</label>
                <input type="number" onChange={this.onChange} class="form-control" id="total_hours" value={this.getRandomInt(10)}/>
            </div>
            <div class="form-group">
                <label for="total_price">Total Price</label>
                <input type="number" onChange={this.onChange} class="form-control" id="total_price" value={this.getRandomInt(10)}/>
            </div>
            <button type="submit" class="btn btn-primary">Submit</button>
        </form>
    );
  }
}
