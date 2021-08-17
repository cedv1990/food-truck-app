const ApiFoodTruck = require('../../external/food-truck');

class FoodTruckController {
    static async getAllFoodTrucks(req, res) {
        try {
            const data = await ApiFoodTruck.getList();
            res.status(200).send(data);
        } catch (e) {
            console.log('Error in getAllFoodTrucks method', e);
            res.sendStatus(500);
        }
    }
}

module.exports = FoodTruckController;
