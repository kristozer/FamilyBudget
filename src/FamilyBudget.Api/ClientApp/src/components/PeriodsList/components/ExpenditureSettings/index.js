import React, { useState } from 'react';
import { Button, Stack, TextField } from '@mui/material';

const ExpenditureSettings = ({ expenditure, onChange, onDelete }) => {
    const [newName, setNewName] = useState(expenditure.name || '');
    const [newPlannedToSpendValue, setPlannedToSpendValue] = useState(expenditure.plannedToSpendValue || '');
    const [newSpentValue, setSpentValue] = useState(expenditure.spentValue || '');

    const onNewName = e => setNewName(e.target.value);
    const onNewPlannedToSpendValue = e => setPlannedToSpendValue(parseInt(e.target.value));
    const onNewSpentValue = e => setSpentValue(parseInt(e.target.value));
    const onChangeLocal = () => {
        onChange({
            id: expenditure.id,
            name: newName,
            plannedToSpendValue: newPlannedToSpendValue || 0,
            spentValue: newSpentValue || 0
        });
    }

    return (
        <Stack spacing={1} alignItems="center">
            <TextField label='Наименование' variant="standard" value={newName} onChange={onNewName}/>
            <TextField label='Запланировано' variant="standard" value={newPlannedToSpendValue} onChange={onNewPlannedToSpendValue}/>
            <TextField label='Потрачено' variant="standard" value={newSpentValue} onChange={onNewSpentValue}/>
            <Button variant="contained" onClick={onChangeLocal}>{expenditure.id === 0 ? `Добавить` : `Изменить`}</Button>
            <Button variant="contained" onClick={() => onDelete(expenditure.id)} disabled={expenditure.id === 0}>Удалить</Button>
        </Stack>
    );
};

export default ExpenditureSettings;
