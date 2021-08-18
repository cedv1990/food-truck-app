import { types } from '../types';

const initialState = {
    foodTruckList: [],
    error: false,
    gelocation: {
        status: '',
        coords: {},
    },
    geolocationError: false,
};

export const appReducer = (state = initialState, action) => {
    switch (action.type) {
        case types.appListLoaded:
            return {
                ...state,
                foodTruckList: action.payload,
            };
        case types.errorLoadingData:
            return {
                ...state,
                error: true,
            };
        case types.errorRequestGeolocation:
            return {
                ...state,
                geolocationError: true,
            };
        case types.setGeolocation:
            return {
                ...state,
                geolocationError: false,
                gelocation: {
                    ...action.payload,
                },
            };
        default:
            return state;
    }
};
