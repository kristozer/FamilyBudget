import React from 'react';
import { inject, observer } from 'mobx-react';

import { CircularProgress, Grid } from '@mui/material';
import Period from './components/Period';

const PeriodsList = ({ store }) => {
    const data = store.periods;
    const itemSize = 12 / data.length;

    const items = data.map(d => {
        return (
            <Grid key={d.id} item xs={12} sm={itemSize}>
                <Period data={d}/>
            </Grid>
        );
    });

    if (!store.showPeriods) {
        return <CircularProgress/>;
    }

    return (
        <Grid container>
            {items}
        </Grid>
    );
};

export default inject(`store`)(observer(PeriodsList));
