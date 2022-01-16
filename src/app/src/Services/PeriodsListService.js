class PeriodsListService {
    async GetPeriods() {
        const response = await fetch('https://localhost:5001/budgetperiods/');
        return response.json();
    };
}

export default new PeriodsListService();
