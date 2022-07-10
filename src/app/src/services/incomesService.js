import { get, post } from './apiService';

export async function saveIncome(income) {
    return post(`https://localhost:5001/Incomes/SaveIncome`, income);
}

export function getIncomes(periodId) {
    return get(`https://localhost:5001/Incomes/Get?periodId=${periodId}`);
}

export function deleteIncome(id) {
    return post(`https://localhost:5001/Incomes/DeleteIncome?id=${id}`);
}
