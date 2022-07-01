import React, { useState } from 'react';
import { Box, IconButton, Stack, Typography } from '@mui/material';
import { Edit as EditIcon } from '@mui/icons-material';
import withDrawer from '../../../../hoc/withDrawer';
import ExpedintureSettings from '../ExpedintureSettings';

const styles = {
    boldMarginText: {
        fontWeight: 'bold',
        marginRight: '5px'
    },
    marginText: {
        marginRight: '5px'
    }
};

const Expedintures = ({ data }) => {
    const [isVisibleExpedintureSettings, setIsVisibleExpedintureSettings] = useState(false);
    const [actualId, setActualId] = useState(false);

    const openExpedintureSettings = id => {
        setActualId(id);
        setIsVisibleExpedintureSettings(true);
    };

    const closeExpedintureSettings = () => {
        setIsVisibleExpedintureSettings(false);
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
                        onClick={() => openExpedintureSettings(expenditure.id)}>
                            <EditIcon fontSize="small"/>
                        </IconButton>
                    </Box>
                </div>);
        });
    };

    return (
        <>
            <Stack spacing={0.5}>
                {createItems()}
            </Stack>
            {withDrawer(<ExpedintureSettings id={actualId}/>, closeExpedintureSettings, isVisibleExpedintureSettings)}
        </>);
};

export default Expedintures;
