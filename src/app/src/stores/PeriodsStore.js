import { makeObservable, observable, action, runInAction } from 'mobx';

import { getPeriods } from '../services/periodsService';
import { getIncomes, saveIncome, deleteIncome } from '../services/incomesService';


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

    fillPeriods = async () => {
        const periods = await getPeriods();

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

    deletePeriodIncome = async (periodId, incomeId) => {
        const period = this.periods.find(i => i.id === periodId);
        if (period) {
            await deleteIncome(incomeId);
            const newIncomes = await getIncomes(periodId);

            runInAction(() => {
                period.incomes = newIncomes;
            })
        }
    };

    addPeriodIncome = async (income) => {
        const period = this.periods.find(i => i.id === income.periodId);
        if (period) {
            await saveIncome(income);
            const newIncomes = await getIncomes(income.periodId);

            runInAction(() => {
                period.incomes = newIncomes;
            })
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
