import React, { useState } from 'react';
import PropTypes from 'prop-types';
import { inject, observer } from 'mobx-react';

import { Paper, Typography, IconButton, Box } from '@mui/material';
import { Edit as EditIcon, Settings as SettingsIcon } from '@mui/icons-material';
import IncomeSettings from '../IncomeSettings';
import Expedintures from '../Expedintures';

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

    const deleteIncome = (periodId, incomeId) => store.deletePeriodIncome(periodId, incomeId);
    const addPeriodIncome = (periodId, income) => store.addPeriodIncome(periodId, income);

    return (
        <>
            <Paper style={styles.paper} elevation={3}>
                <IconButton aria-label="edit" color="primary" size="small" component="span"
                            style={{ position: 'absolute', right: '-10px', top: '-10px' }}
                            onClick={() => console.log('click')}>
                    <SettingsIcon fontSize="small"/>
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
                <Expedintures data={expenditures}/>
            </Paper>
            <IncomeSettings
                periodId={id}
                isVisible={isVisibleIncomeSettings}
                onClose={toggleIncomesVisibility}
                incomes={incomes}
                deleteIncome={deleteIncome}
                addPeriodIncome={addPeriodIncome}
            />

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
