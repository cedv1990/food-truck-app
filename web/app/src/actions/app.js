import { types } from '../types';

import FoodTruckApi from '../services/food-truck';

export const appStartLoading = () => async (dispatch) => {
    try {
        const resp = await FoodTruckApi.getFoodTruckSites();
        dispatch(listLoaded(resp));
    } catch (error) {
        console.log(error);
    }
};

const listLoaded = (foodTrucks) => ({
    type: types.appListLoaded,
    payload: foodTrucks,
});
