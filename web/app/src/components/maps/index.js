import PropTypes from 'prop-types';
import GoogleMapReact from 'google-map-react';

import './style.css';

const types = {
    0: {
        src: 'https://image.flaticon.com/icons/png/512/1276/1276208.png',
        tooltip: 'Food truck'
    },
    1: {
        src: 'https://image.flaticon.com/icons/png/512/5043/5043154.png',
        tooltip: 'Push cart'
    },
    2: {
        src: 'https://image.flaticon.com/icons/png/512/2634/2634120.png',
        tooltip: '(Not specified)'
    },
};

const AnyReactComponent = ({ title, type, children }) => {
    const { src, tooltip } = types[type];
    return (
        <div className="food-truck">
            <img srcSet={src} alt={title} title={tooltip} />
            <div className="content">
                <h3>{title}</h3>
                {children}
            </div>
        </div>
    );
};

const GoogleMap = ({ center: { latitude, longitude }, locations }) => {
    const markers = locations.map(({
        id,
        title,
        description,
        type,
        location,
    }) => (
        <AnyReactComponent
            key={`site-${id}`}
            lat={location.latitude}
            lng={location.longitude}
            title={title}
            type={type}
        >
            {description}
        </AnyReactComponent>
    ));
    return (
        <div style={{ height: '100vh', width: '100%' }}>
            <GoogleMapReact
                bootstrapURLKeys={{ key: 'AIzaSyCHRcw3FIUilwa42WbrsCXWDD3YfwJSaaY' }}
                center={[latitude, longitude]}
                zoom={12}
            >
                {markers}
            </GoogleMapReact>
        </div>
    );
};

GoogleMap.propTypes = {
    center: PropTypes.shape({
        longitude: PropTypes.number.isRequired,
        latitude: PropTypes.number.isRequired,
    }),
    locations: PropTypes.arrayOf(
        PropTypes.shape({
            location: PropTypes.shape({
                longitude: PropTypes.number.isRequired,
                latitude: PropTypes.number.isRequired,
            }).isRequired,
            type: PropTypes.oneOf([0, 1, 2]).isRequired,
            title: PropTypes.string.isRequired,
            description: PropTypes.any.isRequired,
            id: PropTypes.number.isRequired,
        }).isRequired
    ),
};

export default GoogleMap;
