import React, { useState } from 'react';
import { Button, Stack, TextField } from '@mui/material';

const styles = {
    margin: {
        fontWeight: 'bold',
        marginTop: '5px'
    }
};

const ExpenditureSettings = ({ expenditure, onChange }) => {
    const [newPlannedToSpendValue, setPlannedToSpendValue] = useState(expenditure.plannedToSpendValue);
    const [newSpentValue, setSpentValue] = useState(expenditure.spentValue);

    const onNewPlannedToSpendValue = e => setPlannedToSpendValue(e.target.value);
    const onNewSpentValue = e => setSpentValue(e.target.value);

    return (
        <Stack spacing={1} alignItems="center" style={styles.margin}>
            <TextField label='Запланировано' variant="standard" value={newPlannedToSpendValue}
                       onChange={onNewPlannedToSpendValue}/>
            <TextField label='Сумма' variant="standard" value={newSpentValue} onChange={onNewSpentValue}/>
            <Button variant="contained" onClick={() => onChange(expenditure.id, newPlannedToSpendValue, newSpentValue)}>Изменить</Button>
        </Stack>
    );
};

export default ExpenditureSettings;
