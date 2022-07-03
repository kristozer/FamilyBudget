import React, { useState } from 'react';
import PropTypes from 'prop-types'
import { inject, observer } from 'mobx-react';

import { Button, Stack, TextField } from '@mui/material';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import DeleteForeverIcon from '@mui/icons-material/DeleteForever';

const IncomeSettings = ({ store, periodId, incomes }) => {
    const [newIncomeName, setNewIncomeName] = useState('');
    const [newIncomeValue, setNewIncomeValue] = useState('');

    const list = () => (
        <List>
            {incomes.map(income => (
                <ListItem button key={income.id}>
                    <ListItemText primary={income.name}/>
                    <ListItemText primary={income.value}/>
                    <ListItemIcon onClick={() => store.deletePeriodIncome(periodId, income.id)}>
                        <DeleteForeverIcon/>
                    </ListItemIcon>
                </ListItem>
            ))}
        </List>
    );

    const addPeriodIncomeFunc = () => {
        store.addPeriodIncome(periodId, { name: newIncomeName, value: newIncomeValue || 0 });
        setNewIncomeName('');
        setNewIncomeValue('');
    };

    const onNewIncomeNameChange = e => setNewIncomeName(e.target.value);
    const onNewIncomeValueChange = e => setNewIncomeValue(parseInt(e.target.value));

    return (
        <>
            {list()}
            <Stack spacing={1} alignItems="center">
                <TextField label='Наименование' variant="standard" value={newIncomeName}
                           onChange={onNewIncomeNameChange}/>
                <TextField label='Сумма' variant="standard" value={newIncomeValue} onChange={onNewIncomeValueChange}/>
                <Button variant="contained" onClick={addPeriodIncomeFunc}>Добавить</Button>
            </Stack>
        </>);
};

IncomeSettings.propTypes = {
    store: PropTypes.object,
    periodId: PropTypes.number
};

export default inject(`store`)(observer(IncomeSettings));
