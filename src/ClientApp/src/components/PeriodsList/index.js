import React, { Component } from 'react';
import { Grid, Paper } from '@material-ui/core';
import Period from './components/Period';
import style from './style.css';

class PeriodsList extends Component {
	constructor(props) {
		super(props);
	}

	render() {
		const { data } = this.props;
		const itemSize = 12 / data.length;

		const items = data.map(d => {
			return (
				<Grid key={d.id} item container xs={itemSize}>
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
