import React, { useState } from 'react';
import PropTypes from 'prop-types';
import { inject, observer } from 'mobx-react';

import { Paper, Typography, IconButton, Box } from '@mui/material';
import { Edit as EditIcon, DeleteForever as DeleteForeverIcon } from '@mui/icons-material';
import IncomeSettings from '../IncomeSettings';
import Expenditures from '../Expenditures';
import withDrawer from '../../../../hoc/withDrawer';

const styles = {
    paper: {
        margin: '12px 5px',
        padding: '5px',
        display: 'inline-block',
        whiteSpace: 'nowrap',
        position: 'relative'
    }
};

const Period = ({ data: { id, periodBegin, periodEnd, incomes, expenditures }, store }) => {
    const [isVisibleIncomeSettings, setIsVisibleIncomeSettings] = useState(false);

    const formatDate = (str) => {
        const date = new Date(str);
        return date.getDate().toString().padStart(2, '0') + '.' + (date.getMonth() + 1).toString().padStart(2, '0') + '.' + date.getFullYear();
    };

    const income = incomes.reduce((accumulator, currentValue) => accumulator + currentValue.value, 0);
    const toggleIncomesVisibility = () => {
        setIsVisibleIncomeSettings(!isVisibleIncomeSettings)
    };

    const deletePeriod = () => store.deletePeriod(id);

    return (
        <>
            <Paper style={styles.paper} elevation={3}>
                <IconButton aria-label="edit" color="primary" size="small" component="span"
                            onClick={deletePeriod} style={{ position: 'absolute', right: '-10px', top: '0' }}>
                    <DeleteForeverIcon fontSize="small"/>
                </IconButton>
                <Box>
                    <Typography variant='subtitle1' display='inline'>Период: {formatDate(periodBegin)}</Typography>
                    <Typography variant='subtitle1' display='inline'> - </Typography>
                    <Typography variant='subtitle1' display='inline'>{formatDate(periodEnd)}</Typography>
                </Box>
                <Box>
                    <Typography variant='subtitle1' display='inline'>Доход: {income}</Typography>
                    <IconButton aria-label="edit" color="primary" size="small" component="span"
                                onClick={toggleIncomesVisibility}>
                        <EditIcon fontSize="small"/>
                    </IconButton>
                </Box>
                <Expenditures periodId={id} data={expenditures}/>
            </Paper>
            {withDrawer(<IncomeSettings
                periodId={id}
                incomes={incomes}
            />, toggleIncomesVisibility, isVisibleIncomeSettings)}
        </>
    );
};

Period.propTypes = {
    periodBegin: PropTypes.instanceOf(Date),
    periodEnd: PropTypes.instanceOf(Date),
    incomes: PropTypes.array,
    expenditures: PropTypes.array
};

export default inject(`store`)(observer(Period));
