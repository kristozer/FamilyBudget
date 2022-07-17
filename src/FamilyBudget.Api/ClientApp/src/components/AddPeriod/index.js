import React, { useState } from 'react';
import { Button, Stack, TextField } from '@mui/material';

const AddPeriod = ({ store, onAdd }) => {
    const dt = new Date().toISOString().slice(0,10);
    const [periodBeg, setPeriodBeg] = useState(dt);
    const [periodEnd, setPeriodEnd] = useState(dt);

    const onChangePeriodBeg = e => setPeriodBeg(e.target.value);
    const onChangePeriodEnd = e => setPeriodEnd(e.target.value);

    const onAddLocal = () => {
        store.changePeriod({
            id: 0,
            periodBegin: new Date(periodBeg),
            periodEnd: new Date(periodEnd),
            incomes: [],
            expenditures: []
        });
        onAdd();
    }

    return (
        <Stack spacing={1} alignItems="center">
            <TextField label='Дата начала' variant="standard" type="date" value={periodBeg} InputLabelProps={{
                shrink: true, required: true
            }} onChange={onChangePeriodBeg}/>
            <TextField label='Дата окончания' variant="standard" type="date" value={periodEnd} InputLabelProps={{
                shrink: true, required: true
            }} onChange={onChangePeriodEnd}/>
            <Button variant="contained" onClick={onAddLocal}>Добавить период</Button>
        </Stack>
    );
};

export default AddPeriod;
