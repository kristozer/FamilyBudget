import React from 'react';
import { Box, Drawer } from '@mui/material';

const styles = {
    margin: {
        marginTop: '5px'
    }
};

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
                style={styles.margin}
                sx={{ width: 250 }}
                role="presentation"
            >
                {Component}
            </Box>
        </Drawer>
    );
}
