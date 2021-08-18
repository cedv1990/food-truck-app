import { types } from '../types';

import FoodTruckApi from '../services/food-truck';
import { handleLocationPermission } from '../helpers/location';

export const appStartLoading = () => async (dispatch) => {
    try {
        const resp = await FoodTruckApi.getFoodTruckSites();
        if (!resp) {
            throw new Error('Empty response');
        }
        dispatch(listLoaded(resp));
    } catch (error) {
        console.log(`Error trying to getFoodTruckSites: ${error}`);
        dispatch(errorLoadingData())
    }
};

export const appStartGeolocation = () => async (dispatch) => {
    try {
        const { coords, status } = await handleLocationPermission();
        if (!coords) {
            dispatch(errorRequestGeolocation());
            return;
        }
        dispatch(
            setGeolocation({
                status,
                coords: {
                    accuracy: coords.accuracy,
                    altitude: coords.altitude,
                    altitudeAccuracy: coords.altitudeAccuracy,
                    heading: coords.heading,
                    latitude: coords.latitude,
                    longitude: coords.longitude,
                }
            })
        );
    } catch (error) {
        console.log(`Error trying to request geolocation: ${error}`);
        dispatch(errorRequestGeolocation());
    }
};

const listLoaded = (foodTrucks) => ({
    type: types.appListLoaded,
    payload: foodTrucks,
});

const setGeolocation = (data) => ({
    type: types.setGeolocation,
    payload: data,
});

const errorLoadingData = () => ({
    type: types.errorLoadingData,
});

const errorRequestGeolocation = () => ({
    type: types.errorRequestGeolocation,
});
