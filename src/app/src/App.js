import React, {Component} from 'react';
import NavBar from './components/NavBar';
import PeriodsList from './components/PeriodsList';
import { CircularProgress } from '@mui/material';
import periodsListService from './Services/PeriodsListService';

class App extends Component {
    state = {isLoading: true, data: []};

    async componentDidMount() {
        const periods = await periodsListService.GetPeriods();
        this.setState({isLoading: false, data: periods});
    }

    render() {
        const periodsRender = this.state.isLoading ? <CircularProgress/> : <PeriodsList data={this.state.data}/>;

        return (
            <div>
                <NavBar/>
                {periodsRender}
            </div>
        );
    }
}

export default App;
