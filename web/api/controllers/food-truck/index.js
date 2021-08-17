const express = require('express');
const FoodTruckController = require('./controller');

var router = express.Router();

router.get('/', FoodTruckController.getAllFoodTrucks);

module.exports = router;
