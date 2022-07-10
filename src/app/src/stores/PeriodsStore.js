import { makeObservable, observable, action, runInAction } from 'mobx';

import { getPeriods, savePeriod, deletePeriod } from '../services/periodsService';
import { getIncomes, saveIncome, deleteIncome } from '../services/incomesService';
import { getExpenditures, saveExpenditure, deleteExpenditure } from '../services/expendituresService';


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

    changePeriod = async period => {
        await savePeriod(period)
        await this.fillPeriods();
    };

    deletePeriod = async id => {
        await deletePeriod(id);
        await this.fillPeriods();
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

    addPeriodIncome = async income => {
        const period = this.periods.find(i => i.id === income.periodId);
        if (period) {
            await saveIncome(income);
            const newIncomes = await getIncomes(income.periodId);

            runInAction(() => {
                period.incomes = newIncomes;
            })
        }
    };

    changeExpenditure = async expenditure => {
        const period = this.periods.find(i => i.id === expenditure.periodId);
        if (period) {
            await saveExpenditure(expenditure);
            const newExpenditures = await getExpenditures(period.id);

            runInAction(() => {
                period.expenditures = newExpenditures;
            })
        }
    };

    deleteExpenditure = async (periodId, id) => {
        const period = this.periods.find(i => i.id === periodId);
        if (period) {
            await deleteExpenditure(id);
            const newExpenditures = await getExpenditures(periodId);

            runInAction(() => {
                period.expenditures = newExpenditures;
            })
        }
    };
}

export default PeriodsStore;
