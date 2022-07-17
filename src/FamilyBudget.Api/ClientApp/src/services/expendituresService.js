import { get, post } from './apiService';

export async function saveExpenditure(expenditure) {
    return post(`Expenditures/SaveExpenditure`, expenditure);
}

export function getExpenditures(periodId) {
    return get(`Expenditures/Get?periodId=${periodId}`);
}

export function deleteExpenditure(id) {
    return post(`Expenditures/DeleteExpenditure?id=${id}`);
}
