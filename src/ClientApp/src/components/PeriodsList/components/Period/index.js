import React, { Component } from 'react';
import { Container, Paper, Typography, IconButton, Box, Input } from '@material-ui/core';
import { Edit as EditIcon, Settings as SettingsIcon } from '@material-ui/icons';

const styles = {
    paper: {
        margin: '12px auto',
        display: 'inline-block',
        whiteSpace: 'nowrap',
        position: 'relative'
    }
};

class Period extends Component {
    constructor(props) {
        super(props);
    }

    formatDate = (str) => {
        const date = new Date(str);
        return date.getDate().toString().padStart(2, '0') + '.' + (date.getMonth() + 1).toString().padStart(2, '0') + '.' + date.getFullYear();
    };

    createExpenditures = (expenditures) => {
        return expenditures.map((value, index) => {
            const listNumber = index + 1;
            const text = `${listNumber}. ${value.name}: ${value.plannedToSpendValue}`;

            return (
            <div key={value.id}>
                <Typography variant='subtitle1' display='inline'>{text}</Typography>
                <Input label='Потрачено' size="small" value={value.spendValue} />
            </div>)
        });
    };

    render() {
        const { data: { periodBegin, periodEnd, incomes, expenditures } } = this.props;
        const expendituresRender = this.createExpenditures(expenditures);
        const income = incomes.reduce((accumulator, currentValue) => accumulator + currentValue.value, 0);

        return (
            <Paper style={styles.paper} elevation={3}>
                <IconButton aria-label="edit" color="primary" size="small" component="span"
                            style={{ position: 'absolute', right: '-10px', top: '0px' }}>
                    <SettingsIcon fontSize="small"/>
                </IconButton>
                <Container>
                    <Box>
                        <Typography variant='subtitle1' display='inline'>Период: {this.formatDate(periodBegin)}</Typography>
                        <Typography variant='subtitle1' display='inline'> - </Typography>
                        <Typography variant='subtitle1' display='inline'>{this.formatDate(periodEnd)}</Typography>
                    </Box>
                    <Box>
                        <Typography variant='subtitle1' display='inline'>Доход: {income}</Typography>
                        <IconButton aria-label="edit" color="primary" size="small" component="span">
                            <EditIcon fontSize="small"/>
                        </IconButton>
                    </Box>
                </Container>
                <Box>
                    <ol>{expendituresRender}</ol>
                </Box>
            </Paper>
        );
    }
}

export default Period;
