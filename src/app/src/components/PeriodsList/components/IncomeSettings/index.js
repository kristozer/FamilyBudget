import React from 'react';
import PropTypes from 'prop-types'
import { Box } from '@mui/material';
import Drawer from '@mui/material/Drawer';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import DeleteForeverIcon from '@mui/icons-material/DeleteForever';

const IncomeSettings = ({ periodId, isVisible, onClose, incomes }) => {

    const toggleDrawer = (open) => (event) => {
        if (event.type === 'keydown' && (event.key === 'Tab' || event.key === 'Shift')) {
            return;
        }

        onClose();
    };

    const deleteItem = id => {
        incomes = incomes.filter(i => i.id !== id)
    };

    const list = () => (
        <Box
            sx={{ width: 250 }}
            role="presentation"
        >
            <List>
                {incomes.map(income => (
                    <ListItem button key={income.id}>
                        <ListItemText primary={income.name} />
                        <ListItemText primary={income.value} />
                        <ListItemIcon onClick={() => deleteItem(income.id)}>
                            <DeleteForeverIcon />
                        </ListItemIcon>
                    </ListItem>
                ))}
            </List>
        </Box>
    );
    return (
        <Drawer
            anchor='left'
            open={isVisible}
            onClose={toggleDrawer(false)}
        >
            {list()}
        </Drawer>
    );
};

IncomeSettings.propTypes = {
    periodId: PropTypes.number
};

export default IncomeSettings;
