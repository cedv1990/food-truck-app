import { types } from '../types';

const initialState = {
    foodTruckList: [],
};

export const appReducer = (state = initialState, action) => {
    switch (action.type) {
        case types.appListLoaded:
            return {
                ...state,
                foodTruckList: action.payload,
            };
        default:
            return state;
    }
};
