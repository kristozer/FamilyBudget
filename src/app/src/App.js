import React, { Component } from 'react';
import { Provider } from 'mobx-react';

import { IconButton } from '@mui/material';
import { AddCircle as AddCircleIcon } from '@mui/icons-material';

import NavBar from './components/NavBar';
import PeriodsList from './components/PeriodsList';
import PeriodsStore from './stores/PeriodsStore';
import withDrawer from './hoc/withDrawer';
import AddPeriod from './components/AddPeriod';

class App extends Component {
    constructor(props) {
        super(props);

        this.periodsStore = new PeriodsStore();
        this.state = {
            isAddPeriodVisible: false
        };
    }

    closePeriodAdd = () => this.setState({isAddPeriodVisible: false});

    async componentDidMount() {
        this.periodsStore.fillPeriods();
    }

    render() {
        return (
            <Provider store={this.periodsStore}>
                <div>
                    <NavBar/>
                    <PeriodsList/>
                    <IconButton
                        size="large"
                        edge="start"
                        color="primary"
                        aria-label="addCircle"
                        style={{ position: 'absolute', right: '0', bottom: '0' }}
                        onClick={() => this.setState({isAddPeriodVisible: true})}
                    >
                        <AddCircleIcon />
                    </IconButton>
                    {withDrawer(<AddPeriod store={this.periodsStore} onAdd={this.closePeriodAdd}/>, this.closePeriodAdd, this.state.isAddPeriodVisible)}
                </div>
            </Provider>
        );
    }
}

export default App;
