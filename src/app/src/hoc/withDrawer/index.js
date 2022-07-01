import React from 'react';
import { Box, Drawer } from '@mui/material';

export default function withDrawer(Component, onClose, isVisible) {
    const toggleDrawer = (open) => (event) => {
        if (event.type === 'keydown' && (event.key === 'Tab' || event.key === 'Shift')) {
            return;
        }

        onClose();
    };

    return (
        <Drawer
            anchor='left'
            open={isVisible}
            onClose={toggleDrawer(false)}
        >
            <Box
                sx={{ width: 250 }}
                role="presentation"
            >
                {Component}
            </Box>
        </Drawer>
    );
}
