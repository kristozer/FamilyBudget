import React, { useState } from 'react';
import PropTypes from 'prop-types';
import { Container, Paper, Typography, IconButton, Box, Input } from '@mui/material';
import { Edit as EditIcon, Settings as SettingsIcon } from '@mui/icons-material';
import IncomeSettings from '../IncomeSettings';

const styles = {
    paper: {
        margin: '12px auto',
        display: 'inline-block',
        whiteSpace: 'nowrap',
        position: 'relative'
    }
};

const Period = ({ data: { id, periodBegin, periodEnd, incomes, expenditures } }) => {
    const [isVisibleIncomeSettings, SetIsVisibleIncomeSettings] = useState(false);

    const formatDate = (str) => {
        const date = new Date(str);
        return date.getDate().toString().padStart(2, '0') + '.' + (date.getMonth() + 1).toString().padStart(2, '0') + '.' + date.getFullYear();
    };

    const createExpenditures = (expenditures) => {
        return expenditures.map((value, index) => {
            const listNumber = index + 1;
            const text = `${listNumber}. ${value.name}: ${value.plannedToSpendValue}`;

            return (
                <div key={value.id}>
                    <Typography variant='subtitle1' display='inline'>{text}</Typography>
                    <Input label='Потрачено' size="small" value={value.spendValue}/>
                </div>)
        });
    };

    const expendituresRender = createExpenditures(expenditures);
    const income = incomes.reduce((accumulator, currentValue) => accumulator + currentValue.value, 0);
    const toggleIncomesVisibility = () => {SetIsVisibleIncomeSettings(!isVisibleIncomeSettings)};

    return (
        <>
            <Paper style={styles.paper} elevation={3}>
                <IconButton aria-label="edit" color="primary" size="small" component="span"
                            style={{ position: 'absolute', right: '-10px', top: '0px' }}
                            onClick={() => console.log('click')}>
                    <SettingsIcon fontSize="small"/>
                </IconButton>
                <Container>
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
                </Container>
                <Box>
                    <ol>{expendituresRender}</ol>
                </Box>
            </Paper>
            <IncomeSettings periodId={id} isVisible={isVisibleIncomeSettings} onClose={toggleIncomesVisibility} incomes={incomes} />
        </>
    );
};

Period.propTypes = {
    periodBegin: PropTypes.instanceOf(Date),
    periodEnd: PropTypes.instanceOf(Date),
    incomes: PropTypes.array,
    expenditures: PropTypes.array
};

export default Period;
