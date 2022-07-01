import React, { Component } from 'react';
import { Provider } from 'mobx-react';

import NavBar from './components/NavBar';
import PeriodsList from './components/PeriodsList';
import PeriodsStore from './stores/PeriodsStore';

class App extends Component {
    constructor(props) {
        super(props);

        this.periodsStore = new PeriodsStore();
    }

    async componentDidMount() {
        this.periodsStore.fillPeriods();
    }

    render() {
        return (
            <Provider store={this.periodsStore}>
                <div>
                    <NavBar/>
                    <PeriodsList/>
                </div>
            </Provider>
        );
    }
}

export default App;
