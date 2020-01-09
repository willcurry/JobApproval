import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
        <form>
            <div class="form-group">
                <label for="tyre">Tyres</label>
                <input type="number" class="form-control" id="tyres" placeholder="2"/>
            </div>
            <div class="form-group">
                <label for="brake_discs">Brake Discs</label>
                <input type="number" class="form-control" id="brake_discs" placeholder="1"/>
            </div>
            <div class="form-group">
                <label for="brake_pads">Brake Pads</label>
                <input type="number" class="form-control" id="brake_pads" placeholder="1"/>
            </div>
            <div class="form-group">
                <label for="oil">Oil</label>
                <input type="number" class="form-control" id="oil" placeholder="1"/>
            </div>
            <div class="form-group">
                <label for="exhaust">Exhaust</label>
                <input type="number" class="form-control" id="exhaust" placeholder="1"/>
            </div>
            <div class="form-group">
                <label for="total_hours">Total Hours</label>
                <input type="number" class="form-control" id="total_hours" placeholder="1"/>
            </div>
            <div class="form-group">
                <label for="total_price">Total Price</label>
                <input type="number" class="form-control" id="total_price" placeholder="1"/>
            </div>
            <button type="submit" class="btn btn-primary">Submit</button>
        </form>
    );
  }
}
