import { get, post } from './apiService';

export function getPeriods() {
    return get('https://localhost:5001/budgetperiods/');
}

export async function savePeriod(period) {
    return post(`https://localhost:5001/BudgetPeriods/SavePeriod`, period);
}

export function deletePeriod(id) {
    return post(`https://localhost:5001/BudgetPeriods/DeletePeriod?id=${id}`);
}
