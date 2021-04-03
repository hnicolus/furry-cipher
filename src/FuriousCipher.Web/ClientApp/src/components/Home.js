import React, { Component } from 'react';
import CeasarCipher from './CeasarCipher';
export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <CeasarCipher />
      </div>
    );
  }
}
