import React, { Component } from 'react';
import { Col, Grid, Row } from 'react-bootstrap';
import { NavMenu } from './NavMenu';
import { MainFooter } from './Footer';

export class Layout extends Component {
  

  render() {
    return (
        <div>
            {this.props.children}
        </div>
        <div>
            <MainFooter />
        </div>
    );
  }
}
