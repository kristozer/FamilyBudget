import React, { useState } from 'react';
import { inject, observer } from 'mobx-react';

import { Box, Button, IconButton, Stack, Typography } from '@mui/material';
import { Edit as EditIcon } from '@mui/icons-material';
import withDrawer from '../../../../hoc/withDrawer';
import ExpenditureSettings from '../ExpenditureSettings';

const styles = {
    boldMarginText: {
        fontWeight: 'bold',
        marginRight: '5px'
    },
    marginText: {
        marginRight: '5px'
    }
};

const Expenditures = ({ store, periodId, data }) => {
    const [isVisibleExpenditureSettings, setIsVisibleExpenditureSettings] = useState(false);
    const [actualExpenditure, setActualExpenditure] = useState({});

    const openExpenditureSettings = expenditure => {
        setActualExpenditure(expenditure);
        setIsVisibleExpenditureSettings(true);
    };

    const closeExpenditureSettings = () => {
        setIsVisibleExpenditureSettings(false);
    };

    const onExpenditureChange = (expenditure) => {
        store.changeExpenditure({ ...expenditure, periodId });
        closeExpenditureSettings();
    };

    const onExpenditureDelete = id => {
        store.deleteExpenditure(periodId, id);
        closeExpenditureSettings();
    };

    if (!data) {
        return <div/>;
    }

    const createItems = () => {
        return data.map((expenditure, index) => {
            const listNumber = index + 1;

            return (
                <div key={expenditure.id}>
                    <Typography variant='subtitle1'
                                display='inline'>{`${listNumber}. ${expenditure.name}`}</Typography>
                    <Box>
                        <Typography variant='subtitle1' display='inline'
                                    fontSize='small' style={styles.marginText}>Запланировано:
                        </Typography>
                        <Typography
                            variant='subtitle1' display='inline' fontSize='small'
                            style={styles.boldMarginText}>{expenditure.plannedToSpendValue}</Typography>

                        <Typography
                            variant='subtitle1' display='inline' fontSize='small' style={styles.marginText}
                            >Потрачено:
                        </Typography>
                        <Typography variant='subtitle1' display='inline'
                                    fontSize='small'
                                    style={styles.boldMarginText}>{expenditure.spentValue}</Typography>

                        <IconButton aria-label="edit" color="primary" size="small" component="span"
                        onClick={() => openExpenditureSettings(expenditure)}>
                            <EditIcon fontSize="small"/>
                        </IconButton>
                    </Box>
                </div>);
        });
    };

    const spentSum = () => {
        return data.reduce((prev, next) => prev + next.spentValue, 0);
    }

    return (
        <>
            <Stack spacing={0.5}>
                {createItems()}
                <Typography variant='subtitle1' display='inline'>Общий расход: {spentSum()}</Typography>
                <Button variant="contained" onClick={() => openExpenditureSettings({ id:0 })}>Добавить расход</Button>
            </Stack>
            {withDrawer(<ExpenditureSettings expenditure={actualExpenditure} onChange={onExpenditureChange}
                                             onDelete={onExpenditureDelete}/>,
                closeExpenditureSettings, isVisibleExpenditureSettings)}
        </>);
};

export default inject(`store`)(observer(Expenditures));
