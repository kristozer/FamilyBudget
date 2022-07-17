import { get, post } from './apiService';

export function getPeriods() {
    return get('budgetperiods');
}

export async function savePeriod(period) {
    return post(`BudgetPeriods/SavePeriod`, period);
}

export function deletePeriod(id) {
    return post(`BudgetPeriods/DeletePeriod?id=${id}`);
}
