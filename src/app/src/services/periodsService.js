import { get } from './apiService';

export function getPeriods() {
    return get('https://localhost:5001/budgetperiods/');
}
