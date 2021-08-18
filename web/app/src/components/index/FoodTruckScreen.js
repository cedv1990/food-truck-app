import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';

import { appStartGeolocation, appStartLoading } from '../../actions/app';
import GoogleMap from '../maps';

export const FoodTruckScreen = (props) => {
    const { foodTruckList, gelocation: { coords } } = useSelector(state => state.app);

    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(appStartLoading());
    }, [dispatch]);

    useEffect(() => {
        dispatch(appStartGeolocation());
    }, [dispatch]);

    const { latitude, longitude } = coords;

    return (
        <div>
            {foodTruckList.length} puestos de comida cargados
            {latitude && longitude && (
                <GoogleMap
                    center={{ longitude, latitude }}
                />
            )}
        </div>
    );
};
