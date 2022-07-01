import React from 'react';
import { AppBar, Toolbar, Typography, Link } from '@mui/material';

const NavBar = () => {
	return (
		<div>
			<AppBar position='static'>
				<Toolbar>
					<Typography variant='subtitle1' color='inherit'>
						Family Budget
					</Typography>
					<Link color="secondary">Расходы</Link>
				</Toolbar>
			</AppBar>
		</div>
	)
};

export default NavBar;
