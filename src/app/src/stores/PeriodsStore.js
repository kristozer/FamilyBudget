import { makeObservable, observable, action, runInAction } from 'mobx';


class PeriodsStore {
    periods = [];
    showPeriods = false;

    constructor() {
        makeObservable(this, {
            periods: observable,
            showPeriods: observable,
            fillPeriods: action,
            deletePeriodIncome: action
        });
    }

    fillPeriods = () => {
        //const periods = await periodsListService.GetPeriods();
        const testPeriods = [{
            id: 1,
            name: `First`,
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
            this.periods = testPeriods;
            this.showPeriods = true;
        })
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
            const maxIncomeId = Math.max(...this.periods[this.periods.length-1].incomes.map(x => x.id));
            period.incomes.push({
                id: maxIncomeId+1,
                name: income.name,
                value: income.value
            });
        }
    };

    changeExpenditure = (id, newPlannedToSpend, newSpentValue) => {
        const expedinture = this.periods.flatMap(p => p.expenditures).find(e => e.id === id)

        if (expedinture) {
            expedinture.plannedToSpendValue = newPlannedToSpend;
            expedinture.spentValue = newSpentValue;
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
