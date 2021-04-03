import React, { Component } from 'react';

export default class Counter extends Component {
  static displayName = Counter.name;

  constructor(props) {
    super(props);
  }
  render() {

    return (
      <div>
        <p aria-live="polite"> Shifts : <strong>{this.props.currentCount}</strong></p>
        <button className="btn btn-primary mx-1" onClick={this.props.onDecrement}> - </button>
        <button className="btn btn-primary mx-1" onClick={this.props.onIncrement}> + </button>
      </div>
      );
  }
}
