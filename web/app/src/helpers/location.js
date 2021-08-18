export const handleLocationPermission = () => new Promise(async (resolve, reject) => {
    try {
        const { state } = await navigator.permissions.query({ name: 'geolocation' });
        switch (state) {
            case 'prompt':
            case 'granted':
                navigator.geolocation.getCurrentPosition(({ coords }) => resolve({ status: state, coords }), reject);
                break;
            default:
                reject({ state });
                break;
        }
    } catch (e) {
        reject(e);
    }
});
