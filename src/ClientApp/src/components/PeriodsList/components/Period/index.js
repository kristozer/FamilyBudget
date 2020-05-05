import React, {Component} from 'react';
import {Grid, Paper, Typography, IconButton} from '@material-ui/core';
import {Edit as EditIcon} from '@material-ui/icons';

class Period extends Component {
	constructor(props) {
		super(props);
	}

	formatDate = (str) => {
		const date = new Date(str);
		return date.getDate().toString().padStart(2,'0')+'.'+(date.getMonth()+1).toString().padStart(2,'0')+'.'+date.getFullYear();
	};

	render() {
		const {data: {periodBegin, periodEnd, income}} = this.props;

		return (
			<Paper style={{margin: 'auto'}}>
				<Grid container>
					<Grid item xs={12}>
						<Typography variant='subtitle1' display='inline'>{this.formatDate(periodBegin)}</Typography>
						<Typography variant='subtitle1' display='inline'> - </Typography>
						<Typography variant='subtitle1' display='inline'>{this.formatDate(periodEnd)}</Typography>
					</Grid>
					<Grid item xs={12}>
						<Typography variant='subtitle1' display='inline'>Доход: {income}</Typography>
						<IconButton aria-label="edit" color="primary" size="small" component="span">
							<EditIcon fontSize="small" />
						</IconButton>
					</Grid>
				</Grid>
			</Paper>
		);
	}
}

export default Period;
