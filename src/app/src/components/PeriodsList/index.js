import React, { Component } from 'react';
import { Grid, Paper } from '@mui/material';
import Period from './components/Period';

class PeriodsList extends Component {
	constructor(props) {
		super(props);
	}

	render() {
		const { data } = this.props;
		const itemSize = 12 / data.length;

		const items = data.map(d => {
			return (
				<Grid key={d.id} item xs={12} sm={itemSize}>
					<Period data={d} />
				</Grid>
			);
		});

		return (
			<Grid container>
				{items}
			</Grid>
		);
	}
}

export default PeriodsList;
