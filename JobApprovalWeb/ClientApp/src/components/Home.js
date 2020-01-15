import React, { Component } from 'react';

const initialstate = {
    TotalPrice: 0,
    TotalMinutes: 0,
    RequestedItems: {},
    FormItems: ["tyre", "exhaust", "brake_disc", "brake_pad", "oil", "total_minutes", "total_price"]
}

export class Home extends Component {
  static displayName = Home.name;

    constructor(props) {
        super(props)
        this.state = initialstate;
        this.onChange = this.onChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleResponse = this.handleResponse.bind(this);
        this.randomFormValues = this.randomFormValues.bind(this);
        this.setInputToRandomValue = this.setInputToRandomValue.bind(this);
    }

    onChange(e) {
        if (e.target.id === 'total_price') {
            this.setState({ TotalPrice: e.target.value });
        } else if (e.target.id === 'total_minutes') {
            this.setState({ TotalMinutes: e.target.value });
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
                TotalMinutes: parseInt(this.state.TotalMinutes),
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

    setInputToRandomValue(id) {
        var el = document.getElementById(id);
        el.value = this.getRandomInt(10);
        const e = new Event('input', { bubbles: true })
        e.simulated = true;
        let tracker = el._valueTracker;
        if (tracker) {
            tracker.setValue(0);
        }
        el.dispatchEvent(e);
    }

    randomFormValues() {
        var items = this.state.FormItems;
        items.forEach(item => this.setInputToRandomValue(item));
    }

    render () {
      return (
          <div>
          <form onSubmit={this.handleSubmit}>
            <div class="form-group">
                  <label for="tyre">Tyres</label>
                  <input type="number" onChange={this.onChange} class="form-control" id="tyre"/>
            </div>
            <div class="form-group">
                <label for="brake_disc">Brake Discs</label>
                <input type="number" onChange={this.onChange} class="form-control" id="brake_disc"/>
            </div>
            <div class="form-group">
                <label for="brake_pad">Brake Pads</label>
                <input type="number" onChange={this.onChange} class="form-control" id="brake_pad"/>
            </div>
            <div class="form-group">
                <label for="oil">Oil</label>
                <input type="number" onChange={this.onChange} class="form-control" id="oil"/>
            </div>
            <div class="form-group">
                <label for="exhaust">Exhaust</label>
                <input type="number" onChange={this.onChange} class="form-control" id="exhaust"/>
            </div>
            <div class="form-group">
                <label for="total_minutes">Total Minutes</label>
                <input type="number" onChange={this.onChange} class="form-control" id="total_minutes"/>
            </div>
            <div class="form-group">
                <label for="total_price">Total Price</label>
                <input type="number" onChange={this.onChange} class="form-control" id="total_price"/>
            </div>
            <button type="submit" class="btn btn-primary">Submit</button>
        </form>
        <button onClick={this.randomFormValues} class="btn btn-secondary">Random Values</button>
          </div>
    );
  }
}
