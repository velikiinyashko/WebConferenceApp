import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { Index } from './components/Index';

export default class App extends Component {
    displayName = App.name

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Index} />
                <Route path='/counter' component={Counter} />
                <Route path='/fetchdata' component={FetchData} />
            </Layout>
        );
    }
}
