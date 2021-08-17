import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';

import { appStartLoading } from '../../actions/app';

export const FoodTruckScreen = (props) => {
    const { foodTruckList } = useSelector(state => state.app);

    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(appStartLoading());
    }, [dispatch]);

    return (
        <div>
            {foodTruckList.length} puestos de comida cargados
        </div>
    );
};
