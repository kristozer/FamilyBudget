import React from 'react';
import { AppBar, Toolbar, Typography } from '@mui/material';

const NavBar = () => {
	return (
		<div>
			<AppBar position='static'>
				<Toolbar>
					<Typography variant='subtitle1' color='inherit'>
						Family Budget
					</Typography>
				</Toolbar>
			</AppBar>
		</div>
	)
};

export default NavBar;
