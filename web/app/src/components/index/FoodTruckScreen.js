import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';

import { appStartGeolocation, appStartLoading, centerGeolocation } from '../../actions/app';
import GoogleMap from '../maps';

import './style.css';

export const FoodTruckScreen = (props) => {
    const { foodTruckList, gelocation: { coords }, error } = useSelector(state => state.app);
    const { loading } = useSelector(state => state.ui);

    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(appStartLoading());
    }, [dispatch]);

    useEffect(() => {
        dispatch(appStartGeolocation());
    }, [dispatch]);

    if (loading) {
        return (
            <div className="loading">
                Loading food trucks locations, please wait... meanwhile, drink a coffee <span>☕</span>
            </div>
        );
    }

    if (error) {
        const url = process.env.NODE_ENV === 'development' ? 'http://localhost:5000/swagger/index.html' : '';
        return (
            <div className="loading error">
                An error occurred while querying the food trucks... are you sure the dotnet API is running? <span>💔</span><br />
                <p>Check out <a href={url} target="_blank" rel="noreferrer">this page</a></p>
            </div>
        );
    }

    const { latitude, longitude } = coords;

    const formatDescription = (locationDescription, address, foodItems, latitude, longitude) => (
        <div>
            <p><b>Location detail:</b> {locationDescription}</p>
            <p><b>Address:</b> {address}</p>
            {foodItems && foodItems.length > 0 && (
                <>
                    <p><b>Food items:</b></p>
                    <div className="tags-container">
                        {foodItems?.split(': ').map((item, i) => (
                            <div key={`item-${i}`} className="tag">{item}</div>
                        ))}
                    </div>
                </>
            )}
            <a
                target="_blank"
                rel="noreferrer"
                href={`https://www.google.com/maps/@${latitude},${longitude},12z`}
            >
                Open location
            </a>
        </div>
    );

    const handleCenter = () => {
        const latitude = 37.7386361;
        const longitude = -122.4481364;
        dispatch(centerGeolocation({ latitude, longitude }));
    };

    return (
        <div>
            <aside>
                Food Truck App &reg; &copy;
                <br /><br />
                <button type="button" onClick={handleCenter}>Center at San Francisco</button>
            </aside>
            {latitude && longitude && foodTruckList.length > 0 && (
                <GoogleMap
                    center={{ longitude, latitude }}
                    locations={foodTruckList.map(({ address, facilityType, foodItems, id, latitude, locationDescription, longitude, name }) => ({
                        location: { latitude, longitude },
                        type: facilityType,
                        title: name,
                        description: formatDescription(locationDescription, address, foodItems, latitude, longitude),
                        id,
                    }))}
                />
            )}
        </div>
    );
};
