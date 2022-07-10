import { get, post } from './apiService';

export async function saveExpenditure(expenditure) {
    return post(`https://localhost:5001/Expenditures/SaveExpenditure`, expenditure);
}

export function getExpenditures(periodId) {
    return get(`https://localhost:5001/Expenditures/Get?periodId=${periodId}`);
}

export function deleteExpenditure(id) {
    return post(`https://localhost:5001/Expenditures/DeleteExpenditure?id=${id}`);
}
