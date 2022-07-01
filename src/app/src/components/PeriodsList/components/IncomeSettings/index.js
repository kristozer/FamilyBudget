import React, { useState } from 'react';
import PropTypes from 'prop-types'
import { Box, Button, Stack, TextField } from '@mui/material';
import Drawer from '@mui/material/Drawer';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import DeleteForeverIcon from '@mui/icons-material/DeleteForever';

const IncomeSettings = ({ periodId, isVisible, onClose, incomes, deleteIncome, addPeriodIncome }) => {
    const [newIncomeName, setNewIncomeName] = useState('');
    const [newIncomeValue, setNewIncomeValue] = useState();

    const toggleDrawer = (open) => (event) => {
        if (event.type === 'keydown' && (event.key === 'Tab' || event.key === 'Shift')) {
            return;
        }

        onClose();
    };

    const list = () => (
        <Box
            sx={{ width: 250 }}
            role="presentation"
        >
            <List>
                {incomes.map(income => (
                    <ListItem button key={income.id}>
                        <ListItemText primary={income.name}/>
                        <ListItemText primary={income.value}/>
                        <ListItemIcon onClick={() => deleteIncome(periodId, income.id)}>
                            <DeleteForeverIcon/>
                        </ListItemIcon>
                    </ListItem>
                ))}
            </List>
        </Box>
    );

    const addPeriodIncomeFunc = () => {
        addPeriodIncome(periodId, { name: newIncomeName, value: newIncomeValue });
        setNewIncomeName('');
        setNewIncomeValue('');
    };

    const onNewIncomeNameChange = e => setNewIncomeName(e.target.value);
    const onNewIncomeValueChange = e => setNewIncomeValue(parseInt(e.target.value));

    return (
        <Drawer
            anchor='left'
            open={isVisible}
            onClose={toggleDrawer(false)}
        >
            {list()}
            <Stack spacing={1} alignItems="center">
                <TextField label='Наименование' variant="standard" value={newIncomeName}
                           onChange={onNewIncomeNameChange}/>
                <TextField label='Сумма' variant="standard" value={newIncomeValue} onChange={onNewIncomeValueChange}/>
                <Button variant="contained" onClick={addPeriodIncomeFunc}>Добавить</Button>
            </Stack>
        </Drawer>
    );
};

IncomeSettings.propTypes = {
    periodId: PropTypes.number
};

export default IncomeSettings;
