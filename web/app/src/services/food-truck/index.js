class FoodTruckApi {
    getFoodTruckSites() {
        return fetch('/api/food-truck')
            .then(response => response.json())
            .catch(err => console.log('Fetch Error', err));
    }
}

export default new FoodTruckApi();
