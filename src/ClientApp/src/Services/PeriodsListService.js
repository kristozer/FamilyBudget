class PeriodsListService {
    async GetPeriods() {
        const response = await fetch('budgetperiods');
        return response.json();
    };
}

export default new PeriodsListService();
