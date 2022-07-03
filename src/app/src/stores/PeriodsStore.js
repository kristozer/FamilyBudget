import { makeObservable, observable, action, runInAction } from 'mobx';


class PeriodsStore {
    periods = [];
    showPeriods = false;

    constructor() {
        makeObservable(this, {
            periods: observable,
            showPeriods: observable,
            fillPeriods: action,
            changePeriod: action,
            deletePeriodIncome: action,
            addPeriodIncome: action,
            changeExpenditure: action,
            deleteExpenditure: action
        });
    }

    fillPeriods = () => {
        const periods = await periodsListService.GetPeriods();
        const testPeriods = [{
            id: 1,
            periodBegin: new Date('2022-01-01'),
            periodEnd: new Date('2022-06-30'),
            incomes: [{
                id: 1,
                name: `Зарплата`,
                value: 100
            },
                {
                    id: 2,
                    name: `Подарки`,
                    value: 5
                }],
            expenditures: [{
                id: 1,
                name: `Еда`,
                plannedToSpendValue: 5,
                spentValue: 5
            },{
                id: 2,
                name: `Одежда`,
                plannedToSpendValue: 5,
                spentValue: 15
            }]
        }];

        runInAction(() => {
            this.periods = periods;
            this.showPeriods = true;
        })
    };

    changePeriod = (period) => {
        if (period.id === 0) {
            const maxPeriodId = Math.max(...this.periods.map(x => x.id), 0);
            this.periods.push({
                id: maxPeriodId + 1,
                name: period.name,
                periodBegin: period.periodBegin,
                periodEnd: period.periodEnd,
                incomes:[],
                expenditures:[]
            });

            return;
        }


        const currentPeriod = this.periods.find(i => i.id === period.id);
        if (currentPeriod) {
            currentPeriod.name = period.name;
            currentPeriod.periodBegin = period.periodBegin;
            currentPeriod.periodEnd = period.periodEnd;
        }
    };

    deletePeriodIncome = (periodId, incomeId) => {
        const period = this.periods.find(i => i.id === periodId);
        if (period) {
            period.incomes = period.incomes.filter(i => i.id !== incomeId);
        }
    };

    addPeriodIncome = (periodId, income) => {
        const period = this.periods.find(i => i.id === periodId);
        if (period) {
            const maxIncomeId = Math.max(...this.periods[this.periods.length-1].incomes.map(x => x.id), 0);
            period.incomes.push({
                id: maxIncomeId+1,
                name: income.name,
                value: income.value
            });
        }
    };

    changeExpenditure = (periodId, expenditure) => {
        if(expenditure.id === 0) {
            const period = this.periods.find(i => i.id === periodId);
            if (period) {
                const maxExpenditureId = Math.max(...this.periods.flatMap(p => p.expenditures).map(x => x.id), 0);
                period.expenditures.push({
                    id: maxExpenditureId+1,
                    name: expenditure.name,
                    plannedToSpendValue: expenditure.plannedToSpendValue,
                    spentValue: expenditure.spentValue
                });
            }

            return;
        }

        const currentExpenditure = this.periods.flatMap(p => p.expenditures).find(e => e.id === expenditure.id)
        if (currentExpenditure) {
            currentExpenditure.name = expenditure.name;
            currentExpenditure.plannedToSpendValue = expenditure.plannedToSpendValue;
            currentExpenditure.spentValue = expenditure.spentValue;
        }
    };

    deleteExpenditure = id => {
        const period = this.periods.find(p => p.expenditures.find(e => e.id === id));
        if(period) {
            period.expenditures = period.expenditures.filter(e => e.id !== id);
        }
    };
}

export default PeriodsStore;
