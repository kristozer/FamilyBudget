import { get, post } from './apiService';

export async function saveIncome(income) {
    return post(`Incomes/SaveIncome`, income);
}

export function getIncomes(periodId) {
    return get(`Incomes/Get?periodId=${periodId}`);
}

export function deleteIncome(id) {
    return post(`Incomes/DeleteIncome?id=${id}`);
}
